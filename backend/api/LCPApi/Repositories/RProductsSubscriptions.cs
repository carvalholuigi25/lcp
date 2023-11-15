using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RProductsSubscriptions : ControllerBase, IProductsSubscriptions
{
    private readonly DBContext _context;

    public RProductsSubscriptions(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<ProductsSubscriptions>>> GetProductsSubscriptions()
    {
        if (_context.ProductsSubscriptions == null)
        {
            return NotFound();
        }
        return await _context.ProductsSubscriptions.ToListAsync();
    }

    public async Task<ActionResult<ProductsSubscriptions>> GetProductsSubscriptionsById(int id)
    {
        if (_context.ProductsSubscriptions == null)
        {
            return NotFound();
        }
        var productsSubscriptions = await _context.ProductsSubscriptions.FindAsync(id);

        if (productsSubscriptions == null)
        {
            return NotFound();
        }

        return productsSubscriptions;
    }

    public async Task<IActionResult> PutProductsSubscriptions(int id, ProductsSubscriptions productsSubscriptions)
    {
        if (id != productsSubscriptions.ProductsId)
        {
            return BadRequest();
        }

        _context.Entry(productsSubscriptions).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductsSubscriptionsExists(id))
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

    public async Task<ActionResult<ProductsSubscriptions>> PostProductsSubscriptions(ProductsSubscriptions productsSubscriptions)
    {
        if (_context.ProductsSubscriptions == null)
        {
            return Problem("Entity set 'DBContext.ProductsSubscriptions'  is null.");
        }
        _context.ProductsSubscriptions.Add(productsSubscriptions);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProductsSubscriptionsById", new { id = productsSubscriptions.ProductsId }, productsSubscriptions);
    }

    public async Task<IActionResult> DeleteProductsSubscriptions(int id)
    {
        if (_context.ProductsSubscriptions == null)
        {
            return NotFound();
        }
        var productsSubscriptions = await _context.ProductsSubscriptions.FindAsync(id);
        if (productsSubscriptions == null)
        {
            return NotFound();
        }

        _context.ProductsSubscriptions.Remove(productsSubscriptions);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductsSubscriptionsExists(int id)
    {
        return (_context.ProductsSubscriptions?.Any(e => e.ProductsId == id)).GetValueOrDefault();
    }
}