using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProjectController : ControllerBase
    {
        private readonly IProject _projectRepo;

        public ProjectController(IProject projectRepo)
        {
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProject()
        {
           return await _projectRepo.GetProject();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
           return await _projectRepo.GetProjectById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project Project)
        {
            return await _projectRepo.PutProject(id, Project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project Project)
        {
            return await _projectRepo.PostProject(Project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            return await _projectRepo.DeleteProject(id);
        }

        [HttpGet("phase")]
        public async Task<ActionResult<IEnumerable<ProjectPhase>>> GetProjectPhase()
        {
           return await _projectRepo.GetProjectPhase();
        }

        [HttpGet("phase/{id}")]
        public async Task<ActionResult<ProjectPhase>> GetProjectPhaseById(int id)
        {
           return await _projectRepo.GetProjectPhaseById(id);
        }

        [HttpPut("phase/{id}")]
        public async Task<IActionResult> PutProjectPhase(int id, ProjectPhase ProjectPhase)
        {
            return await _projectRepo.PutProjectPhase(id, ProjectPhase);
        }

        [HttpPost("phase")]
        public async Task<ActionResult<ProjectPhase>> PostProjectPhase(ProjectPhase ProjectPhase)
        {
            return await _projectRepo.PostProjectPhase(ProjectPhase);
        }

        [HttpDelete("phase/{id}")]
        public async Task<IActionResult> DeleteProjectPhase(int id)
        {
            return await _projectRepo.DeleteProjectPhase(id);
        }

        [HttpGet("task")]
        public async Task<ActionResult<IEnumerable<ProjectTask>>> GetProjectTask()
        {
           return await _projectRepo.GetProjectTask();
        }

        [HttpGet("task/{id}")]
        public async Task<ActionResult<ProjectTask>> GetProjectTaskById(int id)
        {
           return await _projectRepo.GetProjectTaskById(id);
        }

        [HttpPut("task/{id}")]
        public async Task<IActionResult> PutProjectTask(int id, ProjectTask ProjectTask)
        {
            return await _projectRepo.PutProjectTask(id, ProjectTask);
        }

        [HttpPost("task")]
        public async Task<ActionResult<ProjectTask>> PostProjectTask(ProjectTask ProjectTask)
        {
            return await _projectRepo.PostProjectTask(ProjectTask);
        }

        [HttpDelete("task/{id}")]
        public async Task<IActionResult> DeleteProjectTask(int id)
        {
            return await _projectRepo.DeleteProjectTask(id);
        }

        [HttpGet("task/type")]
        public async Task<ActionResult<IEnumerable<ProjectTaskType>>> GetProjectTaskType()
        {
           return await _projectRepo.GetProjectTaskType();
        }

        [HttpGet("task/type/{id}")]
        public async Task<ActionResult<ProjectTaskType>> GetProjectTaskTypeById(int id)
        {
           return await _projectRepo.GetProjectTaskTypeById(id);
        }

        [HttpPut("task/type/{id}")]
        public async Task<IActionResult> PutProjectTaskType(int id, ProjectTaskType ProjectTaskType)
        {
            return await _projectRepo.PutProjectTaskType(id, ProjectTaskType);
        }

        [HttpPost("task/type")]
        public async Task<ActionResult<ProjectTaskType>> PostProjectTaskType(ProjectTaskType ProjectTaskType)
        {
            return await _projectRepo.PostProjectTaskType(ProjectTaskType);
        }

        [HttpDelete("task/type/{id}")]
        public async Task<IActionResult> DeleteProjectTaskType(int id)
        {
            return await _projectRepo.DeleteProjectTaskType(id);
        }
    }
}
