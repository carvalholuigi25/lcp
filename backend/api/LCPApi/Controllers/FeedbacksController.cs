using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbacks _feedbacksRepo;

        public FeedbacksController(IFeedbacks feedbacksRepo)
        {
            _feedbacksRepo = feedbacksRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedbacks>>> GetFeedbacks()
        {
           return await _feedbacksRepo.GetFeedbacks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedbacks>> GetFeedbacksById(int id)
        {
           return await _feedbacksRepo.GetFeedbacksById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbacks(int id, Feedbacks Feedbacks)
        {
            return await _feedbacksRepo.PutFeedbacks(id, Feedbacks);
        }

        [HttpPost]
        public async Task<ActionResult<Feedbacks>> PostFeedbacks(Feedbacks Feedbacks)
        {
            return await _feedbacksRepo.PostFeedbacks(Feedbacks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbacks(int id)
        {
            return await _feedbacksRepo.DeleteFeedbacks(id);
        }
    }
}
