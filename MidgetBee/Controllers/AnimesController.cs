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

            var anime = await _context.Animes
                                       .Where(a => a.IdAnime == id)
                                       .Include(a => a.ListaDeReviews)
                                       .ThenInclude(r => r.Utilizador)
                                       .OrderByDescending(r => r.Data)
                                       .FirstOrDefaultAsync();
            if (anime == null) {
                return NotFound();
            }

            return View(anime);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateComentario(int animeID, string comentario, int rating) {

            var utilizador = _context.Utilizadores.Where(u => u.UserNameID == _userManager.GetUserId(User)).FirstOrDefault();

            var comment = new Reviews {
                AnimeFK = animeID,
                Comentario = comentario.Replace("\r\n", "<br />"),
                Rating = rating,
                Data = DateTime.Now,
                Visibilidade = true,
                Utilizador = utilizador
            };

            _context.Reviews.Add(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = animeID });

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
