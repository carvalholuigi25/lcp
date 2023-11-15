using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _ordersRepo;

        public OrdersController(IOrders ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
           return await _ordersRepo.GetOrders();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrdersById(int id)
        {
           return await _ordersRepo.GetOrdersById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders Orders)
        {
            return await _ordersRepo.PutOrders(id, Orders);
        }

        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders Orders)
        {
            return await _ordersRepo.PostOrders(Orders);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            return await _ordersRepo.DeleteOrders(id);
        }
    }
}
