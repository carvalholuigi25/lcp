using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Feedback {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackId { get; set; }
    public string FeedbackTitle { get; set; } = null!;
    public string? FeedbackMsg { get; set; }
    public FeedbackStatusEnum? FeedbackStatus { get; set; } = FeedbackStatusEnum.pending;
    public DateTime? FeedbackDateCreated { get; set; }
    public DateTime? FeedbackDateUpdated { get; set; }
    public DateTime? FeedbackDateLocked { get; set; }
    public string? FeedbackAssignBy { get; set; }
    public int? FeedbackUpvotes { get; set; }
    public int? FeedbackDownvotes { get; set; }
    public int? CustomerId { get; set; }
    public int? ProjectId { get; set; }
    public int? CommentId { get; set; }
}

public class FeedbackComment {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackCommentId { get; set; }
    public string FeedbackCommentMsg { get; set; } = null!;
    public int? FeedbackCommentUpvotes { get; set; }
    public int? FeedbackCommentDownvotes { get; set; }
    public FeedbackCommentStatusEnum? FeedbackCommentStatus { get; set; } = FeedbackCommentStatusEnum.pending;
    public DateTime? FeedbackCommentDateCreated { get; set; }
    public DateTime? FeedbackCommentDateUpdated { get; set; }
    public DateTime? FeedbackCommentDateLocked { get; set; }
    public int? FeedbackId { get; set; }
    public int? CustomerId { get; set; }
    public int? ProjectId { get; set; }
}

public enum FeedbackCommentStatusEnum {
    pending,
    accepted,
    denied,
    locked
}

public enum FeedbackStatusEnum {
    pending,
    accepted,
    denied,
    locked
}