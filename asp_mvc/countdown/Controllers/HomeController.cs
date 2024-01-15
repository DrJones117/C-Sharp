using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using countdown.Models;

namespace countdown.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        DateTime start = DateTime.Now;
        DateTime end = new(2050, 1, 20, 3, 30, 00);

        TimeSpan timeRemaining = end - start;

        string formattedStart = start.ToString("yyyy-MM-dd HH:mm:ss");
        string formattedEnd = end.ToString("yyyy-MM-dd HH:mm:ss");
        string formattedTimeRemaining = timeRemaining.ToString("%d") + " day(s)" +  " " + timeRemaining.ToString("%h") + "hour(s)" + " " +  timeRemaining.ToString("%m") + "minute(s)";

        ViewData["formattedStart"] = formattedStart;
        ViewData["formattedEnd"] = formattedEnd;
        ViewData["formattedTimeRemaining"] = formattedTimeRemaining;

        return View("Index");
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
