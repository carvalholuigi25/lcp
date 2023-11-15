using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptions _subscriptionsRepo;

        public SubscriptionsController(ISubscriptions subscriptionsRepo)
        {
            _subscriptionsRepo = subscriptionsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscriptions>>> GetSubscriptions()
        {
           return await _subscriptionsRepo.GetSubscriptions();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriptions>> GetSubscriptionsById(int id)
        {
           return await _subscriptionsRepo.GetSubscriptionsById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptions(int id, Subscriptions Subscriptions)
        {
            return await _subscriptionsRepo.PutSubscriptions(id, Subscriptions);
        }

        [HttpPost]
        public async Task<ActionResult<Subscriptions>> PostSubscriptions(Subscriptions Subscriptions)
        {
            return await _subscriptionsRepo.PostSubscriptions(Subscriptions);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptions(int id)
        {
            return await _subscriptionsRepo.DeleteSubscriptions(id);
        }
    }
}
