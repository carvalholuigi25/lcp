using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Subscription {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubscriptionId { get; set; }
    public string SubscriptionTitle { get; set; } = null!;
    public string? SubscriptionDesc { get; set; }
    public string? SubscriptionType { get; set; }
    public string? SubscriptionImage { get; set; }
    public DateTime? SubscriptionDatePurchased { get; set; }
    public DateTime? SubscriptionDateEnded { get; set; }
    public bool? SubscriptionIsExpired { get; set; }
    public int? CustomerId { get; set; }
    public int? EmployeeId { get; set; }
    public int? ProductId { get; set; }
}

public class SubscriptionKey {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubscriptionKeyId { get; set; }
    public string? SubscriptionKeyValue { get; set; }
    public DateTime? SubscriptionKeyDateStart { get; set; }
    public DateTime? SubscriptionKeyDateEnd { get; set; }
    public DateTime? SubscriptionKeyDateUpdated { get; set; }
    public SubscriptionKeyEnum? SubscriptionKeyStatus { get; set; } = SubscriptionKeyEnum.pending;
    public int? SubscriptionId { get; set; }
}

public enum SubscriptionKeyEnum {
    pending,
    granted,
    expired,
    revoked,
    unknown
}