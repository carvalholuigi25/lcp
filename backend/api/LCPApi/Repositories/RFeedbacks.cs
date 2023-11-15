using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RFeedbacks : ControllerBase, IFeedbacks
{
    private readonly DBContext _context;

    public RFeedbacks(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Feedbacks>>> GetFeedbacks()
    {
        if (_context.Feedbacks == null)
        {
            return NotFound();
        }
        return await _context.Feedbacks.ToListAsync();
    }

    public async Task<ActionResult<Feedbacks>> GetFeedbacksById(int id)
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

    public async Task<ActionResult<Feedbacks>> PostFeedbacks(Feedbacks feedbacks)
    {
        if (_context.Feedbacks == null)
        {
            return Problem("Entity set 'DBContext.Feedbacks'  is null.");
        }
        _context.Feedbacks.Add(feedbacks);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFeedbacksById", new { id = feedbacks.FeedbacksId }, feedbacks);
    }

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