using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class OrdersCustomers {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrdersId { get; set; }
    public int? CustomersId { get; set; }
}