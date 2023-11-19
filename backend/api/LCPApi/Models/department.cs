using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Department {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = null!;
    public string? DepartmentType { get; set; }
    public string? DepartmentDesc { get; set; }
    public int? ProjectId { get; set; }
    public int? EmployeeId { get; set; }
}