using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IFeedback {
    Task<ActionResult<IEnumerable<Feedback>>> GetFeedback();
    Task<ActionResult<Feedback>> GetFeedbackById(int id);
    Task<IActionResult> PutFeedback(int id, Feedback Feedback);
    Task<ActionResult<Feedback>> PostFeedback(Feedback Feedback);
    Task<IActionResult> DeleteFeedback(int id);
    Task<ActionResult<IEnumerable<FeedbackComment>>> GetFeedbackComment();
    Task<ActionResult<FeedbackComment>> GetFeedbackCommentById(int id);
    Task<IActionResult> PutFeedbackComment(int id, FeedbackComment FeedbackComment);
    Task<ActionResult<FeedbackComment>> PostFeedbackComment(FeedbackComment FeedbackComment);
    Task<IActionResult> DeleteFeedbackComment(int id);
}