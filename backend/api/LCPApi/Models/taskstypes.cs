using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class TasksTypes {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TasksTypesId { get; set; }
    public string? TasksTypesDesc { get; set; }
    public int? TasksId { get; set; }
}