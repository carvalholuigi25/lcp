using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RFeedback : ControllerBase, IFeedback
{
    private readonly DBContext _context;

    public RFeedback(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
    {
        if (_context.Feedbacks == null)
        {
            return NotFound();
        }
        return await _context.Feedbacks.ToListAsync();
    }

    public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
    {
        if (_context.Feedbacks == null)
        {
            return NotFound();
        }
        var Feedback = await _context.Feedbacks.FindAsync(id);

        if (Feedback == null)
        {
            return NotFound();
        }

        return Feedback;
    }

    public async Task<IActionResult> PutFeedback(int id, Feedback Feedback)
    {
        if (id != Feedback.FeedbackId)
        {
            return BadRequest();
        }

        _context.Entry(Feedback).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FeedbackExists(id))
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

    public async Task<ActionResult<Feedback>> PostFeedback(Feedback Feedback)
    {
        if (_context.Feedbacks == null)
        {
            return Problem("Entity set 'DBContext.Feedbacks'  is null.");
        }
        _context.Feedbacks.Add(Feedback);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFeedbackById", new { id = Feedback.FeedbackId }, Feedback);
    }

    public async Task<IActionResult> DeleteFeedback(int id)
    {
        if (_context.Feedbacks == null)
        {
            return NotFound();
        }
        var Feedback = await _context.Feedbacks.FindAsync(id);
        if (Feedback == null)
        {
            return NotFound();
        }

        _context.Feedbacks.Remove(Feedback);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    public async Task<ActionResult<IEnumerable<FeedbackComment>>> GetFeedbackComment()
    {
        if (_context.FeedbacksComments == null)
        {
            return NotFound();
        }
        return await _context.FeedbacksComments.ToListAsync();
    }

    public async Task<ActionResult<FeedbackComment>> GetFeedbackCommentById(int id)
    {
        if (_context.FeedbacksComments == null)
        {
            return NotFound();
        }
        var FeedbackComment = await _context.FeedbacksComments.FindAsync(id);

        if (FeedbackComment == null)
        {
            return NotFound();
        }

        return FeedbackComment;
    }

    public async Task<IActionResult> PutFeedbackComment(int id, FeedbackComment FeedbackComment)
    {
        if (id != FeedbackComment.FeedbackCommentId)
        {
            return BadRequest();
        }

        _context.Entry(FeedbackComment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FeedbackCommentExists(id))
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

    public async Task<ActionResult<FeedbackComment>> PostFeedbackComment(FeedbackComment FeedbackComment)
    {
        if (_context.FeedbacksComments == null)
        {
            return Problem("Entity set 'DBContext.FeedbacksComments'  is null.");
        }
        _context.FeedbacksComments.Add(FeedbackComment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFeedbackCommentById", new { id = FeedbackComment.FeedbackCommentId }, FeedbackComment);
    }

    public async Task<IActionResult> DeleteFeedbackComment(int id)
    {
        if (_context.FeedbacksComments == null)
        {
            return NotFound();
        }
        var FeedbackComment = await _context.FeedbacksComments.FindAsync(id);
        if (FeedbackComment == null)
        {
            return NotFound();
        }

        _context.FeedbacksComments.Remove(FeedbackComment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FeedbackCommentExists(int id)
    {
        return (_context.FeedbacksComments?.Any(e => e.FeedbackCommentId == id)).GetValueOrDefault();
    }

    private bool FeedbackExists(int id)
    {
        return (_context.Feedbacks?.Any(e => e.FeedbackId == id)).GetValueOrDefault();
    }
}