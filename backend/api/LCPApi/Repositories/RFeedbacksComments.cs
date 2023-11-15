using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RFeedbacksComments : ControllerBase, IFeedbacksComments
{
    private readonly DBContext _context;

    public RFeedbacksComments(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<FeedbacksComments>>> GetFeedbacksComments()
    {
        if (_context.FeedbacksComments == null)
        {
            return NotFound();
        }
        return await _context.FeedbacksComments.ToListAsync();
    }

    public async Task<ActionResult<FeedbacksComments>> GetFeedbacksCommentsById(int id)
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

    public async Task<ActionResult<FeedbacksComments>> PostFeedbacksComments(FeedbacksComments feedbacksComments)
    {
        if (_context.FeedbacksComments == null)
        {
            return Problem("Entity set 'DBContext.FeedbacksComments'  is null.");
        }
        _context.FeedbacksComments.Add(feedbacksComments);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFeedbacksCommentsById", new { id = feedbacksComments.FeedbacksCommentsId }, feedbacksComments);
    }

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