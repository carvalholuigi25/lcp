using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Products {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductsId { get; set; }
    public string ProductsTitle { get; set; } = null!;
    public string ProductsType { get; set; } = null!;
    public string? ProductsDesc { get; set; }
    public double? ProductsPrice { get; set; }
    public string? ProductsImageMain { get; set; }
    public string? ProductsGallery { get; set; }
    public bool? ProductsIsFeatured { get; set; }
    public DateTime? ProductsDateCreated { get; set; }
    public DateTime? ProductsDateUpdated { get; set; }
    public int? CustomersId { get; set; }
    public int? EmployeesId { get; set; }
}