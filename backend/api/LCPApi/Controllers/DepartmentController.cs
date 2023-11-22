using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "StaffOnly")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentRepo;

        public DepartmentController(IDepartment departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
           return await _departmentRepo.GetDepartment();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
           return await _departmentRepo.GetDepartmentById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department Department)
        {
            return await _departmentRepo.PutDepartment(id, Department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department Department)
        {
            return await _departmentRepo.PostDepartment(Department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return await _departmentRepo.DeleteDepartment(id);
        }
    }
}