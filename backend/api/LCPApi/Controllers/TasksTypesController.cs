using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksTypesController : ControllerBase
    {
        private readonly ITasksTypes _taskstypesRepo;

        public TasksTypesController(ITasksTypes taskstypesRepo)
        {
            _taskstypesRepo = taskstypesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasksTypes>>> GetTasksTypes()
        {
           return await _taskstypesRepo.GetTasksTypes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TasksTypes>> GetTasksTypesById(int id)
        {
           return await _taskstypesRepo.GetTasksTypesById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasksTypes(int id, TasksTypes TasksTypes)
        {
            return await _taskstypesRepo.PutTasksTypes(id, TasksTypes);
        }

        [HttpPost]
        public async Task<ActionResult<TasksTypes>> PostTasksTypes(TasksTypes TasksTypes)
        {
            return await _taskstypesRepo.PostTasksTypes(TasksTypes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasksTypes(int id)
        {
            return await _taskstypesRepo.DeleteTasksTypes(id);
        }
    }
}
