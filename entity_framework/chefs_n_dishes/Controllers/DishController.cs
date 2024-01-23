// Using statements
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using chefs_n_dishes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace chefs_n_dishes.Controllers;    
public class DishController : Controller
{    
    private readonly ILogger<DishController> _logger;

    private MyContext _context;         

    public DishController(ILogger<DishController> logger, MyContext context)    
    {        
        _logger = logger;

        _context = context;    
    }

    // Renders the dashboard of Dishes
    [HttpGet("dishes")]    
    public IActionResult Dishes()    
    {     
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Creator).ToList();
        return View(AllDishes);    
    }

    // Renders the Add Dish form.
    [HttpGet("dish/new")]
    public IActionResult NewDish()
    {
        List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.ChefChoices = new List<SelectListItem>()
        {
            new("---choose---","",true,true),
        };

        foreach (var entry in AllChefs)
        {
            ViewBag.ChefChoices.Add(new SelectListItem($"{entry.FirstName} {entry.LastName}", $"{entry.ChefId}"));
        }

        ViewBag.TastinessChoices = new List<SelectListItem>()
        {
            new("---choose---","",true,true),
            new("1", "1"),
            new("2", "2"),
            new("3", "3"),
            new("4", "4"),
            new("5", "5"),
        };

        return View("NewDish");
    }

    // Processes the form data.
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (!ModelState.IsValid)
        {

        // Model state is invalid, return to the NewDish view with the model
        // List<Chef> AllChefs = _context.Chefs.ToList();

        // ViewBag.ChefChoices = new List<SelectListItem>
        // {
        //     new SelectListItem("---choose---", "", true, true),
        // };

        // foreach (var entry in AllChefs)
        // {
        //     ViewBag.ChefChoices.Add(new SelectListItem($"{entry.FirstName} {entry.LastName}", $"{entry.ChefId}"));
        // }

        // ViewBag.TastinessChoices = new List<SelectListItem>
        // {
        //     new SelectListItem("---choose---", "", true, true),
        //     new SelectListItem("1", "1"),
        //     new SelectListItem("2", "2"),
        //     new SelectListItem("3", "3"),
        //     new SelectListItem("4", "4"),
        //     new SelectListItem("5", "5"),
        // };

            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

        return NewDish();
        }
        else
        {   
            _context.Add(newDish);
            _context.SaveChanges();

            return RedirectToAction("Dishes");
        }
    }
}