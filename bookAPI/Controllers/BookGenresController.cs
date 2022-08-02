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
    public class BookGenresController : ControllerBase
    {
        private readonly DataContext _context;

        public BookGenresController(DataContext context)
        {
            _context = context;
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
    }
}
