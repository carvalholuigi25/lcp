using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RTasksTypes : ControllerBase, ITasksTypes
{
    private readonly DBContext _context;

    public RTasksTypes(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<TasksTypes>>> GetTasksTypes()
    {
        if (_context.TasksTypes == null)
        {
            return NotFound();
        }
        return await _context.TasksTypes.ToListAsync();
    }

    public async Task<ActionResult<TasksTypes>> GetTasksTypesById(int id)
    {
        if (_context.TasksTypes == null)
        {
            return NotFound();
        }
        var tasksTypes = await _context.TasksTypes.FindAsync(id);

        if (tasksTypes == null)
        {
            return NotFound();
        }

        return tasksTypes;
    }

    public async Task<IActionResult> PutTasksTypes(int id, TasksTypes tasksTypes)
    {
        if (id != tasksTypes.TasksTypesId)
        {
            return BadRequest();
        }

        _context.Entry(tasksTypes).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TasksTypesExists(id))
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

    public async Task<ActionResult<TasksTypes>> PostTasksTypes(TasksTypes tasksTypes)
    {
        if (_context.TasksTypes == null)
        {
            return Problem("Entity set 'DBContext.TasksTypes'  is null.");
        }
        _context.TasksTypes.Add(tasksTypes);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTasksTypesById", new { id = tasksTypes.TasksTypesId }, tasksTypes);
    }

    public async Task<IActionResult> DeleteTasksTypes(int id)
    {
        if (_context.TasksTypes == null)
        {
            return NotFound();
        }
        var tasksTypes = await _context.TasksTypes.FindAsync(id);
        if (tasksTypes == null)
        {
            return NotFound();
        }

        _context.TasksTypes.Remove(tasksTypes);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TasksTypesExists(int id)
    {
        return (_context.TasksTypes?.Any(e => e.TasksTypesId == id)).GetValueOrDefault();
    }
}
