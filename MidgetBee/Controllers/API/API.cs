using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidgetBee.Data;
using MidgetBee.Models;

namespace MidgetBee.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class API : ControllerBase
    {
        private readonly AnimeDB _context;

        public API(AnimeDB context)
        {
            _context = context;
        }

        // GET: api/API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimesAPIViewModel>>> GetAnimes()
        {
            var listaAnimes = await _context.Animes
                                 .Select(j => new AnimesAPIViewModel {
                                     Fotografia = j.Fotografia,
                                     IdAnime = j.IdAnime,
                                     Nome = j.Nome,
                                     Rating = j.Rating,
                                     Categoria = j.Categoria
                                 }
                                 )
                                 .OrderBy(j => j.IdAnime)
                                 .ToListAsync();
            return listaAnimes;
        }

        // GET: api/API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animes>> GetAnimes(int id)
        {
            var animes = await _context.Animes.FindAsync(id);

            if (animes == null)
            {
                return NotFound();
            }

            return animes;
        }

        // PUT: api/API/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimes(int id, Animes animes)
        {
            if (id != animes.IdAnime)
            {
                return BadRequest();
            }

            _context.Entry(animes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/API
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animes>> PostAnimes(Animes animes)
        {
            _context.Animes.Add(animes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimes", new { id = animes.IdAnime }, animes);
        }

        // DELETE: api/API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimes(int id)
        {
            var animes = await _context.Animes.FindAsync(id);
            if (animes == null)
            {
                return NotFound();
            }

            _context.Animes.Remove(animes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimesExists(int id)
        {
            return _context.Animes.Any(e => e.IdAnime == id);
        }
    }
}
