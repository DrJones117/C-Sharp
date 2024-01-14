#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace form_submission.Models;

public class Form
{
    [Required]
    [MinLength(2, ErrorMessage = "The Name field must have at least 2 characters.")]
    public string Name {get;set;}

    [Required]
    [EmailValidation]
    public string Email {get;set;}

    [Required(ErrorMessage = "The BirthDate field is required.")]
    [BirthDateValidation]
    public DateTime BirthDate {get;set;}

    [Required]
    [MinLength(8, ErrorMessage = "The Password field must have at least 8 characters.")]
    public string Password {get;set;}

    [Required(ErrorMessage = "The FavOddNum field is required.")]
    [FavOddNumValidation]
    public int FavOddNum {get;set;}
}

public class EmailValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string email && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("The Email field is not in a valid format");
        }
    }
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

public class FavOddNumValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int oddNum)
        {
            Console.WriteLine("oddNum");
            if (oddNum % 2 != 1)
            {
                return new ValidationResult("The FavOddNum field must be an odd number.");
            }
        }

        return ValidationResult.Success;
    }
}