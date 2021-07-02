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
    public class AnimesCategoriasController : Controller
    {
        private readonly AnimeDB _context;

        public AnimesCategoriasController(AnimeDB context)
        {
            _context = context;
        }

        // GET: AnimesCategorias
        public async Task<IActionResult> Index()
        {
            var animeDB = _context.AnimesCategoria.Include(a => a.Animes).Include(a => a.Categorias);
            return View(await animeDB.ToListAsync());
        }

        // GET: AnimesCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animesCategoria = await _context.AnimesCategoria
                .Include(a => a.Animes)
                .Include(a => a.Categorias)
                .FirstOrDefaultAsync(m => m.idAnimesCategoria == id);
            if (animesCategoria == null)
            {
                return NotFound();
            }

            return View(animesCategoria);
        }

        // GET: AnimesCategorias/Create
        public IActionResult Create()
        {
            ViewData["AnimesFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime");
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria");
            return View();
        }

        // POST: AnimesCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAnimesCategoria,AnimesFK,CategoriaFK")] AnimesCategoria animesCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animesCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimesFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", animesCategoria.AnimesFK);
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", animesCategoria.CategoriaFK);
            return View(animesCategoria);
        }

        // GET: AnimesCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animesCategoria = await _context.AnimesCategoria.FindAsync(id);
            if (animesCategoria == null)
            {
                return NotFound();
            }
            ViewData["AnimesFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", animesCategoria.AnimesFK);
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", animesCategoria.CategoriaFK);
            return View(animesCategoria);
        }

        // POST: AnimesCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAnimesCategoria,AnimesFK,CategoriaFK")] AnimesCategoria animesCategoria)
        {
            if (id != animesCategoria.idAnimesCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animesCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimesCategoriaExists(animesCategoria.idAnimesCategoria))
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
            ViewData["AnimesFK"] = new SelectList(_context.Animes, "IdAnime", "IdAnime", animesCategoria.AnimesFK);
            ViewData["CategoriaFK"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", animesCategoria.CategoriaFK);
            return View(animesCategoria);
        }

        // GET: AnimesCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animesCategoria = await _context.AnimesCategoria
                .Include(a => a.Animes)
                .Include(a => a.Categorias)
                .FirstOrDefaultAsync(m => m.idAnimesCategoria == id);
            if (animesCategoria == null)
            {
                return NotFound();
            }

            return View(animesCategoria);
        }

        // POST: AnimesCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animesCategoria = await _context.AnimesCategoria.FindAsync(id);
            _context.AnimesCategoria.Remove(animesCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimesCategoriaExists(int id)
        {
            return _context.AnimesCategoria.Any(e => e.idAnimesCategoria == id);
        }
    }
}
