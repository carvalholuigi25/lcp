using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsKeysController : ControllerBase
    {
        private readonly ISubscriptionsKeys _subscriptionskeysRepo;

        public SubscriptionsKeysController(ISubscriptionsKeys subscriptionskeysRepo)
        {
            _subscriptionskeysRepo = subscriptionskeysRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionsKeys>>> GetSubscriptionsKeys()
        {
           return await _subscriptionskeysRepo.GetSubscriptionsKeys();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionsKeys>> GetSubscriptionsKeysById(int id)
        {
           return await _subscriptionskeysRepo.GetSubscriptionsKeysById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionsKeys(int id, SubscriptionsKeys SubscriptionsKeys)
        {
            return await _subscriptionskeysRepo.PutSubscriptionsKeys(id, SubscriptionsKeys);
        }

        [HttpPost]
        public async Task<ActionResult<SubscriptionsKeys>> PostSubscriptionsKeys(SubscriptionsKeys SubscriptionsKeys)
        {
            return await _subscriptionskeysRepo.PostSubscriptionsKeys(SubscriptionsKeys);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionsKeys(int id)
        {
            return await _subscriptionskeysRepo.DeleteSubscriptionsKeys(id);
        }
    }
}
