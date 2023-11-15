using LCPApi.Context;
using LCPApi.Interfaces;
using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LCPApi.Repositories;

public class RCustomers : ControllerBase, ICustomers
{
    private readonly DBContext _context;

    public RCustomers(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        return await _context.Customers.ToListAsync();
    }

    public async Task<ActionResult<Customers>> GetCustomersById(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        var customers = await _context.Customers.FindAsync(id);

        if (customers == null)
        {
            return NotFound();
        }

        return customers;
    }

    public async Task<IActionResult> PutCustomers(int id, Customers customers)
    {
        if (id != customers.CustomersId)
        {
            return BadRequest();
        }

        _context.Entry(customers).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomersExists(id))
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

    public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
    {
        if (_context.Customers == null)
        {
            return Problem("Entity set 'DBContext.Customers'  is null.");
        }
        _context.Customers.Add(customers);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCustomersById", new { id = customers.CustomersId }, customers);
    }

    public async Task<IActionResult> DeleteCustomers(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        var customers = await _context.Customers.FindAsync(id);
        if (customers == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customers);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomersExists(int id)
    {
        return (_context.Customers?.Any(e => e.CustomersId == id)).GetValueOrDefault();
    }
}