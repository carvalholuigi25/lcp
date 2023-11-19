using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Order {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public double ItemPrice { get; set; }
    public double ItemDiscount { get; set; }
    public double ItemStock { get; set; }
    public int ProductId { get; set; }
}

public class OrderCustomer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public int? CustomerId { get; set; }
}