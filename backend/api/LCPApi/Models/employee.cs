using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LCPApi.Models;
public class Employee {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = null!;
    public string EmployeePassword { get; set; } = null!;
    public string? EmployeeRole { get; set; }
    public string? EmployeeEmail { get; set; }
    public int? EmployeePin { get; set; }
    public string? EmployeeFirstName { get; set; }
    public string? EmployeeLastName { get; set; }
    public string? EmployeeJob { get; set; }
    public DateTime? EmployeeDateBirthday { get; set; }
    public DateTime? EmployeeDateRegistered { get; set; } = DateTime.Now;
    public string? EmployeeCountry { get; set; }
    public string? EmployeePhoneNumber { get; set; }
    public string? EmployeePostalAddress { get; set; }
    public string? EmployeeCity { get; set; }
    public string? EmployeeZipCode { get; set; }
    public string? EmployeeStateProvince { get; set; }
    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}