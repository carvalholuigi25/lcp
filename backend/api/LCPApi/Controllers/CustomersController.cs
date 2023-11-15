using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Repositories;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomers _customersRepo;

        public CustomersController(ICustomers customersRepo)
        {
            _customersRepo = customersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
           return await _customersRepo.GetCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomersById(int id)
        {
           return await _customersRepo.GetCustomersById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, Customers customers)
        {
            return await _customersRepo.PutCustomers(id, customers);
        }

        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
        {
            return await _customersRepo.PostCustomers(customers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            return await _customersRepo.DeleteCustomers(id);
        }
    }
}
