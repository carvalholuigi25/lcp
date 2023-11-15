using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IOrders {
    Task<ActionResult<IEnumerable<Orders>>> GetOrders();
    Task<ActionResult<Orders>> GetOrdersById(int id);
    Task<IActionResult> PutOrders(int id, Orders Orders);
    Task<ActionResult<Orders>> PostOrders(Orders Orders);
    Task<IActionResult> DeleteOrders(int id);
}