using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class REmployee : ControllerBase, IEmployee
{
    private readonly DBContext _context;

    public REmployee(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
    {
        if (_context.Employees == null)
        {
            return NotFound();
        }
        return await _context.Employees.ToListAsync();
    }

    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        if (_context.Employees == null)
        {
            return NotFound();
        }
        var Employee = await _context.Employees.FindAsync(id);

        if (Employee == null)
        {
            return NotFound();
        }

        return Employee;
    }

    public async Task<IActionResult> PutEmployee(int id, Employee Employee)
    {
        if (id != Employee.EmployeeId)
        {
            return BadRequest();
        }

        _context.Entry(Employee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(id))
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

    public async Task<ActionResult<Employee>> PostEmployee(Employee Employee)
    {
        if (_context.Employees == null)
        {
            return Problem("Entity set 'DBContext.Employees'  is null.");
        }
        _context.Employees.Add(Employee);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEmployeeById", new { id = Employee.EmployeeId }, Employee);
    }

    public async Task<IActionResult> DeleteEmployee(int id)
    {
        if (_context.Employees == null)
        {
            return NotFound();
        }
        var Employee = await _context.Employees.FindAsync(id);
        if (Employee == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(Employee);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmployeeExists(int id)
    {
        return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
    }
}