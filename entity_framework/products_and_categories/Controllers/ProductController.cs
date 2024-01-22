// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using products_and_categories.Models;
namespace YourProjectName.Controllers;    
public class ProductController : Controller
{    
    private readonly ILogger<ProductController> _logger;

    private MyContext _context;         

    public ProductController(ILogger<ProductController> logger, MyContext context)    
    {        
        _logger = logger;

        _context = context;    
    }

    [HttpGet("")]    
    public IActionResult Index()    
    {     

        return View();    
    } 
}
