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
    public class FeedbacksController : ControllerBase
    {
        private readonly DBContext _context;

        public FeedbacksController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedbacks>>> GetFeedbacks()
        {
          if (_context.Feedbacks == null)
          {
              return NotFound();
          }
            return await _context.Feedbacks.ToListAsync();
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedbacks>> GetFeedbacks(int id)
        {
          if (_context.Feedbacks == null)
          {
              return NotFound();
          }
            var feedbacks = await _context.Feedbacks.FindAsync(id);

            if (feedbacks == null)
            {
                return NotFound();
            }

            return feedbacks;
        }

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbacks(int id, Feedbacks feedbacks)
        {
            if (id != feedbacks.FeedbacksId)
            {
                return BadRequest();
            }

            _context.Entry(feedbacks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbacksExists(id))
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

        // POST: api/Feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feedbacks>> PostFeedbacks(Feedbacks feedbacks)
        {
          if (_context.Feedbacks == null)
          {
              return Problem("Entity set 'DBContext.Feedbacks'  is null.");
          }
            _context.Feedbacks.Add(feedbacks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbacks", new { id = feedbacks.FeedbacksId }, feedbacks);
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbacks(int id)
        {
            if (_context.Feedbacks == null)
            {
                return NotFound();
            }
            var feedbacks = await _context.Feedbacks.FindAsync(id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            _context.Feedbacks.Remove(feedbacks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbacksExists(int id)
        {
            return (_context.Feedbacks?.Any(e => e.FeedbacksId == id)).GetValueOrDefault();
        }
    }
}
