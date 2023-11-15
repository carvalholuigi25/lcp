using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartments _departmentsRepo;

        public DepartmentsController(IDepartments departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departments>>> GetDepartments()
        {
           return await _departmentsRepo.GetDepartments();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departments>> GetDepartmentsById(int id)
        {
           return await _departmentsRepo.GetDepartmentsById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartments(int id, Departments Departments)
        {
            return await _departmentsRepo.PutDepartments(id, Departments);
        }

        [HttpPost]
        public async Task<ActionResult<Departments>> PostDepartments(Departments Departments)
        {
            return await _departmentsRepo.PostDepartments(Departments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartments(int id)
        {
            return await _departmentsRepo.DeleteDepartments(id);
        }
    }
}