using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsPhasesController : ControllerBase
    {
        private readonly IProjectsPhases _projectsphasesRepo;

        public ProjectsPhasesController(IProjectsPhases projectsphasesRepo)
        {
            _projectsphasesRepo = projectsphasesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsPhases>>> GetProjectsPhases()
        {
           return await _projectsphasesRepo.GetProjectsPhases();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectsPhases>> GetProjectsPhasesById(int id)
        {
           return await _projectsphasesRepo.GetProjectsPhasesById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectsPhases(int id, ProjectsPhases ProjectsPhases)
        {
            return await _projectsphasesRepo.PutProjectsPhases(id, ProjectsPhases);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectsPhases>> PostProjectsPhases(ProjectsPhases ProjectsPhases)
        {
            return await _projectsphasesRepo.PostProjectsPhases(ProjectsPhases);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectsPhases(int id)
        {
            return await _projectsphasesRepo.DeleteProjectsPhases(id);
        }
    }
}
