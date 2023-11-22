using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderRepo;

        public OrderController(IOrder orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
           return await _orderRepo.GetOrder();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
           return await _orderRepo.GetOrderById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order Order)
        {
            return await _orderRepo.PutOrder(id, Order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order Order)
        {
            return await _orderRepo.PostOrder(Order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            return await _orderRepo.DeleteOrder(id);
        }

        [HttpGet("customer")]
        public async Task<ActionResult<IEnumerable<OrderCustomer>>> GetOrderCustomer()
        {
           return await _orderRepo.GetOrderCustomer();
        }

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<OrderCustomer>> GetOrderCustomerById(int id)
        {
           return await _orderRepo.GetOrderCustomerById(id);
        }

        [HttpPut("customer/{id}")]
        public async Task<IActionResult> PutOrderCustomer(int id, OrderCustomer OrderCustomer)
        {
            return await _orderRepo.PutOrderCustomer(id, OrderCustomer);
        }

        [HttpPost("customer")]
        public async Task<ActionResult<OrderCustomer>> PostOrderCustomer(OrderCustomer OrderCustomer)
        {
            return await _orderRepo.PostOrderCustomer(OrderCustomer);
        }

        [HttpDelete("customer/{id}")]
        public async Task<IActionResult> DeleteOrderCustomer(int id)
        {
            return await _orderRepo.DeleteOrderCustomer(id);
        }
    }
}
