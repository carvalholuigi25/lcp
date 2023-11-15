using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ICustomers {
    Task<ActionResult<IEnumerable<Customers>>> GetCustomers();
    Task<ActionResult<Customers>> GetCustomersById(int id);
    Task<IActionResult> PutCustomers(int id, Customers customers);
    Task<ActionResult<Customers>> PostCustomers(Customers customers);
    Task<IActionResult> DeleteCustomers(int id);
}