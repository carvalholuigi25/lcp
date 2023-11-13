using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class ProjectsPhases {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectsPhasesId { get; set; }
    public string ProjectsPhasesName { get; set; } = null!;
    public string? ProjectsPhasesDesc { get; set; }
    public ProjectsPhasesStatusEnum? ProjectsPhasesStatus { get; set; } = ProjectsPhasesStatusEnum.low;
    public DateTime? ProjectsPhasesDateStart { get; set; }
    public DateTime? ProjectsPhasesDateEnd { get; set; }
    public string? ProjectsPhasesActivities { get; set; }
    public int? TasksId { get; set; }
    public int? CategoriesId { get; set; }
}

public enum ProjectsPhasesStatusEnum {
    low,
    medium,
    high
}