// Using statements
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using chefs_n_dishes.Models;
namespace chefs_n_dishes.Controllers;    
public class ChefController : Controller
{    
    private readonly ILogger<ChefController> _logger;

    private MyContext _context;         

    public ChefController(ILogger<ChefController> logger, MyContext context)    
    {        
        _logger = logger;

        _context = context;    
    }

    // Renders the dashboard of Chefs
    [HttpGet("")]    
    public IActionResult Chefs()    
    {     
        List<Chef> AllChefs = _context.Chefs.Include(d => d.AllDishes).ToList();
        return View(AllChefs);
    } 

    // Renders the Add Chef form.
    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View();
    }

    // Processes the form data.
    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return View("NewChef");
        }
        else
        {   
            _context.Add(newChef);
            _context.SaveChanges();

            return RedirectToAction("Chefs");
        }
    }
}
