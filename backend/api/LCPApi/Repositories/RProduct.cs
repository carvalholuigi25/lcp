using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RProduct : ControllerBase, IProduct
{
    private readonly DBContext _context;

    public RProduct(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        return await _context.Products.ToListAsync();
    }

    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        var Product = await _context.Products.FindAsync(id);

        if (Product == null)
        {
            return NotFound();
        }

        return Product;
    }

    public async Task<IActionResult> PutProduct(int id, Product Product)
    {
        if (id != Product.ProductId)
        {
            return BadRequest();
        }

        _context.Entry(Product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
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

    public async Task<ActionResult<Product>> PostProduct(Product Product)
    {
        if (_context.Products == null)
        {
            return Problem("Entity set 'DBContext.Products'  is null.");
        }
        _context.Products.Add(Product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProductById", new { id = Product.ProductId }, Product);
    }

    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        var Product = await _context.Products.FindAsync(id);
        if (Product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(Product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    public async Task<ActionResult<IEnumerable<ProductProject>>> GetProductProject()
    {
        if (_context.ProductsProjects == null)
        {
            return NotFound();
        }
        return await _context.ProductsProjects.ToListAsync();
    }

    public async Task<ActionResult<ProductProject>> GetProductProjectById(int id)
    {
        if (_context.ProductsProjects == null)
        {
            return NotFound();
        }
        var ProductProject = await _context.ProductsProjects.FindAsync(id);

        if (ProductProject == null)
        {
            return NotFound();
        }

        return ProductProject;
    }

    public async Task<IActionResult> PutProductProject(int id, ProductProject ProductProject)
    {
        if (id != ProductProject.ProductId)
        {
            return BadRequest();
        }

        _context.Entry(ProductProject).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductProjectExists(id))
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

    public async Task<ActionResult<ProductProject>> PostProductProject(ProductProject ProductProject)
    {
        if (_context.ProductsProjects == null)
        {
            return Problem("Entity set 'DBContext.ProductsProjects'  is null.");
        }
        _context.ProductsProjects.Add(ProductProject);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProductProjectById", new { id = ProductProject.ProductId }, ProductProject);
    }

    public async Task<IActionResult> DeleteProductProject(int id)
    {
        if (_context.ProductsProjects == null)
        {
            return NotFound();
        }
        var ProductProject = await _context.ProductsProjects.FindAsync(id);
        if (ProductProject == null)
        {
            return NotFound();
        }

        _context.ProductsProjects.Remove(ProductProject);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductProjectExists(int id)
    {
        return (_context.ProductsProjects?.Any(e => e.ProductId == id)).GetValueOrDefault();
    }

    public async Task<ActionResult<IEnumerable<ProductSubscription>>> GetProductSubscription()
    {
        if (_context.ProductsSubscriptions == null)
        {
            return NotFound();
        }
        return await _context.ProductsSubscriptions.ToListAsync();
    }

    public async Task<ActionResult<ProductSubscription>> GetProductSubscriptionById(int id)
    {
        if (_context.ProductsSubscriptions == null)
        {
            return NotFound();
        }
        var ProductSubscription = await _context.ProductsSubscriptions.FindAsync(id);

        if (ProductSubscription == null)
        {
            return NotFound();
        }

        return ProductSubscription;
    }

    public async Task<IActionResult> PutProductSubscription(int id, ProductSubscription ProductSubscription)
    {
        if (id != ProductSubscription.ProductId)
        {
            return BadRequest();
        }

        _context.Entry(ProductSubscription).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductSubscriptionExists(id))
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

    public async Task<ActionResult<ProductSubscription>> PostProductSubscription(ProductSubscription ProductSubscription)
    {
        if (_context.ProductsSubscriptions == null)
        {
            return Problem("Entity set 'DBContext.ProductsSubscriptions'  is null.");
        }
        _context.ProductsSubscriptions.Add(ProductSubscription);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProductSubscriptionById", new { id = ProductSubscription.ProductId }, ProductSubscription);
    }

    public async Task<IActionResult> DeleteProductSubscription(int id)
    {
        if (_context.ProductsSubscriptions == null)
        {
            return NotFound();
        }
        var ProductSubscription = await _context.ProductsSubscriptions.FindAsync(id);
        if (ProductSubscription == null)
        {
            return NotFound();
        }

        _context.ProductsSubscriptions.Remove(ProductSubscription);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductSubscriptionExists(int id)
    {
        return (_context.ProductsSubscriptions?.Any(e => e.ProductId == id)).GetValueOrDefault();
    }

    private bool ProductExists(int id)
    {
        return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
    }
}