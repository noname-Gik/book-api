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
    public class ConnectionsController : ControllerBase
    {
        private readonly DataContext _context;

        public ConnectionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Connections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Connections>>> GetConnections()
        {
          if (_context.Connections == null)
          {
              return NotFound();
          }
            return await _context.Connections.Include(g => g.Genre).Include(b => b.Book).Include(a => a.Author).ToListAsync();
        }

        // GET: api/Connections/5
        [HttpGet("{name}")]
        public async Task<ActionResult<List<Connections>>> GetConnections(string name)
        {
          if (_context.Connections == null)
          {
              return NotFound();
          }
            var connections = await _context.Connections.Where(i => i.Book.name == name).Include(g => g.Genre).Include(b => b.Book).Include(a => a.Author).ToListAsync();

            if (connections == null)
            {
                return NotFound();
            }

            return connections;
        }


        // POST: api/Connections
        [HttpPost]
        public async Task<ActionResult<List<Connections>>> PostConnections(HideConnection request)
        {
            if (_context.Connections == null)
            {
                return Problem("Entity set 'DataContext.Connections'  is null.");
            }

            var book = await _context.Books.FindAsync(request.bookid);
            if (book == null)
                return NotFound();

            var genre = await _context.Genres.FindAsync(request.genreid);
            if (genre == null)
                return NotFound();

            var author = await _context.Authors.FindAsync(request.authorid);
            if (author == null)
                return NotFound();

            Connections newConnections = new Connections
            {
                Book = book,
                Genre = genre,
                Author = author
            };

            _context.Connections.Add(newConnections);
            await _context.SaveChangesAsync();

            return await _context.Connections.Include(g => g.Genre).Include(b => b.Book).Include(a => a.Author).ToListAsync();
        }

        // DELETE: api/Connections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConnections(int id)
        {
            if (_context.Connections == null)
            {
                return NotFound();
            }
            var connections = await _context.Connections.FindAsync(id);
            if (connections == null)
            {
                return NotFound();
            }

            _context.Connections.Remove(connections);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConnectionsExists(int id)
        {
            return (_context.Connections?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
