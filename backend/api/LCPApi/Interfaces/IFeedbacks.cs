using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface IFeedbacks {
    Task<ActionResult<IEnumerable<Feedbacks>>> GetFeedbacks();
    Task<ActionResult<Feedbacks>> GetFeedbacksById(int id);
    Task<IActionResult> PutFeedbacks(int id, Feedbacks Feedbacks);
    Task<ActionResult<Feedbacks>> PostFeedbacks(Feedbacks Feedbacks);
    Task<IActionResult> DeleteFeedbacks(int id);
}