using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ITasks {
    Task<ActionResult<IEnumerable<Tasks>>> GetTasks();
    Task<ActionResult<Tasks>> GetTasksById(int id);
    Task<IActionResult> PutTasks(int id, Tasks Tasks);
    Task<ActionResult<Tasks>> PostTasks(Tasks Tasks);
    Task<IActionResult> DeleteTasks(int id);
}