using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Project {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectId { get; set; }
    public string ProjectName { get; set; } = null!;
    public string ProjectDesc { get; set; } = null!;
    public string ProjectCompany { get; set; } = null!;
    public string ProjectOwner { get; set; } = null!;
    public string? ProjectCategory { get; set; }
    public bool? ProjectPriority { get; set; }
    public ProjectStatusEnum? ProjectStatus { get; set; } = ProjectStatusEnum.pending;
    public DateTime? ProjectDateStart { get; set; }
    public DateTime? ProjectDateEnd { get; set; }
    public DateTime? ProjectDateClose { get; set; }
    public int? ProjectBudgetDays { get; set; }
    public double? ProjectBudgetCost { get; set; }
    public int? ProjectRecords { get; set; }
}

public class ProjectPhase {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectPhaseId { get; set; }
    public string ProjectPhaseName { get; set; } = null!;
    public string? ProjectPhaseDesc { get; set; }
    public ProjectPhaseStatusEnum? ProjectPhaseStatus { get; set; } = ProjectPhaseStatusEnum.low;
    public DateTime? ProjectPhaseDateStart { get; set; }
    public DateTime? ProjectPhaseDateEnd { get; set; }
    public string? ProjectPhaseActivities { get; set; }
    public int? TaskId { get; set; }
    public int? CategoryId { get; set; }
}

public class ProjectTask {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectTaskId { get; set; }
    public string ProjectTaskName { get; set; } = null!;
    public string ProjectTaskDesc { get; set; } = null!;
    public string ProjectTaskProject { get; set; } = null!;
    public string ProjectTaskPhaseName { get; set; } = null!;
    public ProjectTaskStatusEnum ProjectTaskStatus { get; set; } = ProjectTaskStatusEnum.pending;
    public string? ProjectTaskOwner { get; set; }
    public string? ProjectTaskType { get; set; }
    public ProjectTaskPriorityEnum? ProjectTaskPriority { get; set; } = ProjectTaskPriorityEnum.low;
    public DateTime? ProjectTaskStartDate { get; set; }
    public DateTime? ProjectTaskEndDate { get; set; }
    public string? ProjectTaskTeam { get; set; }
    public DateTime? ProjectTaskReviewDate { get; set; }
    public string? ProjectTaskReviewReport { get; set; }
    public string? ProjectTaskDocument { get; set; }
    public string? ProjectTaskDetails { get; set; }
    public int? ProjectId { get; set; }
    public int? CategoryId { get; set; }
}

public class ProjectTaskType {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectTaskTypeId { get; set; }
    public string? ProjectTaskTypeDesc { get; set; }
    public int? ProjectTaskId { get; set; }
}

public enum ProjectTaskStatusEnum {
    pending,
    accepted,
    delayed,
    cancelled
}

public enum ProjectTaskPriorityEnum {
    low,
    medium,
    high
}

public enum ProjectPhaseStatusEnum {
    low,
    medium,
    high
}

public enum ProjectStatusEnum {
    pending,
    delivered,
    approved,
    rejected,
    delayed,
    cancelled
}