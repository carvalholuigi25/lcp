using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Employees {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeesId { get; set; }
    public string EmployeesName { get; set; } = null!;
    public string EmployeesPassword { get; set; } = null!;
    public string? EmployeesRole { get; set; }
    public string? EmployeesEmail { get; set; }
    public int? EmployeesPin { get; set; }
    public string? EmployeesFirstName { get; set; }
    public string? EmployeesLastName { get; set; }
    public string? EmployeesJob { get; set; }
    public DateTime? EmployeesDateBirthday { get; set; }
    public DateTime? EmployeesDateRegistered { get; set; } = DateTime.Now;
    public string? EmployeesCountry { get; set; }
    public string? EmployeesPhoneNumber { get; set; }
    public string? EmployeesPostalAddress { get; set; }
    public string? EmployeesCity { get; set; }
    public string? EmployeesZipCode { get; set; }
    public string? EmployeesStateProvince { get; set; }
}