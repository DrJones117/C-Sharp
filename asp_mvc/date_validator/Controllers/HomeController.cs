using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using date_validator.Models;

namespace date_validator.Controllers;

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
    public IActionResult Process(Birthday model)
    {
        Console.WriteLine($"Here is the model {model.BirthDate}");
        if (ModelState.IsValid)
        {
            Console.WriteLine("Success");
            return RedirectToAction("Success");
        }
        else
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return View("Index", model);
        }
    }

    [HttpGet]
    [Route("success")]
    public ViewResult Success()
    {

        return View();
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
