using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RTasks : ControllerBase, ITasks
{
    private readonly DBContext _context;

    public RTasks(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
    {
        if (_context.Tasks == null)
        {
            return NotFound();
        }
        return await _context.Tasks.ToListAsync();
    }

    public async Task<ActionResult<Tasks>> GetTasksById(int id)
    {
        if (_context.Tasks == null)
        {
            return NotFound();
        }
        var tasks = await _context.Tasks.FindAsync(id);

        if (tasks == null)
        {
            return NotFound();
        }

        return tasks;
    }

    public async Task<IActionResult> PutTasks(int id, Tasks tasks)
    {
        if (id != tasks.TasksId)
        {
            return BadRequest();
        }

        _context.Entry(tasks).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TasksExists(id))
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

    public async Task<ActionResult<Tasks>> PostTasks(Tasks tasks)
    {
        if (_context.Tasks == null)
        {
            return Problem("Entity set 'DBContext.Tasks'  is null.");
        }
        _context.Tasks.Add(tasks);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTasksById", new { id = tasks.TasksId }, tasks);
    }

    public async Task<IActionResult> DeleteTasks(int id)
    {
        if (_context.Tasks == null)
        {
            return NotFound();
        }
        var tasks = await _context.Tasks.FindAsync(id);
        if (tasks == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(tasks);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TasksExists(int id)
    {
        return (_context.Tasks?.Any(e => e.TasksId == id)).GetValueOrDefault();
    }
}