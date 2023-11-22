using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "StaffOnly")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepo;

        public CustomerController(ICustomer customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
           return await _customerRepo.GetCustomer();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
           return await _customerRepo.GetCustomerById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            return await _customerRepo.PutCustomer(id, customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            return await _customerRepo.PostCustomer(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            return await _customerRepo.DeleteCustomer(id);
        }
    }
}
