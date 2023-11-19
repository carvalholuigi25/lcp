using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RSubscription : ControllerBase, ISubscription
{
    private readonly DBContext _context;

    public RSubscription(DBContext context)
    {
        _context = context;
    }


    public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscription()
    {
        if (_context.Subscriptions == null)
        {
            return NotFound();
        }
        return await _context.Subscriptions.ToListAsync();
    }


    public async Task<ActionResult<Subscription>> GetSubscriptionById(int id)
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

    public async Task<IActionResult> PutSubscription(int id, Subscription subscriptions)
    {
        if (id != subscriptions.SubscriptionId)
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
            if (!SubscriptionExists(id))
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

    public async Task<ActionResult<Subscription>> PostSubscription(Subscription subscriptions)
    {
        if (_context.Subscriptions == null)
        {
            return Problem("Entity set 'DBContext.Subscriptions'  is null.");
        }
        _context.Subscriptions.Add(subscriptions);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSubscriptionsById", new { id = subscriptions.SubscriptionId }, subscriptions);
    }

    public async Task<IActionResult> DeleteSubscription(int id)
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

    public async Task<ActionResult<IEnumerable<SubscriptionKey>>> GetSubscriptionKey()
    {
        if (_context.SubscriptionsKeys == null)
        {
            return NotFound();
        }
        return await _context.SubscriptionsKeys.ToListAsync();
    }

    public async Task<ActionResult<SubscriptionKey>> GetSubscriptionKeyById(int id)
    {
        if (_context.SubscriptionsKeys == null)
        {
            return NotFound();
        }
        var subscriptionKey = await _context.SubscriptionsKeys.FindAsync(id);

        if (subscriptionKey == null)
        {
            return NotFound();
        }

        return subscriptionKey;
    }

    public async Task<IActionResult> PutSubscriptionKey(int id, SubscriptionKey subscriptionKey)
    {
        if (id != subscriptionKey.SubscriptionKeyId)
        {
            return BadRequest();
        }

        _context.Entry(subscriptionKey).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SubscriptionKeyExists(id))
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

    public async Task<ActionResult<SubscriptionKey>> PostSubscriptionKey(SubscriptionKey subscriptionKey)
    {
        if (_context.SubscriptionsKeys == null)
        {
            return Problem("Entity set 'DBContext.SubscriptionsKeys'  is null.");
        }
        _context.SubscriptionsKeys.Add(subscriptionKey);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSubscriptionKeyById", new { id = subscriptionKey.SubscriptionKeyId }, subscriptionKey);
    }

    public async Task<IActionResult> DeleteSubscriptionKey(int id)
    {
        if (_context.SubscriptionsKeys == null)
        {
            return NotFound();
        }
        var subscriptionKey = await _context.SubscriptionsKeys.FindAsync(id);
        if (subscriptionKey == null)
        {
            return NotFound();
        }

        _context.SubscriptionsKeys.Remove(subscriptionKey);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SubscriptionKeyExists(int id)
    {
        return (_context.SubscriptionsKeys?.Any(e => e.SubscriptionKeyId == id)).GetValueOrDefault();
    }

    private bool SubscriptionExists(int id)
    {
        return (_context.Subscriptions?.Any(e => e.SubscriptionId == id)).GetValueOrDefault();
    }
}