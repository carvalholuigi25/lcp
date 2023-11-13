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
    public class FeedbacksCommentsController : ControllerBase
    {
        private readonly DBContext _context;

        public FeedbacksCommentsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/FeedbacksComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbacksComments>>> GetFeedbacksComments()
        {
          if (_context.FeedbacksComments == null)
          {
              return NotFound();
          }
            return await _context.FeedbacksComments.ToListAsync();
        }

        // GET: api/FeedbacksComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbacksComments>> GetFeedbacksComments(int id)
        {
          if (_context.FeedbacksComments == null)
          {
              return NotFound();
          }
            var feedbacksComments = await _context.FeedbacksComments.FindAsync(id);

            if (feedbacksComments == null)
            {
                return NotFound();
            }

            return feedbacksComments;
        }

        // PUT: api/FeedbacksComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbacksComments(int id, FeedbacksComments feedbacksComments)
        {
            if (id != feedbacksComments.FeedbacksCommentsId)
            {
                return BadRequest();
            }

            _context.Entry(feedbacksComments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbacksCommentsExists(id))
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

        // POST: api/FeedbacksComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbacksComments>> PostFeedbacksComments(FeedbacksComments feedbacksComments)
        {
          if (_context.FeedbacksComments == null)
          {
              return Problem("Entity set 'DBContext.FeedbacksComments'  is null.");
          }
            _context.FeedbacksComments.Add(feedbacksComments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbacksComments", new { id = feedbacksComments.FeedbacksCommentsId }, feedbacksComments);
        }

        // DELETE: api/FeedbacksComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbacksComments(int id)
        {
            if (_context.FeedbacksComments == null)
            {
                return NotFound();
            }
            var feedbacksComments = await _context.FeedbacksComments.FindAsync(id);
            if (feedbacksComments == null)
            {
                return NotFound();
            }

            _context.FeedbacksComments.Remove(feedbacksComments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbacksCommentsExists(int id)
        {
            return (_context.FeedbacksComments?.Any(e => e.FeedbacksCommentsId == id)).GetValueOrDefault();
        }
    }
}
