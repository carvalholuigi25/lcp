using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RProductsProjects : ControllerBase, IProductsProjects
{
    private readonly DBContext _context;

    public RProductsProjects(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<ProductsProjects>>> GetProductsProjects()
    {
        if (_context.ProductsProjects == null)
        {
            return NotFound();
        }
        return await _context.ProductsProjects.ToListAsync();
    }

    public async Task<ActionResult<ProductsProjects>> GetProductsProjectsById(int id)
    {
        if (_context.ProductsProjects == null)
        {
            return NotFound();
        }
        var productsProjects = await _context.ProductsProjects.FindAsync(id);

        if (productsProjects == null)
        {
            return NotFound();
        }

        return productsProjects;
    }

    public async Task<IActionResult> PutProductsProjects(int id, ProductsProjects productsProjects)
    {
        if (id != productsProjects.ProductsId)
        {
            return BadRequest();
        }

        _context.Entry(productsProjects).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductsProjectsExists(id))
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

    public async Task<ActionResult<ProductsProjects>> PostProductsProjects(ProductsProjects productsProjects)
    {
        if (_context.ProductsProjects == null)
        {
            return Problem("Entity set 'DBContext.ProductsProjects'  is null.");
        }
        _context.ProductsProjects.Add(productsProjects);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProductsProjectsById", new { id = productsProjects.ProductsId }, productsProjects);
    }

    public async Task<IActionResult> DeleteProductsProjects(int id)
    {
        if (_context.ProductsProjects == null)
        {
            return NotFound();
        }
        var productsProjects = await _context.ProductsProjects.FindAsync(id);
        if (productsProjects == null)
        {
            return NotFound();
        }

        _context.ProductsProjects.Remove(productsProjects);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductsProjectsExists(int id)
    {
        return (_context.ProductsProjects?.Any(e => e.ProductsId == id)).GetValueOrDefault();
    }
}