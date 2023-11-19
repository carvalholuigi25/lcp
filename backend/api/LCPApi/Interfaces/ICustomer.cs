using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ICustomer {
    Task<ActionResult<IEnumerable<Customer>>> GetCustomer();
    Task<ActionResult<Customer>> GetCustomerById(int id);
    Task<IActionResult> PutCustomer(int id, Customer Customer);
    Task<ActionResult<Customer>> PostCustomer(Customer Customer);
    Task<IActionResult> DeleteCustomer(int id);
}