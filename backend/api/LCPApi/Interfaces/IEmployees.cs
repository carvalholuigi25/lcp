using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IEmployees {
    Task<ActionResult<IEnumerable<Employees>>> GetEmployees();
    Task<ActionResult<Employees>> GetEmployeesById(int id);
    Task<IActionResult> PutEmployees(int id, Employees Employees);
    Task<ActionResult<Employees>> PostEmployees(Employees Employees);
    Task<IActionResult> DeleteEmployees(int id);
}