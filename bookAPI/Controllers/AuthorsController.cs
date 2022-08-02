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
        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> GetAuthors(int id)
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

            return authors;
        }

        // PUT: api/Authors/5
        [HttpPut]
        public async Task<IActionResult> PutAuthors([FromBody] Authors authors)
        {

            _context.Entry(authors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

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
