using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IFeedbacksComments {
    Task<ActionResult<IEnumerable<FeedbacksComments>>> GetFeedbacksComments();
    Task<ActionResult<FeedbacksComments>> GetFeedbacksCommentsById(int id);
    Task<IActionResult> PutFeedbacksComments(int id, FeedbacksComments FeedbacksComments);
    Task<ActionResult<FeedbacksComments>> PostFeedbacksComments(FeedbacksComments FeedbacksComments);
    Task<IActionResult> DeleteFeedbacksComments(int id);
}