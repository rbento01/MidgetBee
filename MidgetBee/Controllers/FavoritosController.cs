using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MidgetBee.Data;
using MidgetBee.Models;

namespace MidgetBee.Controllers {
    public class FavoritosController : Controller {
        private readonly AnimeDB _context;

        public FavoritosController(AnimeDB context) {
            _context = context;
        }

        // GET: Favoritos
        public async Task<IActionResult> Index() {
            var animeDB = _context.Favoritos.Include(f => f.Anime)
                                            .Include(f => f.Utilizador);
            return View(await animeDB.ToListAsync());
        }

        // GET: Favoritos/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var favoritos = await _context.Favoritos
                .Include(f => f.Anime)
                .Include(f => f.Utilizador)
                .FirstOrDefaultAsync(m => m.IdFavoritos == id);
            if (favoritos == null) {
                return NotFound();
            }

            return View(favoritos);
        }

        // GET: Favoritos/Create
        public IActionResult Create() {
            ViewData["AnimeFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime");
            ViewData["UsersFK"] = new SelectList(_context.Utilizadores, "IdUsers", "IdUsers");
            return View();
        }

        // POST: Favoritos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFavoritos,UsersFK,AnimeFK")] Favoritos favoritos) {
            if (ModelState.IsValid) {
                _context.Add(favoritos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimeFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", favoritos.AnimeFK);
            ViewData["UsersFK"] = new SelectList(_context.Utilizadores, "IdUsers", "IdUsers", favoritos.UsersFK);
            return View(favoritos);
        }

        // GET: Favoritos/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var favoritos = await _context.Favoritos.FindAsync(id);
            if (favoritos == null) {
                return NotFound();
            }
            ViewData["AnimeFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", favoritos.AnimeFK);
            ViewData["UsersFK"] = new SelectList(_context.Utilizadores, "IdUsers", "IdUsers", favoritos.UsersFK);
            return View(favoritos);
        }

        // POST: Favoritos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFavoritos,UsersFK,AnimeFK")] Favoritos favoritos) {
            if (id != favoritos.IdFavoritos) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(favoritos);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!FavoritosExists(favoritos.IdFavoritos)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimeFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", favoritos.AnimeFK);
            ViewData["UsersFK"] = new SelectList(_context.Utilizadores, "IdUsers", "IdUsers", favoritos.UsersFK);
            return View(favoritos);
        }

        // GET: Favoritos/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var favoritos = await _context.Favoritos
                .Include(f => f.Anime)
                .Include(f => f.Utilizador)
                .FirstOrDefaultAsync(m => m.IdFavoritos == id);
            if (favoritos == null) {
                return NotFound();
            }

            return View(favoritos);
        }

        // POST: Favoritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var favoritos = await _context.Favoritos.FindAsync(id);
            _context.Favoritos.Remove(favoritos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoritosExists(int id) {
            return _context.Favoritos.Any(e => e.IdFavoritos == id);
        }
    }
}
