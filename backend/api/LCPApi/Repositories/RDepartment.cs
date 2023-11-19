using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RDepartment : ControllerBase, IDepartment
{
    private readonly DBContext _context;

    public RDepartment(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
    {
        if (_context.Departments == null)
        {
            return NotFound();
        }
        return await _context.Departments.ToListAsync();
    }

    public async Task<ActionResult<Department>> GetDepartmentById(int id)
    {
        if (_context.Departments == null)
        {
            return NotFound();
        }
        var Department = await _context.Departments.FindAsync(id);

        if (Department == null)
        {
            return NotFound();
        }

        return Department;
    }

    public async Task<IActionResult> PutDepartment(int id, Department Department)
    {
        if (id != Department.DepartmentId)
        {
            return BadRequest();
        }

        _context.Entry(Department).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartmentExists(id))
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

    public async Task<ActionResult<Department>> PostDepartment(Department Department)
    {
        if (_context.Departments == null)
        {
            return Problem("Entity set 'DBContext.Departments'  is null.");
        }
        _context.Departments.Add(Department);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDepartmentById", new { id = Department.DepartmentId }, Department);
    }

    public async Task<IActionResult> DeleteDepartment(int id)
    {
        if (_context.Departments == null)
        {
            return NotFound();
        }
        var Department = await _context.Departments.FindAsync(id);
        if (Department == null)
        {
            return NotFound();
        }

        _context.Departments.Remove(Department);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DepartmentExists(int id)
    {
        return (_context.Departments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
    }
}