using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class ROrdersCustomers : ControllerBase, IOrdersCustomers
{
    private readonly DBContext _context;

    public ROrdersCustomers(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<OrdersCustomers>>> GetOrdersCustomers()
    {
        if (_context.OrdersCustomers == null)
        {
            return NotFound();
        }
        return await _context.OrdersCustomers.ToListAsync();
    }

    public async Task<ActionResult<OrdersCustomers>> GetOrdersCustomersById(int id)
    {
        if (_context.OrdersCustomers == null)
        {
            return NotFound();
        }
        var ordersCustomers = await _context.OrdersCustomers.FindAsync(id);

        if (ordersCustomers == null)
        {
            return NotFound();
        }

        return ordersCustomers;
    }

    public async Task<IActionResult> PutOrdersCustomers(int id, OrdersCustomers ordersCustomers)
    {
        if (id != ordersCustomers.OrdersId)
        {
            return BadRequest();
        }

        _context.Entry(ordersCustomers).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrdersCustomersExists(id))
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

    public async Task<ActionResult<OrdersCustomers>> PostOrdersCustomers(OrdersCustomers ordersCustomers)
    {
        if (_context.OrdersCustomers == null)
        {
            return Problem("Entity set 'DBContext.OrdersCustomers'  is null.");
        }
        _context.OrdersCustomers.Add(ordersCustomers);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOrdersCustomersById", new { id = ordersCustomers.OrdersId }, ordersCustomers);
    }

    public async Task<IActionResult> DeleteOrdersCustomers(int id)
    {
        if (_context.OrdersCustomers == null)
        {
            return NotFound();
        }
        var ordersCustomers = await _context.OrdersCustomers.FindAsync(id);
        if (ordersCustomers == null)
        {
            return NotFound();
        }

        _context.OrdersCustomers.Remove(ordersCustomers);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrdersCustomersExists(int id)
    {
        return (_context.OrdersCustomers?.Any(e => e.OrdersId == id)).GetValueOrDefault();
    }
}