using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;
using LCPApi.Functions;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "StaffOnly")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscription _subscriptionRepo;

        public SubscriptionController(ISubscription subscriptionRepo)
        {
            _subscriptionRepo = subscriptionRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscription()
        {
           return await _subscriptionRepo.GetSubscription();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscriptionById(int id)
        {
           return await _subscriptionRepo.GetSubscriptionById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription(int id, Subscription Subscription)
        {
            return await _subscriptionRepo.PutSubscription(id, Subscription);
        }

        [HttpPost]
        public async Task<ActionResult<Subscription>> PostSubscription(Subscription Subscription)
        {
            return await _subscriptionRepo.PostSubscription(Subscription);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            return await _subscriptionRepo.DeleteSubscription(id);
        }

        [HttpGet("genpkey")]
        public async Task<ActionResult<IEnumerable<ProductKeyClass>>> GenerateProdKey()
        {
           return await ProductKeyFunctions.GetProductKey();
        }

        [HttpGet("key")]
        public async Task<ActionResult<IEnumerable<SubscriptionKey>>> GetSubscriptionKey()
        {
           return await _subscriptionRepo.GetSubscriptionKey();
        }

        [HttpGet("key/{id}")]
        public async Task<ActionResult<SubscriptionKey>> GetSubscriptionKeyById(int id)
        {
           return await _subscriptionRepo.GetSubscriptionKeyById(id);
        }

        [HttpPut("key/{id}")]
        public async Task<IActionResult> PutSubscriptionKey(int id, SubscriptionKey SubscriptionKey)
        {
            return await _subscriptionRepo.PutSubscriptionKey(id, SubscriptionKey);
        }

        [HttpPost("key")]
        public async Task<ActionResult<SubscriptionKey>> PostSubscriptionKey(SubscriptionKey SubscriptionKey)
        {
            return await _subscriptionRepo.PostSubscriptionKey(SubscriptionKey);
        }

        [HttpDelete("key/{id}")]
        public async Task<IActionResult> DeleteSubscriptionKey(int id)
        {
            return await _subscriptionRepo.DeleteSubscriptionKey(id);
        }
    }
}
