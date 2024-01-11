using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using view_model_fun.Models;

namespace view_model_fun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static string Message = "This is my message";

    public static List<int> IntArr = new([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1000, -76, +56]);
    public static User FirstGuy = new("Gaston", "Leroux");
    public static User SecondGuy = new("Scott", "Lynch");
    public static User ThirdGuy = new("John", "Tolkien");
    public static User FourthGuy = new("Brandon", "Sanderson");
    public static List<User> UserList = new([FirstGuy, SecondGuy, ThirdGuy, FourthGuy]);

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("Index", Message);
    }

    [HttpGet]
    [Route("numbers")]
    public ViewResult Numbers()
    {
        return View("Numbers", IntArr);
    }

    [HttpGet]
    [Route("user")]
    public ViewResult User()
    {
        return View("User", FirstGuy);
    }
    
    [HttpGet]
    [Route("users")]
    public ViewResult Users()
    {
        return View("Users", UserList);
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
