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
    public class BookAuthorsController : ControllerBase
    {
        private readonly DataContext _context;

        public BookAuthorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookAuthors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors()
        {
            if (_context.BookAuthors == null)
            {
                return NotFound();
            }
            return await _context.BookAuthors.Include(a => a.authid).ToListAsync();
        }

        // GET: api/BookAuthors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<BookAuthor>>> GetBookAuthor(int id)
        {
            if (_context.BookAuthors == null)
            {
                return NotFound();
            }
            var bookAuthor = await _context.BookAuthors.Where(i => i.id == id).Include(a => a.authid).ToListAsync();

            if (bookAuthor == null)
            {
                return NotFound();
            }

            return bookAuthor;
        }

        // POST: api/BookAuthors
        [HttpPost]
        public async Task<ActionResult<List<BookAuthor>>> PostBookAuthor(HIDEpostbkau request)
        {
            if (_context.BookAuthors == null)
            {
                return Problem("Entity set 'DataContext.BookAuthors'  is null.");
            }

            var author = await _context.Authors.FindAsync(request.postauthor);
            if (author == null)
                return NotFound();

            BookAuthor newba = new BookAuthor
            {
                authid = author,
                // нет возможности добавить BookID
            };

            _context.BookAuthors.Add(newba);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/BookAuthors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAuthor(int id)
        {
            if (_context.BookAuthors == null)
            {
                return NotFound();
            }
            var bookAuthor = await _context.BookAuthors.FindAsync(id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            _context.BookAuthors.Remove(bookAuthor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookAuthorExists(int id)
        {
            return (_context.BookAuthors?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
