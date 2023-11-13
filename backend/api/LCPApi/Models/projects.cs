using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Projects {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectsId { get; set; }
    public string ProjectsName { get; set; } = null!;
    public string ProjectsDesc { get; set; } = null!;
    public string ProjectsCompany { get; set; } = null!;
    public string ProjectsOwner { get; set; } = null!;
    public string? ProjectsCategory { get; set; }
    public bool? ProjectsPriority { get; set; }
    public ProjectsStatusEnum? ProjectsStatus { get; set; } = ProjectsStatusEnum.pending;
    public DateTime? ProjectsDateStart { get; set; }
    public DateTime? ProjectsDateEnd { get; set; }
    public DateTime? ProjectsDateClose { get; set; }
    public int? ProjectsBudgetDays { get; set; }
    public double? ProjectsBudgetCost { get; set; }
    public int? ProjectsRecords { get; set; }
}

public enum ProjectsStatusEnum {
    pending,
    delivered,
    approved,
    rejected,
    delayed,
    cancelled
}