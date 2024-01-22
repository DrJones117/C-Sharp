#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
namespace products_and_categories.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int Price { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> Categories { get; set; } = new List<Association>();
}