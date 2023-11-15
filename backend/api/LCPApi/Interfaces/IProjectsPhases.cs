using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IProjectsPhases {
    Task<ActionResult<IEnumerable<ProjectsPhases>>> GetProjectsPhases();
    Task<ActionResult<ProjectsPhases>> GetProjectsPhasesById(int id);
    Task<IActionResult> PutProjectsPhases(int id, ProjectsPhases ProjectsPhases);
    Task<ActionResult<ProjectsPhases>> PostProjectsPhases(ProjectsPhases ProjectsPhases);
    Task<IActionResult> DeleteProjectsPhases(int id);
}