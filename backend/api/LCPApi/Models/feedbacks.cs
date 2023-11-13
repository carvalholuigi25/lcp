using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Feedbacks {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbacksId { get; set; }
    public string FeedbacksTitle { get; set; } = null!;
    public string? FeedbacksMsg { get; set; }
    public FeedbacksStatusEnum? FeedbacksStatus { get; set; } = FeedbacksStatusEnum.pending;
    public DateTime? FeedbacksDateCreated { get; set; }
    public DateTime? FeedbacksDateUpdated { get; set; }
    public DateTime? FeedbacksDateLocked { get; set; }
    public string? FeedbacksAssignBy { get; set; }
    public int? FeedbacksUpvotes { get; set; }
    public int? FeedbacksDownvotes { get; set; }
    public int? CustomersId { get; set; }
    public int? ProjectsId { get; set; }
    public int? CommentsId { get; set; }
}

public enum FeedbacksStatusEnum {
    pending,
    accepted,
    denied,
    locked
}