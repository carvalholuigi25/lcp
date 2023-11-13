using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsKeysController : ControllerBase
    {
        private readonly DBContext _context;

        public SubscriptionsKeysController(DBContext context)
        {
            _context = context;
        }

        // GET: api/SubscriptionsKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionsKeys>>> GetSubscriptionsKeys()
        {
          if (_context.SubscriptionsKeys == null)
          {
              return NotFound();
          }
            return await _context.SubscriptionsKeys.ToListAsync();
        }

        // GET: api/SubscriptionsKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionsKeys>> GetSubscriptionsKeys(int id)
        {
          if (_context.SubscriptionsKeys == null)
          {
              return NotFound();
          }
            var subscriptionsKeys = await _context.SubscriptionsKeys.FindAsync(id);

            if (subscriptionsKeys == null)
            {
                return NotFound();
            }

            return subscriptionsKeys;
        }

        // PUT: api/SubscriptionsKeys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionsKeys(int id, SubscriptionsKeys subscriptionsKeys)
        {
            if (id != subscriptionsKeys.SubscriptionsKeysId)
            {
                return BadRequest();
            }

            _context.Entry(subscriptionsKeys).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionsKeysExists(id))
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

        // POST: api/SubscriptionsKeys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriptionsKeys>> PostSubscriptionsKeys(SubscriptionsKeys subscriptionsKeys)
        {
          if (_context.SubscriptionsKeys == null)
          {
              return Problem("Entity set 'DBContext.SubscriptionsKeys'  is null.");
          }
            _context.SubscriptionsKeys.Add(subscriptionsKeys);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionsKeys", new { id = subscriptionsKeys.SubscriptionsKeysId }, subscriptionsKeys);
        }

        // DELETE: api/SubscriptionsKeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionsKeys(int id)
        {
            if (_context.SubscriptionsKeys == null)
            {
                return NotFound();
            }
            var subscriptionsKeys = await _context.SubscriptionsKeys.FindAsync(id);
            if (subscriptionsKeys == null)
            {
                return NotFound();
            }

            _context.SubscriptionsKeys.Remove(subscriptionsKeys);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionsKeysExists(int id)
        {
            return (_context.SubscriptionsKeys?.Any(e => e.SubscriptionsKeysId == id)).GetValueOrDefault();
        }
    }
}
