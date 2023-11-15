using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RCategories : ControllerBase, ICategories
{
    private readonly DBContext _context;

    public RCategories(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }
        return await _context.Categories.ToListAsync();
    }

    public async Task<ActionResult<Categories>> GetCategoriesById(int id)
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }
        var categories = await _context.Categories.FindAsync(id);

        if (categories == null)
        {
            return NotFound();
        }

        return categories;
    }

    public async Task<IActionResult> PutCategories(int id, Categories categories)
    {
        if (id != categories.CategoriesId)
        {
            return BadRequest();
        }

        _context.Entry(categories).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriesExists(id))
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

    public async Task<ActionResult<Categories>> PostCategories(Categories categories)
    {
        if (_context.Categories == null)
        {
            return Problem("Entity set 'DBContext.Categories'  is null.");
        }
        _context.Categories.Add(categories);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategoriesById", new { id = categories.CategoriesId }, categories);
    }

    public async Task<IActionResult> DeleteCategories(int id)
    {
        if (_context.Categories == null)
        {
            return NotFound();
        }
        var categories = await _context.Categories.FindAsync(id);
        if (categories == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(categories);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoriesExists(int id)
    {
        return (_context.Categories?.Any(e => e.CategoriesId == id)).GetValueOrDefault();
    }
}