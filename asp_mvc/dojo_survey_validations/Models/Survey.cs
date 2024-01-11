#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace dojo_survey_validations.Models;

public class Survey
{
    [Required]
    [MinLength(2)]
    public string Name {get;set;}

    [Required]
    public string Location {get;set;}

    [Required]
    public string Language {get;set;}

    [CommentValidation]
    public string? Comment {get;set;}
}

public class CommentValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }
        else if (value.ToString()?.Length < 21)
        {
            return new ValidationResult("Comments must be longer than 20 characters long when they are given");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}