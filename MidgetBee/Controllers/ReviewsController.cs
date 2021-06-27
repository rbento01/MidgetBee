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
    public class ReviewsController : Controller {
        private readonly AnimeDB _context;

        public ReviewsController(AnimeDB context) {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index() {
            var animeDB = _context.Reviews.Include(r => r.Anime).Include(r => r.Utilizador);
            return View(await animeDB.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Anime)
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.IdReview == id);
            if (reviews == null) {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create() {
            ViewData["AnimeFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime");
            ViewData["UsersFK"] = new SelectList(_context.Utilizadores, "IdUsers", "IdUsers");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReview,Comentario,Rating,Data,Visibilidade,UsersFK,AnimeFK")] Reviews reviews) {
            if (ModelState.IsValid) {
                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimeFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", reviews.AnimeFK);
            ViewData["UsersFK"] = new SelectList(_context.Utilizadores, "IdUsers", "IdUsers", reviews.UsersFK);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null) {
                return NotFound();
            }
            ViewData["AnimeFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", reviews.AnimeFK);
            ViewData["UsersFK"] = new SelectList(_context.Utilizadores, "IdUsers", "IdUsers", reviews.UsersFK);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReview,Comentario,Rating,Data,Visibilidade,UsersFK,AnimeFK")] Reviews reviews) {
            if (id != reviews.IdReview) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!ReviewsExists(reviews.IdReview)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimeFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", reviews.AnimeFK);
            ViewData["UsersFK"] = new SelectList(_context.Utilizadores, "IdUsers", "IdUsers", reviews.UsersFK);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Anime)
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.IdReview == id);
            if (reviews == null) {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewsExists(int id) {
            return _context.Reviews.Any(e => e.IdReview == id);
        }
    }
}
