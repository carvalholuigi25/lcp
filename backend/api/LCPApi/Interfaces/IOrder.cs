using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IOrder {
    Task<ActionResult<IEnumerable<Order>>> GetOrder();
    Task<ActionResult<Order>> GetOrderById(int id);
    Task<IActionResult> PutOrder(int id, Order Order);
    Task<ActionResult<Order>> PostOrder(Order Order);
    Task<IActionResult> DeleteOrder(int id);
    Task<ActionResult<IEnumerable<OrderCustomer>>> GetOrderCustomer();
    Task<ActionResult<OrderCustomer>> GetOrderCustomerById(int id);
    Task<IActionResult> PutOrderCustomer(int id, OrderCustomer OrderCustomer);
    Task<ActionResult<OrderCustomer>> PostOrderCustomer(OrderCustomer OrderCustomer);
    Task<IActionResult> DeleteOrderCustomer(int id);
}