using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersCustomersController : ControllerBase
    {
        private readonly IOrdersCustomers _orderscustomersRepo;

        public OrdersCustomersController(IOrdersCustomers orderscustomersRepo)
        {
            _orderscustomersRepo = orderscustomersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersCustomers>>> GetOrdersCustomers()
        {
           return await _orderscustomersRepo.GetOrdersCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersCustomers>> GetOrdersCustomersById(int id)
        {
           return await _orderscustomersRepo.GetOrdersCustomersById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersCustomers(int id, OrdersCustomers OrdersCustomers)
        {
            return await _orderscustomersRepo.PutOrdersCustomers(id, OrdersCustomers);
        }

        [HttpPost]
        public async Task<ActionResult<OrdersCustomers>> PostOrdersCustomers(OrdersCustomers OrdersCustomers)
        {
            return await _orderscustomersRepo.PostOrdersCustomers(OrdersCustomers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersCustomers(int id)
        {
            return await _orderscustomersRepo.DeleteOrdersCustomers(id);
        }
    }
}
