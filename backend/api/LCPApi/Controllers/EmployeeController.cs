using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "StaffOnly")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeRepo;

        public EmployeeController(IEmployee employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
           return await _employeeRepo.GetEmployee();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
           return await _employeeRepo.GetEmployeeById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee Employee)
        {
            return await _employeeRepo.PutEmployee(id, Employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee Employee)
        {
            return await _employeeRepo.PostEmployee(Employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return await _employeeRepo.DeleteEmployee(id);
        }
    }
}