#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace date_validator.Models;

public class Birthday
{
    [BirthDateValidation]
    public DateTime BirthDate {get;set;}
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
            return new ValidationResult("You can't have been born in the future.");
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