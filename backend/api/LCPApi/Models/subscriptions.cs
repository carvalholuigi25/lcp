using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Subscriptions {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SubscriptionsId { get; set; }
    public string SubscriptionsTitle { get; set; } = null!;
    public string? SubscriptionsDesc { get; set; }
    public string? SubscriptionsType { get; set; }
    public string? SubscriptionsImage { get; set; }
    public DateTime? SubscriptionsDatePurchased { get; set; }
    public DateTime? SubscriptionsDateEnded { get; set; }
    public bool? SubscriptionsIsExpired { get; set; }
    public int? CustomersId { get; set; }
    public int? EmployeesId { get; set; }
    public int? ProductsId { get; set; }
}