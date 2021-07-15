using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidgetBee.Data;
using MidgetBee.Models;

namespace MidgetBee.Controllers.API {
    [Route("api/[controller]")]
    [ApiController]
    public class API : ControllerBase {
        private readonly AnimeDB _context;

        private readonly IWebHostEnvironment _caminho;

        public API(AnimeDB context, IWebHostEnvironment caminho) {
            _context = context;
            _caminho = caminho;
        }

        // GET: api/API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimesAPIViewModel>>> GetAnimes() {
            var listaAnimes = await _context.Animes
                                 .Select(j => new AnimesAPIViewModel {
                                     IdAnime = j.IdAnime,
                                     Nome = j.Nome,
                                     QuantEpisodios = j.QuantEpisodios,
                                     Autor = j.Autor,
                                     Estudio = j.Estudio,
                                     Data = j.Data,
                                     Links = j.Links,
                                     Rating = j.Rating,
                                     Fotografia = j.Fotografia,
                                 }
                                 )
                                 .OrderBy(j => j.IdAnime)
                                 .ToListAsync();
            return listaAnimes;
        }

        // GET: api/API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animes>> GetAnimes(int id) {
            var animes = await _context.Animes.FindAsync(id);

            if (animes == null) {
                return NotFound();
            }

            return animes;
        }

        // PUT: api/API/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimes(int id, Animes animes) {
            if (id != animes.IdAnime) {
                return BadRequest();
            }

            _context.Entry(animes).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!AnimesExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/API
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animes>> PostAnimes([FromForm] Animes anime, IFormFile UpFotografia)  {
            anime.Fotografia = "";
            string localizacao = _caminho.WebRootPath;
            var nomeFoto = Path.Combine(localizacao, "fotos", UpFotografia.FileName);
            var fotoUp = new FileStream(nomeFoto, FileMode.Create);
            await UpFotografia.CopyToAsync(fotoUp);
            anime.Fotografia = UpFotografia.FileName;
            try {
                _context.Animes.Add(anime);
                await _context.SaveChangesAsync();
            } catch (Exception ex) {

                throw;
            }
            

            return CreatedAtAction("GetAnimes", new { id = anime.IdAnime }, anime);
        }

        // DELETE: api/API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimes(int id) {
            var animes = await _context.Animes.FindAsync(id);
            if (animes == null) {
                return NotFound();
            }

            _context.Animes.Remove(animes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimesExists(int id) {
            return _context.Animes.Any(e => e.IdAnime == id);
        }
    }
}
