using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class ROrder : ControllerBase, IOrder
{
    private readonly DBContext _context;

    public ROrder(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }
        return await _context.Orders.ToListAsync();
    }

    public async Task<ActionResult<Order>> GetOrderById(int id)
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }
        var Order = await _context.Orders.FindAsync(id);

        if (Order == null)
        {
            return NotFound();
        }

        return Order;
    }

    public async Task<IActionResult> PutOrder(int id, Order Order)
    {
        if (id != Order.OrderId)
        {
            return BadRequest();
        }

        _context.Entry(Order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
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

    public async Task<ActionResult<Order>> PostOrder(Order Order)
    {
        if (_context.Orders == null)
        {
            return Problem("Entity set 'DBContext.Orders'  is null.");
        }
        _context.Orders.Add(Order);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOrderById", new { id = Order.OrderId }, Order);
    }

    public async Task<IActionResult> DeleteOrder(int id)
    {
        if (_context.Orders == null)
        {
            return NotFound();
        }
        var Order = await _context.Orders.FindAsync(id);
        if (Order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(Order);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    public async Task<ActionResult<IEnumerable<OrderCustomer>>> GetOrderCustomer()
    {
        if (_context.OrdersCustomers == null)
        {
            return NotFound();
        }
        return await _context.OrdersCustomers.ToListAsync();
    }

    public async Task<ActionResult<OrderCustomer>> GetOrderCustomerById(int id)
    {
        if (_context.OrdersCustomers == null)
        {
            return NotFound();
        }
        var OrderCustomer = await _context.OrdersCustomers.FindAsync(id);

        if (OrderCustomer == null)
        {
            return NotFound();
        }

        return OrderCustomer;
    }

    public async Task<IActionResult> PutOrderCustomer(int id, OrderCustomer OrderCustomer)
    {
        if (id != OrderCustomer.OrderId)
        {
            return BadRequest();
        }

        _context.Entry(OrderCustomer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderCustomerExists(id))
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

    public async Task<ActionResult<OrderCustomer>> PostOrderCustomer(OrderCustomer OrderCustomer)
    {
        if (_context.OrdersCustomers == null)
        {
            return Problem("Entity set 'DBContext.OrdersCustomers'  is null.");
        }
        _context.OrdersCustomers.Add(OrderCustomer);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOrderCustomerById", new { id = OrderCustomer.OrderId }, OrderCustomer);
    }

    public async Task<IActionResult> DeleteOrderCustomer(int id)
    {
        if (_context.OrdersCustomers == null)
        {
            return NotFound();
        }
        var OrderCustomer = await _context.OrdersCustomers.FindAsync(id);
        if (OrderCustomer == null)
        {
            return NotFound();
        }

        _context.OrdersCustomers.Remove(OrderCustomer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrderCustomerExists(int id)
    {
        return (_context.OrdersCustomers?.Any(e => e.OrderId == id)).GetValueOrDefault();
    }

    private bool OrderExists(int id)
    {
        return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
    }
}