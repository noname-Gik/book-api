using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookAPI.Data;
using bookAPI.Models.Front;

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
            return await _context.Books.Include(g => g.BookGenre).Include(a => a.BookAuthor).ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks(string name)
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            var books = await _context.Books.Where(i => i.name.Contains(name)).Include(g => g.BookGenre).Include(a => a.BookAuthor).ToListAsync();

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        // PUT: api/Books/5
        [HttpPut]
        public async Task<ActionResult<Books>> PutBooks(Books books)
        {
            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Books>> PostBooks(Books books)
        {
          if (_context.Books == null)
          {
              return Problem("Entity set 'DataContext.Books'  is null.");
          }
            _context.Books.Add(books);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = books.id }, books);
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
