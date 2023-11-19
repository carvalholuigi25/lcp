using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RCategory : ControllerBase, ICategory
{
    private readonly DBContext _context;

    public RCategory(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }
        return await _context.Categories.ToListAsync();
    }

    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }
        var Category = await _context.Categories.FindAsync(id);

        if (Category == null)
        {
            return NotFound();
        }

        return Category;
    }

    public async Task<IActionResult> PutCategory(int id, Category Category)
    {
        if (id != Category.CategoryId)
        {
            return BadRequest();
        }

        _context.Entry(Category).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
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

    public async Task<ActionResult<Category>> PostCategory(Category Category)
    {
        if (_context.Categories == null)
        {
            return Problem("Entity set 'DBContext.Category'  is null.");
        }
        _context.Categories.Add(Category);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategoryById", new { id = Category.CategoryId }, Category);
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }
        var Category = await _context.Categories.FindAsync(id);
        if (Category == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(Category);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoryExists(int id)
    {
        return (_context.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
    }
}