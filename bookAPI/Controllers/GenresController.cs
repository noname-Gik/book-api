using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPI.Models;
using BookAPI.Data;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly DataContext _context;

        public GenresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genres>>> GetGenres()
        {
          if (_context.Genres == null)
          {
              return NotFound();
          }
            return await _context.Genres.ToListAsync();
        }

        // GET: api/Genres/5
        [HttpGet("{name}")]
        public async Task<ActionResult<List<Genres>>> GetGenres(string name)
        {
          if (_context.Genres == null)
          {
              return NotFound();
          }
            var genres = await _context.Genres.Where(i => i.name.Contains(name)).ToListAsync();

            if (genres == null)
            {
                return NotFound();
            }

            return genres;
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenres([FromRoute] int id, Genres genres)
        {
            var found = await _context.Genres.FindAsync(id);

            if (found is null)
                return NotFound();

            found.name = genres.name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenresExists(id))
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

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult<Genres>> PostGenres(Genres genres)
        {
          if (_context.Genres == null)
          {
              return Problem("Entity set 'DataContext.Genres'  is null.");
          }
            _context.Genres.Add(genres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenres", new { id = genres.id }, genres);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenres(int id)
        {
            if (_context.Genres == null)
            {
                return NotFound();
            }
            var genres = await _context.Genres.FindAsync(id);
            if (genres == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenresExists(int id)
        {
            return (_context.Genres?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
