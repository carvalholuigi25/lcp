using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IDepartment {
    Task<ActionResult<IEnumerable<Department>>> GetDepartment();
    Task<ActionResult<Department>> GetDepartmentById(int id);
    Task<IActionResult> PutDepartment(int id, Department Department);
    Task<ActionResult<Department>> PostDepartment(Department Department);
    Task<IActionResult> DeleteDepartment(int id);
}