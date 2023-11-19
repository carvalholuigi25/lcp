using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LCPApi.Models;
public class Product {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    public string ProductTitle { get; set; } = null!;
    public string ProductType { get; set; } = null!;
    public string? ProductDesc { get; set; }
    public double? ProductPrice { get; set; }
    public string? ProductImageMain { get; set; }
    public string? ProductGallery { get; set; }
    public bool? ProductIsFeatured { get; set; }
    public DateTime? ProductDateCreated { get; set; }
    public DateTime? ProductDateUpdated { get; set; }
    public int? CustomerId { get; set; }
    public int? EmployeeId { get; set; }
    [JsonIgnore]
    public Customer? Customers { get; set; }
    [JsonIgnore]
    public Employee? Employees { get; set; }
}

public class ProductProject {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    public int? ProjectId { get; set; }
}

public class ProductSubscription {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    public int? SubscriptionId { get; set; }
}