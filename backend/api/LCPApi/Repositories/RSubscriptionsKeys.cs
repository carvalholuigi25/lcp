using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RSubscriptionsKeys : ControllerBase, ISubscriptionsKeys
{
    private readonly DBContext _context;

    public RSubscriptionsKeys(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<SubscriptionsKeys>>> GetSubscriptionsKeys()
    {
        if (_context.SubscriptionsKeys == null)
        {
            return NotFound();
        }
        return await _context.SubscriptionsKeys.ToListAsync();
    }

    public async Task<ActionResult<SubscriptionsKeys>> GetSubscriptionsKeysById(int id)
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

    public async Task<ActionResult<SubscriptionsKeys>> PostSubscriptionsKeys(SubscriptionsKeys subscriptionsKeys)
    {
        if (_context.SubscriptionsKeys == null)
        {
            return Problem("Entity set 'DBContext.SubscriptionsKeys'  is null.");
        }
        _context.SubscriptionsKeys.Add(subscriptionsKeys);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSubscriptionsKeysById", new { id = subscriptionsKeys.SubscriptionsKeysId }, subscriptionsKeys);
    }

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