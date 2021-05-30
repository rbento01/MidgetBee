using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MidgetBee.Data;
using MidgetBee.Models;

namespace MidgetBee.Controllers
{
    public class AnimesController : Controller
    {
        private readonly AnimeDB _context;

        public AnimesController(AnimeDB context)
        {
            _context = context;
        }

        // GET: Animes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animes.ToListAsync());
        }

        // GET: Animes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animes = await _context.Animes
                .FirstOrDefaultAsync(m => m.IdAnime == id);
            if (animes == null)
            {
                return NotFound();
            }

            return View(animes);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnime,Nome,QuantEpisodios,Rating,Sinopse,Autor,Estudio,Data,Links,Fotografia,Categoria")] Animes animes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animes);
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animes = await _context.Animes.FindAsync(id);
            if (animes == null)
            {
                return NotFound();
            }
            return View(animes);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnime,Nome,QuantEpisodios,Rating,Sinopse,Autor,Estudio,Data,Links,Fotografia,Categoria")] Animes animes)
        {
            if (id != animes.IdAnime)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimesExists(animes.IdAnime))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(animes);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animes = await _context.Animes
                .FirstOrDefaultAsync(m => m.IdAnime == id);
            if (animes == null)
            {
                return NotFound();
            }

            return View(animes);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animes = await _context.Animes.FindAsync(id);
            _context.Animes.Remove(animes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimesExists(int id)
        {
            return _context.Animes.Any(e => e.IdAnime == id);
        }
    }
}
