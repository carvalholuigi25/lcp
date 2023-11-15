using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IOrdersCustomers {
    Task<ActionResult<IEnumerable<OrdersCustomers>>> GetOrdersCustomers();
    Task<ActionResult<OrdersCustomers>> GetOrdersCustomersById(int id);
    Task<IActionResult> PutOrdersCustomers(int id, OrdersCustomers OrdersCustomers);
    Task<ActionResult<OrdersCustomers>> PostOrdersCustomers(OrdersCustomers OrdersCustomers);
    Task<IActionResult> DeleteOrdersCustomers(int id);
}