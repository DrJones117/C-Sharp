#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace wedding_planner.Models;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    
    [Required]
    public string WedderOne { get; set; }

    [Required]
    public string WedderTwo { get; set; }

    [Required]
    [DateValidation]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Required]
    public string Address { get; set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    // Foreign Key
    public int UserId { get; set; }
    public User? Planner { get; set; }
    public List<RSVP> Attendees { get; set; } = new();
}

public class DateValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {
        DateTime today = DateTime.Now.Date;
        DateTime userInput = (DateTime)value;

        Console.WriteLine(today);

        if (userInput < today)
        {
            return new ValidationResult("Date must be in the Future.");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}


