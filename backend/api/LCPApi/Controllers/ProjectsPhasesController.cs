using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LCPApi.Context;
using LCPApi.Models;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsPhasesController : ControllerBase
    {
        private readonly DBContext _context;

        public ProjectsPhasesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/ProjectsPhases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsPhases>>> GetProjectsPhases()
        {
          if (_context.ProjectsPhases == null)
          {
              return NotFound();
          }
            return await _context.ProjectsPhases.ToListAsync();
        }

        // GET: api/ProjectsPhases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectsPhases>> GetProjectsPhases(int id)
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

        // PUT: api/ProjectsPhases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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

        // POST: api/ProjectsPhases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectsPhases>> PostProjectsPhases(ProjectsPhases projectsPhases)
        {
          if (_context.ProjectsPhases == null)
          {
              return Problem("Entity set 'DBContext.ProjectsPhases'  is null.");
          }
            _context.ProjectsPhases.Add(projectsPhases);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectsPhases", new { id = projectsPhases.ProjectsPhasesId }, projectsPhases);
        }

        // DELETE: api/ProjectsPhases/5
        [HttpDelete("{id}")]
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
}
