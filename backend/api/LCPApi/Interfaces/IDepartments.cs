using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IDepartments {
    Task<ActionResult<IEnumerable<Departments>>> GetDepartments();
    Task<ActionResult<Departments>> GetDepartmentsById(int id);
    Task<IActionResult> PutDepartments(int id, Departments Departments);
    Task<ActionResult<Departments>> PostDepartments(Departments Departments);
    Task<IActionResult> DeleteDepartments(int id);
}