using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RSubscriptions : ControllerBase, ISubscriptions
{
    private readonly DBContext _context;

    public RSubscriptions(DBContext context)
    {
        _context = context;
    }


    public async Task<ActionResult<IEnumerable<Subscriptions>>> GetSubscriptions()
    {
        if (_context.Subscriptions == null)
        {
            return NotFound();
        }
        return await _context.Subscriptions.ToListAsync();
    }


    public async Task<ActionResult<Subscriptions>> GetSubscriptionsById(int id)
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

    public async Task<ActionResult<Subscriptions>> PostSubscriptions(Subscriptions subscriptions)
    {
        if (_context.Subscriptions == null)
        {
            return Problem("Entity set 'DBContext.Subscriptions'  is null.");
        }
        _context.Subscriptions.Add(subscriptions);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSubscriptionsById", new { id = subscriptions.SubscriptionsId }, subscriptions);
    }

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