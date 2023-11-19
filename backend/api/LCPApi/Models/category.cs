using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Category {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }
    public string? CategoryDesc { get; set; }
    public int? ProjectId { get; set; }
}