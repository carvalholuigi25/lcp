using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RProjects : ControllerBase, IProjects
{
    private readonly DBContext _context;

    public RProjects(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Projects>>> GetProjects()
    {
        if (_context.Projects == null)
        {
            return NotFound();
        }
        return await _context.Projects.ToListAsync();
    }

    public async Task<ActionResult<Projects>> GetProjectsById(int id)
    {
        if (_context.Projects == null)
        {
            return NotFound();
        }
        var projects = await _context.Projects.FindAsync(id);

        if (projects == null)
        {
            return NotFound();
        }

        return projects;
    }

    public async Task<IActionResult> PutProjects(int id, Projects projects)
    {
        if (id != projects.ProjectsId)
        {
            return BadRequest();
        }

        _context.Entry(projects).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectsExists(id))
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

    public async Task<ActionResult<Projects>> PostProjects(Projects projects)
    {
        if (_context.Projects == null)
        {
            return Problem("Entity set 'DBContext.Projects'  is null.");
        }
        _context.Projects.Add(projects);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProjectsById", new { id = projects.ProjectsId }, projects);
    }

    public async Task<IActionResult> DeleteProjects(int id)
    {
        if (_context.Projects == null)
        {
            return NotFound();
        }
        var projects = await _context.Projects.FindAsync(id);
        if (projects == null)
        {
            return NotFound();
        }

        _context.Projects.Remove(projects);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProjectsExists(int id)
    {
        return (_context.Projects?.Any(e => e.ProjectsId == id)).GetValueOrDefault();
    }
}