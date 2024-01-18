#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required]
    public string Name { get; set; } 

    [Required]
    public string Chef { get; set; } 

    [Required]
    [TastinessValidation]
    public int Tastiness { get; set; }

    [Required]
    [CaloriesValidation]
    public int Calories { get; set; }

    [Required]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}


public class TastinessValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((int)value <= 0 || (int)value > 5)
        {
            return new ValidationResult("Tastiness must be between 1 and 5");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

public class CaloriesValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((int)value <= 0)
        {
            return new ValidationResult("The Dish must be more than 0 calories.");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}
