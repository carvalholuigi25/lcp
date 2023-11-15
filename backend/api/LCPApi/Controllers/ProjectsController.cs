using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjects _projectsRepo;

        public ProjectsController(IProjects projectsRepo)
        {
            _projectsRepo = projectsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projects>>> GetProjects()
        {
           return await _projectsRepo.GetProjects();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projects>> GetProjectsById(int id)
        {
           return await _projectsRepo.GetProjectsById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjects(int id, Projects Projects)
        {
            return await _projectsRepo.PutProjects(id, Projects);
        }

        [HttpPost]
        public async Task<ActionResult<Projects>> PostProjects(Projects Projects)
        {
            return await _projectsRepo.PostProjects(Projects);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjects(int id)
        {
            return await _projectsRepo.DeleteProjects(id);
        }
    }
}
