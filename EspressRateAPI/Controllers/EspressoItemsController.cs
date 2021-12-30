#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EspressRateAPI.Models;

namespace EspressRateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspressoItemsController : ControllerBase
    {
        private readonly EspressoContext _context;

        public EspressoItemsController(EspressoContext context)
        {
            _context = context;
        }

        // GET: api/EspressoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspressoItem>>> GetEspressoItems()
        {
            return await _context.EspressoItems.ToListAsync();
        }

        // GET: api/EspressoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspressoItem>> GetEspressoItem(long id)
        {
            var espressoItem = await _context.EspressoItems.FindAsync(id);

            if (espressoItem == null)
            {
                return NotFound();
            }

            return espressoItem;
        }

        // PUT: api/EspressoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspressoItem(long id, EspressoItem espressoItem)
        {
            if (id != espressoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(espressoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspressoItemExists(id))
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

        // POST: api/EspressoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EspressoItem>> PostEspressoItem(EspressoItem espressoItem)
        {
            _context.EspressoItems.Add(espressoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEspressoItem), new { id = espressoItem.Id }, espressoItem);
        }

        // DELETE: api/EspressoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspressoItem(long id)
        {
            var espressoItem = await _context.EspressoItems.FindAsync(id);
            if (espressoItem == null)
            {
                return NotFound();
            }

            _context.EspressoItems.Remove(espressoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspressoItemExists(long id)
        {
            return _context.EspressoItems.Any(e => e.Id == id);
        }
    }
}
