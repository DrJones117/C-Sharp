using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

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
        return View("Dishes", AllDishes);
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
            new("5", "5"),
        };

        return View("Form");
    }

    // Adds the info to the database
    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return Form();
        }
        else
        {
            _context.Add(newDish);
            _context.SaveChanges();

            return RedirectToAction("Dishes");
        }
    }

    // Renders a single dish
    [HttpGet("dishes/{id}")]
    public IActionResult Show(int id)
    {
        Dish singleDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);

        return View(singleDish); 
    }

    // Renders the form to edit a Dish
    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        ViewBag.TastinessChoices = new List<SelectListItem>()
        {
            new("---choose---","",true,true),
            new("1", "1"),
            new("2", "2"),
            new("3", "3"),
            new("4", "4"),
            new("5", "5"),
        };

        Dish? dishToEdit = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);

        if (dishToEdit == null)
        {
            return RedirectToAction("Show");
        }
        return View(dishToEdit);
    }

    // Handles the updated information and posts it to the database
    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateDish(Dish editedDish, int dishId)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);

        if (!ModelState.IsValid || OldDish == null)
        {
            return RedirectToAction("EditDish", editedDish);
        }
        else
        {
            OldDish.Name = editedDish.Name;
            OldDish.Chef = editedDish.Chef;
            OldDish.Tastiness = editedDish.Tastiness;
            OldDish.Calories = editedDish.Calories;
            OldDish.Description = editedDish.Description;

            OldDish.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return RedirectToAction("Show", new { id = dishId });
        }
    }

    // Deletes the information from the database by the given id
    [HttpPost("dishes/{dishId}/destroy")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);

        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Dishes");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
