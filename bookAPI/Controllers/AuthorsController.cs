using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookAPI.Data;
using bookAPI.Models;

namespace bookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authors>>> GetAuthors()
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{fullname}")]
        public async Task<ActionResult<List<Authors>>> GetAuthors(string fullname)
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            var authors = await _context.Authors.Where(i => i.fullname.Contains(fullname)).ToListAsync();

            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthors([FromRoute] int id, Authors authors)
        {
            var found = await _context.Authors.FindAsync(id);

            if (found is null)
                return NotFound();

            found.fullname = authors.fullname;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Authors>> PostAuthors(Authors authors)
        {
          if (_context.Authors == null)
          {
              return Problem("Entity set 'DataContext.Authors'  is null.");
          }
            _context.Authors.Add(authors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthors", new { id = authors.id }, authors);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthors(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var authors = await _context.Authors.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(authors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorsExists(int id)
        {
            return (_context.Authors?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
