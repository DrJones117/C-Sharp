using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojo_survey_model.Models;

namespace dojo_survey_model.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("process")]
    public RedirectToActionResult Process(Survey user)
    {

        return RedirectToAction("Params", new {name=user.Name, location=user.Location, language=user.Language, comment=user.Comment });
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
