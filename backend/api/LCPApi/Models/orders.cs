using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Orders {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrdersId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public double ItemPrice { get; set; }
    public double ItemDiscount { get; set; }
    public double ItemStock { get; set; }
    public int ProductsId { get; set; }
}