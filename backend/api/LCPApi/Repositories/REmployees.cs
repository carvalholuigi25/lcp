using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class REmployees : ControllerBase, IEmployees
{
    private readonly DBContext _context;

    public REmployees(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
    {
        if (_context.Employees == null)
        {
            return NotFound();
        }
        return await _context.Employees.ToListAsync();
    }

    public async Task<ActionResult<Employees>> GetEmployeesById(int id)
    {
        if (_context.Employees == null)
        {
            return NotFound();
        }
        var employees = await _context.Employees.FindAsync(id);

        if (employees == null)
        {
            return NotFound();
        }

        return employees;
    }

    public async Task<IActionResult> PutEmployees(int id, Employees employees)
    {
        if (id != employees.EmployeesId)
        {
            return BadRequest();
        }

        _context.Entry(employees).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeesExists(id))
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

    public async Task<ActionResult<Employees>> PostEmployees(Employees employees)
    {
        if (_context.Employees == null)
        {
            return Problem("Entity set 'DBContext.Employees'  is null.");
        }
        _context.Employees.Add(employees);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEmployeesById", new { id = employees.EmployeesId }, employees);
    }

    public async Task<IActionResult> DeleteEmployees(int id)
    {
        if (_context.Employees == null)
        {
            return NotFound();
        }
        var employees = await _context.Employees.FindAsync(id);
        if (employees == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employees);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmployeesExists(int id)
    {
        return (_context.Employees?.Any(e => e.EmployeesId == id)).GetValueOrDefault();
    }
}