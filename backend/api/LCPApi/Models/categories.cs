using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCPApi.Models;
public class Categories {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoriesId { get; set; }
    public string? CategoriesDesc { get; set; }
    public int? ProjectsId { get; set; }
}