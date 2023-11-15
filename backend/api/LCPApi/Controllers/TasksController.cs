using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasks _tasksRepo;

        public TasksController(ITasks tasksRepo)
        {
            _tasksRepo = tasksRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
           return await _tasksRepo.GetTasks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasksById(int id)
        {
           return await _tasksRepo.GetTasksById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(int id, Tasks Tasks)
        {
            return await _tasksRepo.PutTasks(id, Tasks);
        }

        [HttpPost]
        public async Task<ActionResult<Tasks>> PostTasks(Tasks Tasks)
        {
            return await _tasksRepo.PostTasks(Tasks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            return await _tasksRepo.DeleteTasks(id);
        }
    }
}
