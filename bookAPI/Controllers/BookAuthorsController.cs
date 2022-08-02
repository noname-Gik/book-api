using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookAPI.Data;
using bookAPI.Models.Back;

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
