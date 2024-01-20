#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace login_and_reg.Models;

public class LogUser
{
    [Required(ErrorMessage = "Invalid Email/Password")]
    [Display(Name = "Email")]
    [EmailAddress]
    public string LogEmail { get; set; }

    [Required(ErrorMessage = "Invalid Email/Password")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string LogPassword { get; set; }
}