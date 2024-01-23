#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace chefs_n_dishes.Models;
public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    public string FirstName { get; set; } 

    [Required]
    public string LastName { get; set; }

    [Required]
    [BirthDateValidation]
    [DataType(DataType.Date)]
    public DateTime BirthDate {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}

public class BirthDateValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {
        DateTime today = DateTime.Now.Date;
        DateTime userInput = (DateTime)value;

        Console.WriteLine(today);

        if (userInput > today)
        {
            Console.WriteLine("Are we getting back here?");
            return new ValidationResult("The Chef can't have been born in the future.");
        }
        if (userInput.ToString() == "")
        {
            return new ValidationResult("Hmm if you didn't provide a date, you must not exist");
        }
        else
        {
            Console.WriteLine("The Date was correct");
            return ValidationResult.Success;
        }
    }
}
