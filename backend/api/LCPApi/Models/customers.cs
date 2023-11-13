using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Customers {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomersId { get; set; }
    public string CustomersName { get; set; } = null!;
    public string CustomersPassword { get; set; } = null!;
    public string? CustomersRole { get; set; }
    public string? CustomersEmail { get; set; }
    public int? CustomersPin { get; set; }
    public string? CustomersFirstName { get; set; }
    public string? CustomersLastName { get; set; }
    public string? CustomersJob { get; set; }
    public DateTime? CustomersDateBirthday { get; set; }
    public DateTime? CustomersDateRegistered { get; set; } = DateTime.Now;
    public string? CustomersCountry { get; set; }
    public string? CustomersPhoneNumber { get; set; }
    public string? CustomersPostalAddress { get; set; }
    public string? CustomersCity { get; set; }
    public string? CustomersZipCode { get; set; }
    public string? CustomersStateProvince { get; set; }
}