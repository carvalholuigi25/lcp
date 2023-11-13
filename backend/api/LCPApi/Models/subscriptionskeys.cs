using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class SubscriptionsKeys {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubscriptionsKeysId { get; set; }
    public string? SubscriptionsKeysValue { get; set; }
    public DateTime? SubscriptionsKeysDateStart { get; set; }
    public DateTime? SubscriptionsKeysDateEnd { get; set; }
    public DateTime? SubscriptionsKeysDateUpdated { get; set; }
    public SubscriptionsKeysEnum? SubscriptionsKeysStatus { get; set; } = SubscriptionsKeysEnum.pending;
    public int? SubscriptionsId { get; set; }
}

public enum SubscriptionsKeysEnum {
    pending,
    granted,
    expired,
    revoked,
    unknown
}