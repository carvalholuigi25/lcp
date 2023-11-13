using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Departments {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DepartmentsId { get; set; }
    public string DepartmentsName { get; set; } = null!;
    public string? DepartmentsType { get; set; }
    public string? DepartmentsDesc { get; set; }
    public int? ProjectsId { get; set; }
    public int? EmployeesId { get; set; }
}