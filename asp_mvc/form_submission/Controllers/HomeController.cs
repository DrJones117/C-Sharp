using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using form_submission.Models;

namespace form_submission.Controllers;

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
    public IActionResult Process(Form data)
    {
        Console.WriteLine(data);
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        else 
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return View("Index");
        }
    }

    [HttpGet]
    [Route("success")]
    public ViewResult Success()
    {
        Console.WriteLine("Success");

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
