using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RProjectsPhases : ControllerBase, IProjectsPhases
{
    private readonly DBContext _context;

    public RProjectsPhases(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<ProjectsPhases>>> GetProjectsPhases()
    {
        if (_context.ProjectsPhases == null)
        {
            return NotFound();
        }
        return await _context.ProjectsPhases.ToListAsync();
    }


    public async Task<ActionResult<ProjectsPhases>> GetProjectsPhasesById(int id)
    {
        if (_context.ProjectsPhases == null)
        {
            return NotFound();
        }
        var projectsPhases = await _context.ProjectsPhases.FindAsync(id);

        if (projectsPhases == null)
        {
            return NotFound();
        }

        return projectsPhases;
    }

    public async Task<IActionResult> PutProjectsPhases(int id, ProjectsPhases projectsPhases)
    {
        if (id != projectsPhases.ProjectsPhasesId)
        {
            return BadRequest();
        }

        _context.Entry(projectsPhases).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectsPhasesExists(id))
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

    public async Task<ActionResult<ProjectsPhases>> PostProjectsPhases(ProjectsPhases projectsPhases)
    {
        if (_context.ProjectsPhases == null)
        {
            return Problem("Entity set 'DBContext.ProjectsPhases'  is null.");
        }
        _context.ProjectsPhases.Add(projectsPhases);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProjectsPhasesById", new { id = projectsPhases.ProjectsPhasesId }, projectsPhases);
    }

    public async Task<IActionResult> DeleteProjectsPhases(int id)
    {
        if (_context.ProjectsPhases == null)
        {
            return NotFound();
        }
        var projectsPhases = await _context.ProjectsPhases.FindAsync(id);
        if (projectsPhases == null)
        {
            return NotFound();
        }

        _context.ProjectsPhases.Remove(projectsPhases);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProjectsPhasesExists(int id)
    {
        return (_context.ProjectsPhases?.Any(e => e.ProjectsPhasesId == id)).GetValueOrDefault();
    }
}