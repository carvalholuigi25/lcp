using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployees _employeesRepo;

        public EmployeesController(IEmployees employeesRepo)
        {
            _employeesRepo = employeesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
           return await _employeesRepo.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployeesById(int id)
        {
           return await _employeesRepo.GetEmployeesById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees(int id, Employees Employees)
        {
            return await _employeesRepo.PutEmployees(id, Employees);
        }

        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees(Employees Employees)
        {
            return await _employeesRepo.PostEmployees(Employees);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            return await _employeesRepo.DeleteEmployees(id);
        }
    }
}