using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Tasks {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TasksId { get; set; }
    public string TasksName { get; set; } = null!;
    public string TasksDesc { get; set; } = null!;
    public string TasksProject { get; set; } = null!;
    public string TasksPhaseName { get; set; } = null!;
    public TasksStatusEnum TasksStatus { get; set; } = TasksStatusEnum.pending;
    public string? TasksOwner { get; set; }
    public string? TasksType { get; set; }
    public TasksPriorityEnum? TasksPriority { get; set; } = TasksPriorityEnum.low;
    public DateTime? TasksStartDate { get; set; }
    public DateTime? TasksEndDate { get; set; }
    public string? TasksTeam { get; set; }
    public DateTime? TasksReviewDate { get; set; }
    public string? TasksReviewReport { get; set; }
    public string? TasksDocument { get; set; }
    public string? TasksDetails { get; set; }
    public int? ProjectsId { get; set; }
    public int? CategoriesId { get; set; }
}

public enum TasksStatusEnum {
    pending,
    accepted,
    delayed,
    cancelled
}

public enum TasksPriorityEnum {
    low,
    medium,
    high
}