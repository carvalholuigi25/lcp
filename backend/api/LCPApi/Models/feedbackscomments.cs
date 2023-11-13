using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class FeedbacksComments {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbacksCommentsId { get; set; }
    public string FeedbacksCommentsMsg { get; set; } = null!;
    public int? FeedbacksCommentsUpvotes { get; set; }
    public int? FeedbacksCommentsDownvotes { get; set; }
    public FeedbacksCommentsStatusEnum? FeedbacksCommentsStatus { get; set; } = FeedbacksCommentsStatusEnum.pending;
    public DateTime? FeedbacksCommentsDateCreated { get; set; }
    public DateTime? FeedbacksCommentsDateUpdated { get; set; }
    public DateTime? FeedbacksCommentsDateLocked { get; set; }
    public int? FeedbacksId { get; set; }
    public int? CustomersId { get; set; }
    public int? ProjectsId { get; set; }
}

public enum FeedbacksCommentsStatusEnum {
    pending,
    accepted,
    denied,
    locked
}