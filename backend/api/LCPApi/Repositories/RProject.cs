using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Repositories;

public class RProject : ControllerBase, IProject
{
    private readonly DBContext _context;

    public RProject(DBContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Project>>> GetProject()
    {
        if (_context.Projects == null)
        {
            return NotFound();
        }
        return await _context.Projects.ToListAsync();
    }

    public async Task<ActionResult<Project>> GetProjectById(int id)
    {
        if (_context.Projects == null)
        {
            return NotFound();
        }
        var Project = await _context.Projects.FindAsync(id);

        if (Project == null)
        {
            return NotFound();
        }

        return Project;
    }

    public async Task<IActionResult> PutProject(int id, Project Project)
    {
        if (id != Project.ProjectId)
        {
            return BadRequest();
        }

        _context.Entry(Project).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectExists(id))
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

    public async Task<ActionResult<Project>> PostProject(Project Project)
    {
        if (_context.Projects == null)
        {
            return Problem("Entity set 'DBContext.Projects'  is null.");
        }
        _context.Projects.Add(Project);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProjectById", new { id = Project.ProjectId }, Project);
    }

    public async Task<IActionResult> DeleteProject(int id)
    {
        if (_context.Projects == null)
        {
            return NotFound();
        }
        var Project = await _context.Projects.FindAsync(id);
        if (Project == null)
        {
            return NotFound();
        }

        _context.Projects.Remove(Project);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    public async Task<ActionResult<IEnumerable<ProjectPhase>>> GetProjectPhase()
    {
        if (_context.ProjectsPhases == null)
        {
            return NotFound();
        }
        return await _context.ProjectsPhases.ToListAsync();
    }


    public async Task<ActionResult<ProjectPhase>> GetProjectPhaseById(int id)
    {
        if (_context.ProjectsPhases == null)
        {
            return NotFound();
        }
        var ProjectPhase = await _context.ProjectsPhases.FindAsync(id);

        if (ProjectPhase == null)
        {
            return NotFound();
        }

        return ProjectPhase;
    }

    public async Task<IActionResult> PutProjectPhase(int id, ProjectPhase ProjectPhase)
    {
        if (id != ProjectPhase.ProjectPhaseId)
        {
            return BadRequest();
        }

        _context.Entry(ProjectPhase).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectPhaseExists(id))
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

    public async Task<ActionResult<ProjectPhase>> PostProjectPhase(ProjectPhase ProjectPhase)
    {
        if (_context.ProjectsPhases == null)
        {
            return Problem("Entity set 'DBContext.ProjectsPhases'  is null.");
        }
        _context.ProjectsPhases.Add(ProjectPhase);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProjectPhaseById", new { id = ProjectPhase.ProjectPhaseId }, ProjectPhase);
    }

    public async Task<IActionResult> DeleteProjectPhase(int id)
    {
        if (_context.ProjectsPhases == null)
        {
            return NotFound();
        }
        var ProjectPhase = await _context.ProjectsPhases.FindAsync(id);
        if (ProjectPhase == null)
        {
            return NotFound();
        }

        _context.ProjectsPhases.Remove(ProjectPhase);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProjectPhaseExists(int id)
    {
        return (_context.ProjectsPhases?.Any(e => e.ProjectPhaseId == id)).GetValueOrDefault();
    }

    public async Task<ActionResult<IEnumerable<ProjectTask>>> GetProjectTask()
    {
        if (_context.ProjectTasks == null)
        {
            return NotFound();
        }
        return await _context.ProjectTasks.ToListAsync();
    }

    public async Task<ActionResult<ProjectTask>> GetProjectTaskById(int id)
    {
        if (_context.ProjectTasks == null)
        {
            return NotFound();
        }
        var ProjectTask = await _context.ProjectTasks.FindAsync(id);

        if (ProjectTask == null)
        {
            return NotFound();
        }

        return ProjectTask;
    }

    public async Task<IActionResult> PutProjectTask(int id, ProjectTask ProjectTask)
    {
        if (id != ProjectTask.ProjectTaskId)
        {
            return BadRequest();
        }

        _context.Entry(ProjectTask).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectTaskExists(id))
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

    public async Task<ActionResult<ProjectTask>> PostProjectTask(ProjectTask ProjectTask)
    {
        if (_context.ProjectTasks == null)
        {
            return Problem("Entity set 'DBContext.ProjectTask'  is null.");
        }
        _context.ProjectTasks.Add(ProjectTask);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProjectTaskById", new { id = ProjectTask.ProjectTaskId }, ProjectTask);
    }

    public async Task<IActionResult> DeleteProjectTask(int id)
    {
        if (_context.ProjectTasks == null)
        {
            return NotFound();
        }
        var ProjectTask = await _context.ProjectTasks.FindAsync(id);
        if (ProjectTask == null)
        {
            return NotFound();
        }

        _context.ProjectTasks.Remove(ProjectTask);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProjectTaskExists(int id)
    {
        return (_context.ProjectTasks?.Any(e => e.ProjectTaskId == id)).GetValueOrDefault();
    }

    public async Task<ActionResult<IEnumerable<ProjectTaskType>>> GetProjectTaskType()
    {
        if (_context.ProjectTasksTypes == null)
        {
            return NotFound();
        }
        return await _context.ProjectTasksTypes.ToListAsync();
    }

    public async Task<ActionResult<ProjectTaskType>> GetProjectTaskTypeById(int id)
    {
        if (_context.ProjectTasksTypes == null)
        {
            return NotFound();
        }
        var ProjectTaskType = await _context.ProjectTasksTypes.FindAsync(id);

        if (ProjectTaskType == null)
        {
            return NotFound();
        }

        return ProjectTaskType;
    }

    public async Task<IActionResult> PutProjectTaskType(int id, ProjectTaskType ProjectTaskType)
    {
        if (id != ProjectTaskType.ProjectTaskTypeId)
        {
            return BadRequest();
        }

        _context.Entry(ProjectTaskType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectTaskTypeExists(id))
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

    public async Task<ActionResult<ProjectTaskType>> PostProjectTaskType(ProjectTaskType ProjectTaskType)
    {
        if (_context.ProjectTasksTypes == null)
        {
            return Problem("Entity set 'DBContext.ProjectTaskType'  is null.");
        }
        _context.ProjectTasksTypes.Add(ProjectTaskType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProjectTaskTypeById", new { id = ProjectTaskType.ProjectTaskTypeId }, ProjectTaskType);
    }

    public async Task<IActionResult> DeleteProjectTaskType(int id)
    {
        if (_context.ProjectTasksTypes == null)
        {
            return NotFound();
        }
        var ProjectTaskType = await _context.ProjectTasksTypes.FindAsync(id);
        if (ProjectTaskType == null)
        {
            return NotFound();
        }

        _context.ProjectTasksTypes.Remove(ProjectTaskType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProjectTaskTypeExists(int id)
    {
        return (_context.ProjectTasksTypes?.Any(e => e.ProjectTaskTypeId == id)).GetValueOrDefault();
    }

    private bool ProjectExists(int id)
    {
        return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
    }
}