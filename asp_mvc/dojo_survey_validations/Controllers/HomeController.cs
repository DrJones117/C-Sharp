using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojo_survey_validations.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dojo_survey_model.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        ViewBag.LocationChoices = new List<SelectListItem>()
        {
            new("---choose---","",true,true),
            new("Mars", "Mars"),
            new("Delta 1", "Delta 1"),
            new("Chronos", "Chronos"),
            new("Arbor 4", "Arbor 4"),
        };

        ViewBag.LanguageChoices = new List<SelectListItem>()
        {
            new("---choose---","",true,true),
            new("JavaScript", "JavaScript"),
            new("Python", "Python"),
            new("C#", "C#"),
            new("Ruby", "Ruby"),
            new("Java", "Java"),
        };

        return View("Index");
    }

    [HttpPost]
    [Route("process")]
    public IActionResult Process(Survey user)
    {
        // if (!ModelState.IsValid)
        // {
        //     var message = string.Join(" | ", ModelState.Values
        //     .SelectMany(v => v.Errors)
        //     .Select(e => e.ErrorMessage));
        //     Console.WriteLine(message);
        // }

        // if (!ModelState.IsValid)
        // {
        //     return Index();
        // }

        if (ModelState.IsValid)
        {
            return RedirectToAction("Params", new {name=user.Name, location=user.Location, language=user.Language, comment=user.Comment });
        }
        else 
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return Index();
        }
    }

    [HttpGet("param/{name}/{location}/{language}/{comment}")]
    public ViewResult Params(string name, string location, string language, string comment)
    {
        Console.WriteLine($"Name: {name} Location: {location} Language: {language} Comment: {comment}");

    Survey User = new()
    {
        Name = name,
        Location = location,
        Language = language,
        Comment = comment
    };
        return View(User);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
