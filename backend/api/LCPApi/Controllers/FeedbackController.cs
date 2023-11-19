using Microsoft.AspNetCore.Mvc;
using LCPApi.Models;
using LCPApi.Interfaces;

namespace LCPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedback _feedbackRepo;

        public FeedbackController(IFeedback feedbackRepo)
        {
            _feedbackRepo = feedbackRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
        {
           return await _feedbackRepo.GetFeedback();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
        {
           return await _feedbackRepo.GetFeedbackById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, Feedback Feedback)
        {
            return await _feedbackRepo.PutFeedback(id, Feedback);
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback Feedback)
        {
            return await _feedbackRepo.PostFeedback(Feedback);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            return await _feedbackRepo.DeleteFeedback(id);
        }

        [HttpGet("comment")]
        public async Task<ActionResult<IEnumerable<FeedbackComment>>> GetFeedbackComment()
        {
           return await _feedbackRepo.GetFeedbackComment();
        }

        [HttpGet("comment/{id}")]
        public async Task<ActionResult<FeedbackComment>> GetFeedbackCommentById(int id)
        {
           return await _feedbackRepo.GetFeedbackCommentById(id);
        }

        [HttpPut("comment/{id}")]
        public async Task<IActionResult> PutFeedbackComment(int id, FeedbackComment FeedbackComment)
        {
            return await _feedbackRepo.PutFeedbackComment(id, FeedbackComment);
        }

        [HttpPost("comment")]
        public async Task<ActionResult<FeedbackComment>> PostFeedbackComment(FeedbackComment FeedbackComment)
        {
            return await _feedbackRepo.PostFeedbackComment(FeedbackComment);
        }

        [HttpDelete("comment/{id}")]
        public async Task<IActionResult> DeleteFeedbackComment(int id)
        {
            return await _feedbackRepo.DeleteFeedbackComment(id);
        }
    }
}
