using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IProject {
    Task<ActionResult<IEnumerable<Project>>> GetProject();
    Task<ActionResult<Project>> GetProjectById(int id);
    Task<IActionResult> PutProject(int id, Project Project);
    Task<ActionResult<Project>> PostProject(Project Project);
    Task<IActionResult> DeleteProject(int id);
    Task<ActionResult<IEnumerable<ProjectPhase>>> GetProjectPhase();
    Task<ActionResult<ProjectPhase>> GetProjectPhaseById(int id);
    Task<IActionResult> PutProjectPhase(int id, ProjectPhase ProjectPhase);
    Task<ActionResult<ProjectPhase>> PostProjectPhase(ProjectPhase ProjectPhase);
    Task<IActionResult> DeleteProjectPhase(int id);
    Task<ActionResult<IEnumerable<ProjectTask>>> GetProjectTask();
    Task<ActionResult<ProjectTask>> GetProjectTaskById(int id);
    Task<IActionResult> PutProjectTask(int id, ProjectTask Tasks);
    Task<ActionResult<ProjectTask>> PostProjectTask(ProjectTask Tasks);
    Task<IActionResult> DeleteProjectTask(int id);
    Task<ActionResult<IEnumerable<ProjectTaskType>>> GetProjectTaskType();
    Task<ActionResult<ProjectTaskType>> GetProjectTaskTypeById(int id);
    Task<IActionResult> PutProjectTaskType(int id, ProjectTaskType ProjectTaskType);
    Task<ActionResult<ProjectTaskType>> PostProjectTaskType(ProjectTaskType ProjectTaskType);
    Task<IActionResult> DeleteProjectTaskType(int id);
}