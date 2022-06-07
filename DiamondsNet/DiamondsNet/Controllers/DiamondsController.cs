using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiamondsAPI.Models;

namespace DiamondsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiamondsController : ControllerBase
    {
        private readonly DiamondContext _context;

        public DiamondsController(DiamondContext context)
        {
            _context = context;
        }

        // GET: api/Diamonds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diamond>>> GetDiamonds()
        {
            return await _context.Diamonds.ToListAsync();
        }

        // GET: api/Diamonds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diamond>> GetDiamond(long id)
        {
            var diamond = await _context.Diamonds.FindAsync(id);

            if (diamond == null)
            {
                return NotFound();
            }

            return diamond;
        }

        // PUT: api/Diamonds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiamond(long id, Diamond diamond)
        {
            if (id != diamond.Id)
            {
                return BadRequest();
            }

            _context.Entry(diamond).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiamondExists(id))
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

        // POST: api/Diamonds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Diamond>> PostDiamond(Diamond diamond)
        {
            _context.Diamonds.Add(diamond);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiamond", new { id = diamond.Id }, diamond);
        }

        // DELETE: api/Diamonds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Diamond>> DeleteDiamond(long id)
        {
            var diamond = await _context.Diamonds.FindAsync(id);
            if (diamond == null)
            {
                return NotFound();
            }

            _context.Diamonds.Remove(diamond);
            await _context.SaveChangesAsync();

            return diamond;
        }

        private bool DiamondExists(long id)
        {
            return _context.Diamonds.Any(e => e.Id == id);
        }
    }
}
