using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zooflix.Data;
using Zooflix.Models;

namespace Zooflix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarsController : ControllerBase
    {
        private readonly ZooflixContext _context;

        public StarsController(ZooflixContext context)
        {
            _context = context;
        }

        // GET: api/Stars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Star>>> GetStar()
        {
          if (_context.Star == null)
          {
              return NotFound();
          }
            return await _context.Star.ToListAsync();
        }

        // GET: api/Stars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Star>> GetStar(int id)
        {
          if (_context.Star == null)
          {
              return NotFound();
          }
            var star = await _context.Star.FindAsync(id);

            if (star == null)
            {
                return NotFound();
            }

            return star;
        }

        // PUT: api/Stars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStar(int id, Star star)
        {
            if (id != star.Id)
            {
                return BadRequest();
            }

            _context.Entry(star).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarExists(id))
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

        // POST: api/Stars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("AllowAll")]
        [HttpPost]
        public async Task<ActionResult<Star>> PostStar(Star star)
        {
          if (_context.Star == null)
          {
              return Problem("Entity set 'ZooflixContext.Star'  is null.");
          }
            _context.Star.Add(star);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStar", new { id = star.Id }, star);
        }

        // DELETE: api/Stars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStar(int id)
        {
            if (_context.Star == null)
            {
                return NotFound();
            }
            var star = await _context.Star.FindAsync(id);
            if (star == null)
            {
                return NotFound();
            }

            _context.Star.Remove(star);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StarExists(int id)
        {
            return (_context.Star?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
