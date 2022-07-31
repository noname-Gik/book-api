using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookAPI.Data;
using bookAPI.Models;

namespace bookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookGenresController : ControllerBase
    {
        private readonly DataContext _context;

        public BookGenresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookGenre>>> GetBookGenres()
        {
          if (_context.BookGenres == null)
          {
              return NotFound();
          }
            return await _context.BookGenres.ToListAsync();
        }

        // GET: api/BookGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookGenre>> GetBookGenre(int id)
        {
          if (_context.BookGenres == null)
          {
              return NotFound();
          }
            var bookGenre = await _context.BookGenres.FindAsync(id);

            if (bookGenre == null)
            {
                return NotFound();
            }

            return bookGenre;
        }

        // POST: api/BookGenres
        [HttpPost]
        public async Task<ActionResult<BookGenre>> PostBookGenre(HIDEpostbkgn request)
        {
          if (_context.BookGenres == null)
          {
              return Problem("Entity set 'DataContext.BookGenres'  is null.");
          }

            var genre = await _context.Genres.FindAsync(request.postgenre);
            if (genre == null)
                return NotFound();

            BookGenre newbg = new BookGenre
            {
                genid = genre,
                // нет возможности добавить BookID
            };

            _context.BookGenres.Add(newbg);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/BookGenres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookGenre(int id)
        {
            if (_context.BookGenres == null)
            {
                return NotFound();
            }
            var bookGenre = await _context.BookGenres.FindAsync(id);
            if (bookGenre == null)
            {
                return NotFound();
            }

            _context.BookGenres.Remove(bookGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookGenreExists(int id)
        {
            return (_context.BookGenres?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
