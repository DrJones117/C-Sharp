using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using session_workshop.Models;

namespace session_workshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        HttpContext.Session.Clear();

        return View();
    }

    [HttpPost]
    [Route("process")]
    public IActionResult Process(string name)
    {

        Console.WriteLine($"Name: {name}");
        HttpContext.Session.SetString("Name", name);

        return RedirectToAction("Session");
    }

    [HttpGet]
    [Route("session")]
    public IActionResult Session()
    {
        if (@HttpContext.Session.GetString("Name") == null)
        {
            return RedirectToAction("Index");
        }

        int val = 0;
        return View("Session", val);
    }

    [HttpPost]
    [Route("operations")]
    public IActionResult Operations(string type, int value, int start)
    {
        if (type == "add")
        {
            start += value;
            Console.WriteLine(start);
            return View("Session", start);
        }
        else if (type == "times")
        {
            start *= value;
            Console.WriteLine(start);
            return View("Session", start);
        }
        else if (type == "minus")
        {
            start -= value;
            Console.WriteLine(start);
            return View("Session", start);
        }
        else if (type == "random")
        {
            Random rand = new Random();
            start += rand.Next(1, 11);
            Console.WriteLine(start);
            return View("Session", start);
        }

        if (@HttpContext.Session.GetString("Name") == null)
        {
            return RedirectToAction("Index");
        }

        return View("Session");
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
