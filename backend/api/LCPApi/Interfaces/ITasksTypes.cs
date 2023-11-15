using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ITasksTypes {
    Task<ActionResult<IEnumerable<TasksTypes>>> GetTasksTypes();
    Task<ActionResult<TasksTypes>> GetTasksTypesById(int id);
    Task<IActionResult> PutTasksTypes(int id, TasksTypes TasksTypes);
    Task<ActionResult<TasksTypes>> PostTasksTypes(TasksTypes TasksTypes);
    Task<IActionResult> DeleteTasksTypes(int id);
}