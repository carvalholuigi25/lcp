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
    public class TasksTypesController : ControllerBase
    {
        private readonly DBContext _context;

        public TasksTypesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TasksTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasksTypes>>> GetTasksTypes()
        {
          if (_context.TasksTypes == null)
          {
              return NotFound();
          }
            return await _context.TasksTypes.ToListAsync();
        }

        // GET: api/TasksTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TasksTypes>> GetTasksTypes(int id)
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

        // PUT: api/TasksTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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

        // POST: api/TasksTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TasksTypes>> PostTasksTypes(TasksTypes tasksTypes)
        {
          if (_context.TasksTypes == null)
          {
              return Problem("Entity set 'DBContext.TasksTypes'  is null.");
          }
            _context.TasksTypes.Add(tasksTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasksTypes", new { id = tasksTypes.TasksTypesId }, tasksTypes);
        }

        // DELETE: api/TasksTypes/5
        [HttpDelete("{id}")]
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
}
