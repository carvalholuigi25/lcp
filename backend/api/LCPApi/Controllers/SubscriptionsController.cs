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
    public class SubscriptionsController : ControllerBase
    {
        private readonly DBContext _context;

        public SubscriptionsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Subscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscriptions>>> GetSubscriptions()
        {
          if (_context.Subscriptions == null)
          {
              return NotFound();
          }
            return await _context.Subscriptions.ToListAsync();
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriptions>> GetSubscriptions(int id)
        {
          if (_context.Subscriptions == null)
          {
              return NotFound();
          }
            var subscriptions = await _context.Subscriptions.FindAsync(id);

            if (subscriptions == null)
            {
                return NotFound();
            }

            return subscriptions;
        }

        // PUT: api/Subscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptions(int id, Subscriptions subscriptions)
        {
            if (id != subscriptions.SubscriptionsId)
            {
                return BadRequest();
            }

            _context.Entry(subscriptions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionsExists(id))
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

        // POST: api/Subscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscriptions>> PostSubscriptions(Subscriptions subscriptions)
        {
          if (_context.Subscriptions == null)
          {
              return Problem("Entity set 'DBContext.Subscriptions'  is null.");
          }
            _context.Subscriptions.Add(subscriptions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptions", new { id = subscriptions.SubscriptionsId }, subscriptions);
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptions(int id)
        {
            if (_context.Subscriptions == null)
            {
                return NotFound();
            }
            var subscriptions = await _context.Subscriptions.FindAsync(id);
            if (subscriptions == null)
            {
                return NotFound();
            }

            _context.Subscriptions.Remove(subscriptions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionsExists(int id)
        {
            return (_context.Subscriptions?.Any(e => e.SubscriptionsId == id)).GetValueOrDefault();
        }
    }
}
