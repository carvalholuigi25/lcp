using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RDepartments : ControllerBase, IDepartments
{
    private readonly DBContext _context;

    public RDepartments(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Departments>>> GetDepartments()
    {
        if (_context.Departments == null)
        {
            return NotFound();
        }
        return await _context.Departments.ToListAsync();
    }

    public async Task<ActionResult<Departments>> GetDepartmentsById(int id)
    {
        if (_context.Departments == null)
        {
            return NotFound();
        }
        var departments = await _context.Departments.FindAsync(id);

        if (departments == null)
        {
            return NotFound();
        }

        return departments;
    }

    public async Task<IActionResult> PutDepartments(int id, Departments departments)
    {
        if (id != departments.DepartmentsId)
        {
            return BadRequest();
        }

        _context.Entry(departments).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartmentsExists(id))
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

    public async Task<ActionResult<Departments>> PostDepartments(Departments departments)
    {
        if (_context.Departments == null)
        {
            return Problem("Entity set 'DBContext.Departments'  is null.");
        }
        _context.Departments.Add(departments);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDepartmentsById", new { id = departments.DepartmentsId }, departments);
    }

    public async Task<IActionResult> DeleteDepartments(int id)
    {
        if (_context.Departments == null)
        {
            return NotFound();
        }
        var departments = await _context.Departments.FindAsync(id);
        if (departments == null)
        {
            return NotFound();
        }

        _context.Departments.Remove(departments);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DepartmentsExists(int id)
    {
        return (_context.Departments?.Any(e => e.DepartmentsId == id)).GetValueOrDefault();
    }
}