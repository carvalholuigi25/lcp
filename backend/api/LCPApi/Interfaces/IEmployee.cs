using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IEmployee {
    Task<ActionResult<IEnumerable<Employee>>> GetEmployee();
    Task<ActionResult<Employee>> GetEmployeeById(int id);
    Task<IActionResult> PutEmployee(int id, Employee Employee);
    Task<ActionResult<Employee>> PostEmployee(Employee Employee);
    Task<IActionResult> DeleteEmployee(int id);
}