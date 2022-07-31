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
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;

        public BooksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            return await _context.Books.Include(g => g.BookGenre).ThenInclude(g => g.genid).Include(a => a.BookAuthor).ThenInclude(a => a.authid).ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{name}")]
        public async Task<ActionResult<List<Books>>> GetBooks(string name)
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            var books = await _context.Books.Where(i => i.name == name).Include(g => g.BookGenre).ThenInclude(g => g.genid).Include(a => a.BookAuthor).ThenInclude(a => a.authid).ToListAsync();

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<List<Books>>> PostBooks(HIDEpostbook request)
        {
          if (_context.Books == null)
          {
              return Problem("Entity set 'DataContext.Books'  is null.");
          }

            var genre = await _context.Genres.FindAsync(request.postgenreID);
            if (genre == null)
                return NotFound();

            var author = await _context.Authors.FindAsync(request.postathorID);
            if (author == null)
                return NotFound();

            var newbook = new Books
            {
                name = request.BookName,
            };

            // получить последний ID в Books
            // var lastbook = _context.Books.OrderByDescending(a => a.id).First();

            var newgenre = new BookGenre
            {
                genid = genre,
                // нет возможности обратиться к BookID
            };

            var newauthor = new BookAuthor
            {
                authid = author,
                // нет возможности обратиться к BookID
            };
            _context.Books.Add(newbook);
            _context.BookGenres.Add(newgenre);
            _context.BookAuthors.Add(newauthor);
            await _context.SaveChangesAsync();

            return await _context.Books.Include(g => g.BookGenre).ThenInclude(g => g.genid).Include(a => a.BookAuthor).ThenInclude(a => a.authid).ToListAsync();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.Books.Remove(books);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooksExists(int id)
        {
            return (_context.Books?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
