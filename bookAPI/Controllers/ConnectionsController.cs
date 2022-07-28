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
            return await _context.Connections.ToListAsync();
        }

        // GET: api/Connections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Connections>> GetConnections(int id)
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

            return connections;
        }

        // PUT: api/Connections/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConnections(int id, Connections connections)
        {
            if (id != connections.id)
            {
                return BadRequest();
            }

            _context.Entry(connections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionsExists(id))
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

        // POST: api/Connections

        [HttpPost]
        public async Task<ActionResult<Connections>> PostConnections(Connections connections)
        {
          if (_context.Connections == null)
          {
              return Problem("Entity set 'DataContext.Connections'  is null.");
          }
            _context.Connections.Add(connections);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConnections", new { id = connections.id }, connections);
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
