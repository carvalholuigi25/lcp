using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class ROrders : ControllerBase, IOrders
{
    private readonly DBContext _context;

    public ROrders(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }
        return await _context.Orders.ToListAsync();
    }

    public async Task<ActionResult<Orders>> GetOrdersById(int id)
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }
        var orders = await _context.Orders.FindAsync(id);

        if (orders == null)
        {
            return NotFound();
        }

        return orders;
    }

    public async Task<IActionResult> PutOrders(int id, Orders orders)
    {
        if (id != orders.OrdersId)
        {
            return BadRequest();
        }

        _context.Entry(orders).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrdersExists(id))
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

    public async Task<ActionResult<Orders>> PostOrders(Orders orders)
    {
        if (_context.Orders == null)
        {
            return Problem("Entity set 'DBContext.Orders'  is null.");
        }
        _context.Orders.Add(orders);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOrdersById", new { id = orders.OrdersId }, orders);
    }

    public async Task<IActionResult> DeleteOrders(int id)
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }
        var orders = await _context.Orders.FindAsync(id);
        if (orders == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(orders);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrdersExists(int id)
    {
        return (_context.Orders?.Any(e => e.OrdersId == id)).GetValueOrDefault();
    }
}