using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDelicious.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private MyContext _context;     

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;

        _context = context;
    }

    // Renders the Home Page
    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {

        List<Dish> AllDishes = _context.Dishes.ToList();
        return View("Dishes");
    }

    // Renders the Form
    [HttpGet("/dishes/new")]
    public IActionResult Form()
    {

        ViewBag.TastinessChoices = new List<SelectListItem>()
        {
            new("---choose---","",true,true),
            new("1", "1"),
            new("2", "2"),
            new("3", "3"),
            new("4", "4"),
        };

        return View("Form");
    }

    [HttpPost("/dishes/create")]
    public IActionResult Process()
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
        }

        if (!ModelState.IsValid)
        {
            return Form();
        }
        return RedirectToAction();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
