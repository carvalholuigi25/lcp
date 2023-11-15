using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksCommentsController : ControllerBase
    {
        private readonly IFeedbacksComments _feedbackscommentsRepo;

        public FeedbacksCommentsController(IFeedbacksComments feedbackscommentsRepo)
        {
            _feedbackscommentsRepo = feedbackscommentsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbacksComments>>> GetFeedbacksComments()
        {
           return await _feedbackscommentsRepo.GetFeedbacksComments();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbacksComments>> GetFeedbacksCommentsById(int id)
        {
           return await _feedbackscommentsRepo.GetFeedbacksCommentsById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbacksComments(int id, FeedbacksComments FeedbacksComments)
        {
            return await _feedbackscommentsRepo.PutFeedbacksComments(id, FeedbacksComments);
        }

        [HttpPost]
        public async Task<ActionResult<FeedbacksComments>> PostFeedbacksComments(FeedbacksComments FeedbacksComments)
        {
            return await _feedbackscommentsRepo.PostFeedbacksComments(FeedbacksComments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbacksComments(int id)
        {
            return await _feedbackscommentsRepo.DeleteFeedbacksComments(id);
        }
    }
}
