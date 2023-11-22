using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LCPApi.Models;
public class Customer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;
    [Column(TypeName = "varchar(MAX)")]
    public string CustomerPassword { get; set; } = null!;
    public string? CustomerRole { get; set; }
    public string? CustomerEmail { get; set; }
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter a valid number.")]
    [MaxLength(4, ErrorMessage = "The pin has been reached at max of 4 numbers!")]
    [Column(TypeName = "varchar(MAX)")]
    public string? CustomerPin { get; set; }
    public string? CustomerFirstName { get; set; }
    public string? CustomerLastName { get; set; }
    public string? CustomerJob { get; set; }
    public DateTime? CustomerDateBirthday { get; set; }
    public DateTime? CustomerDateRegistered { get; set; } = DateTime.Now;
    public string? CustomerCountry { get; set; }
    public string? CustomerPhoneNumber { get; set; }
    public string? CustomerPostalAddress { get; set; }
    public string? CustomerCity { get; set; }
    public string? CustomerZipCode { get; set; }
    public string? CustomerStateProvince { get; set; }
    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}