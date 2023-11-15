using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IProjects {
    Task<ActionResult<IEnumerable<Projects>>> GetProjects();
    Task<ActionResult<Projects>> GetProjectsById(int id);
    Task<IActionResult> PutProjects(int id, Projects Projects);
    Task<ActionResult<Projects>> PostProjects(Projects Projects);
    Task<IActionResult> DeleteProjects(int id);
}