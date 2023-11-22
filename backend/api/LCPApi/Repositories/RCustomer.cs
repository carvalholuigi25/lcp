using LCPApi.Context;
using LCPApi.Interfaces;
using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace LCPApi.Repositories;

public class RCustomer : ControllerBase, ICustomer
{
    private readonly DBContext _context;

    public RCustomer(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        return await _context.Customers.ToListAsync();
    }

    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        var Customer = await _context.Customers.FindAsync(id);

        if (Customer == null)
        {
            return NotFound();
        }

        return Customer;
    }

    public async Task<IActionResult> PutCustomer(int id, Customer Customer)
    {
        if (id != Customer.CustomerId)
        {
            return BadRequest();
        }

        if(!string.IsNullOrEmpty(Customer.CustomerPassword)) {
            Customer.CustomerPassword = BC.HashPassword(Customer.CustomerPassword);
        }

        if(!string.IsNullOrEmpty(Customer.CustomerPin)) {
            Customer.CustomerPin = BC.HashPassword(Customer.CustomerPin);
        }

        _context.Entry(Customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
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

    public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
    {        
        if (_context.Customers == null)
        {
            return Problem("Entity set 'DBContext.Customers'  is null.");
        }

        Customer.CustomerPassword = BC.HashPassword(Customer.CustomerPassword);
        Customer.CustomerPin = BC.HashPassword(Customer.CustomerPin);

        _context.Customers.Add(Customer);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCustomerById", new { id = Customer.CustomerId }, Customer);
    }

    public async Task<IActionResult> DeleteCustomer(int id)
    {
        if (_context.Customers == null)
        {
            return NotFound();
        }
        var Customer = await _context.Customers.FindAsync(id);
        if (Customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(Customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerExists(int id)
    {
        return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
    }
}