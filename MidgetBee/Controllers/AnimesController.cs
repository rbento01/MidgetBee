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

namespace MidgetBee.Controllers {
    public class AnimesController : Controller {
        private readonly AnimeDB _context;

        /// <summary>
        /// objeto para gerir os dados dos Utilizadores registados
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        public AnimesController(AnimeDB context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
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
                                       .Include(ul => ul.ListaDeUsers)
                                       .OrderByDescending(r => r.Data)
                                       .FirstOrDefaultAsync();
            if (anime == null) {
                return NotFound();
            }

            // lista de todas as categorias existentes
            ViewBag.ListaDeUsers = _context.Utilizadores.OrderBy(c => c.IdUsers).ToList();

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

            if (utilizador.contComment == false) {
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
                utilizador.contComment = true;

                // dá update à database para aparecer true
                _context.Utilizadores.Update(utilizador);

                // guarda na base de dados
                await _context.SaveChangesAsync();

                // redireciona o user para a página dos Details do Anime que o user antes estava
                return RedirectToAction(nameof(Details), new { id = animeID });
            } else {

                ModelState.AddModelError("", "You can only comment once. Sorry.");
                return RedirectToAction("Erro", "Animes");
            }

        }

        public async Task<IActionResult> AddFavoritos(int animeID) {
            // esta variável vai ter o valor do username do utilizador
            var utilizador = _context.Utilizadores.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefault();


        }

        // GET: Animes/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnime,Nome,QuantEpisodios,Rating,Sinopse,Autor,Estudio,Data,Links,Fotografia,Categoria")] Animes animes) {
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
        public async Task<IActionResult> Edit(int id, [Bind("IdAnime,Nome,QuantEpisodios,Rating,Sinopse,Autor,Estudio,Data,Links,Fotografia,Categoria")] Animes animes) {
            if (id != animes.IdAnime) {
                return NotFound();
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
