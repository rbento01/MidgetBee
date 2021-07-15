using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MidgetBee.Data;
using MidgetBee.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections.Generic;

namespace MidgetBee.Controllers {
    public class AnimesController : Controller {
        private readonly AnimeDB _context;

        /// <summary>
        /// objeto para gerir os dados dos Utilizadores registados
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IWebHostEnvironment _webhost;

        public AnimesController(AnimeDB context, UserManager<IdentityUser> userManager, IWebHostEnvironment webhost) {
            _context = context;
            _userManager = userManager;
            _webhost = webhost;
        }

        // GET: Animes
        public async Task<IActionResult> Index() {

            return View(await _context.Animes.ToListAsync());
        }

        // GET: Animes/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            /* SQL:
             * 
             * SELECT *
             * FROM Animes.ListaDeReviews ar, Animes a, Reviews r
             * WHERE a.IdAnime = id
             * ORDER BY r.Data;
             */

            var anime = await _context.Animes
                                       .Where(a => a.IdAnime == id)
                                       .Include(ar => ar.ListaDeReviews)
                                       .ThenInclude(r => r.Utilizador)
                                       .OrderByDescending(r => r.Data)
                                       .Include(ac => ac.ListaDeCategorias)
                                       .FirstOrDefaultAsync();
            if (anime == null) {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated) {
                // esta variável vai ter o valor do username do utilizador
                var utilizador = await _context.Utilizadores.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefaultAsync();

                // vai procurar pelo "Gosto" do User
                var favorito = await _context.Favoritos.Where(f => f.AnimeFK == id && f.UsersFK == utilizador.IdUsers).FirstOrDefaultAsync();

                if (favorito == null) {
                    ViewBag.Favorito = false;
                } else {
                    ViewBag.Favorito = true;
                }
            }



            return View(anime);
        }

        /// <summary>
        /// Esta função vai-se encarregar de passar o valor da view para o controller
        /// </summary>
        /// <param name="animeID"></param> Vai possuir o identificador do Anime
        /// <param name="comentario"></param> Vai possuir a string que o user inseriu
        /// <param name="rating"></param> Vai possuir a rating que o user inseriu
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateComentario(int animeID, string comentario, int rating) {

            // esta variável vai ter o valor do username do utilizador
            var utilizador = _context.Utilizadores.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefault();

            if (utilizador.ContComment == false) {
                // objeto do tipo Reviews que vai possuir todos os atributos desse mesmo modelo
                var comment = new Reviews {
                    AnimeFK = animeID,
                    Comentario = comentario.Replace("\r\n", "<br />"),
                    Rating = rating,
                    Data = DateTime.Now,
                    Visibilidade = true,
                    Utilizador = utilizador
                };

                // adiciona esse objeto à base de dados
                _context.Reviews.Add(comment);

                // sinaliza que o utilizador já colocou um comentário
                utilizador.ContComment = true;

                // dá update à database para aparecer true
                _context.Utilizadores.Update(utilizador);

                // guarda na base de dados
                await _context.SaveChangesAsync();

                // redireciona o user para a página dos Details do Anime que o user antes estava
                return RedirectToAction(nameof(Details), new { id = animeID });
            } else {

                return RedirectToAction(nameof(Details), new { id = animeID });
            }

        }

        public async Task<IActionResult> AddFavoritos(int animeID) {
            // esta variável vai ter o valor do username do utilizador
            var utilizador = _context.Utilizadores.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefault();

            var favoritos = await _context.Favoritos.Where(f => f.AnimeFK == animeID && f.UsersFK == utilizador.IdUsers).FirstOrDefaultAsync();

            if (favoritos == null) {
                var fav = new Favoritos {
                    AnimeFK = animeID,
                    UsersFK = utilizador.IdUsers
                };
                // Adiciona na base de dados
                _context.Favoritos.Add(fav);

                // guarda na base de dados
                await _context.SaveChangesAsync();

                // redireciona o user para a página dos Details do Anime que o user antes estava
                return RedirectToAction(nameof(Details), new { id = animeID });
            } else {
                // remove da base de dados 
                _context.Favoritos.Remove(favoritos);

                // guarda na base de dados
                await _context.SaveChangesAsync();

                // redireciona o user para a página dos Details do Anime que o user antes estava
                return RedirectToAction(nameof(Details), new { id = animeID });
            }
        }

        // GET: Animes/Create
        public IActionResult Create() {
            // lista de todas as categorias existentes
            ViewBag.ListaDeCategorias = _context.Categorias.OrderBy(c => c.IdCategoria).ToList();

            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnime,Nome,QuantEpisodios,Rating,Sinopse,Autor,Estudio,Data,Links,Fotografia,Categoria")] Animes animes, IFormFile imgFile, int[] CategoriaEscolhida) {

            // avalia se o array com a lista de categorias escolhidas associadas ao anume está vazio ou não
            if (CategoriaEscolhida.Length == 0) {
                //É gerada uma mensagem de erro
                ModelState.AddModelError("", "É necessário selecionar pelo menos uma categoria.");
                // gerar a lista Categorias que podem ser associadas ao anime
                ViewBag.ListaDeCategorias = _context.Categorias.OrderBy(c => c.IdCategoria).ToList();
                // devolver controlo à View
                return View(animes);
            }

            // criar uma lista com os objetos escolhidos das Categorias
            List<Categorias> listaDeCategoriasEscolhidas = new List<Categorias>();
            // Para cada objeto escolhido..
            foreach (int item in CategoriaEscolhida) {
                //procurar a categoria
                Categorias Categoria = _context.Categorias.Find(item);
                // adicionar a Categoria à lista
                listaDeCategoriasEscolhidas.Add(Categoria);
            }

            // adicionar a lista ao objeto de "Animes"
            animes.ListaDeCategorias = listaDeCategoriasEscolhidas;

            animes.Fotografia = imgFile.FileName;

            //_webhost.WebRootPath vai ter o path para a pasta wwwroot
            var saveimg = Path.Combine(_webhost.WebRootPath, "fotos", imgFile.FileName);

            var imgext = Path.GetExtension(imgFile.FileName);

            if (imgext == ".jpg" || imgext == ".png") {
                using (var uploadimg = new FileStream(saveimg, FileMode.Create)) {
                    await imgFile.CopyToAsync(uploadimg);

                }
            }

            if (ModelState.IsValid) {
                _context.Add(animes);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(animes);
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            // lista de todas as categorias existentes
            ViewBag.ListaDeCategorias = _context.Categorias.OrderBy(c => c.IdCategoria).ToList();

            var animes = await _context.Animes.FindAsync(id);
            if (animes == null) {
                return NotFound();
            }
            return View(animes);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnime,Nome,QuantEpisodios,Rating,Sinopse,Autor,Estudio,Data,Links,Fotografia,Categoria")] Animes animes, IFormFile imgFile, int[] CategoriaEscolhida) {

            if (id != animes.IdAnime) {
                return NotFound();
            }

            // avalia se o array com a lista de categorias escolhidas associadas ao anime está vazio ou não
            if (CategoriaEscolhida.Length == 0) {
                //É gerada uma mensagem de erro
                ModelState.AddModelError("", "É necessário selecionar pelo menos uma categoria.");
                // gerar a lista Categorias que podem ser associadas ao anime
                ViewBag.ListaDeCategorias = _context.Categorias.OrderBy(c => c.IdCategoria).ToList();
                // devolver controlo à View
                return View(animes);
            }

            // criar uma lista com os objetos escolhidos das Categorias
            List<Categorias> listaDeCategoriasEscolhidas = new List<Categorias>();
            // Para cada objeto escolhido..
            foreach (int item in CategoriaEscolhida) {
                //procurar a categoria
                Categorias Categoria = _context.Categorias.Find(item);
                // adicionar a Categoria à lista
                listaDeCategoriasEscolhidas.Add(Categoria);
            }

            // adicionar a lista ao objeto de "Animes"
            animes.ListaDeCategorias = listaDeCategoriasEscolhidas;

            if (imgFile != null) {
                animes.Fotografia = imgFile.FileName;
                //_webhost.WebRootPath vai ter o path para a pasta wwwroot
                var saveimg = Path.Combine(_webhost.WebRootPath, "fotos", imgFile.FileName);
                var imgext = Path.GetExtension(imgFile.FileName);

                if (imgext == ".jpg" || imgext == ".png") {
                    using (var uploadimg = new FileStream(saveimg, FileMode.Create)) {
                        await imgFile.CopyToAsync(uploadimg);
                    }
                }
            } else {
                Animes animes1 = _context.Animes.Find(animes.IdAnime);

                _context.Entry<Animes>(animes1).State = EntityState.Detached;  //Explicitly Detach the orphan tracked instance 


                animes.Fotografia = animes1.Fotografia;
            }



            if (ModelState.IsValid) {
                try {
                    _context.Update(animes);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!AnimesExists(animes.IdAnime)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(animes);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var animes = await _context.Animes
                .FirstOrDefaultAsync(m => m.IdAnime == id);
            if (animes == null) {
                return NotFound();
            }

            return View(animes);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var animes = await _context.Animes.FindAsync(id);
            _context.Animes.Remove(animes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimesExists(int id) {
            return _context.Animes.Any(e => e.IdAnime == id);
        }
    }
}