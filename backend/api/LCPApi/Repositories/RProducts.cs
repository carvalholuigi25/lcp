using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RProducts : ControllerBase, IProducts
{
    private readonly DBContext _context;

    public RProducts(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        return await _context.Products.ToListAsync();
    }

    public async Task<ActionResult<Products>> GetProductsById(int id)
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        var products = await _context.Products.FindAsync(id);

        if (products == null)
        {
            return NotFound();
        }

        return products;
    }

    public async Task<IActionResult> PutProducts(int id, Products products)
    {
        if (id != products.ProductsId)
        {
            return BadRequest();
        }

        _context.Entry(products).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductsExists(id))
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

    public async Task<ActionResult<Products>> PostProducts(Products products)
    {
        if (_context.Products == null)
        {
            return Problem("Entity set 'DBContext.Products'  is null.");
        }
        _context.Products.Add(products);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProductsById", new { id = products.ProductsId }, products);
    }

    public async Task<IActionResult> DeleteProducts(int id)
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        var products = await _context.Products.FindAsync(id);
        if (products == null)
        {
            return NotFound();
        }

        _context.Products.Remove(products);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductsExists(int id)
    {
        return (_context.Products?.Any(e => e.ProductsId == id)).GetValueOrDefault();
    }
}