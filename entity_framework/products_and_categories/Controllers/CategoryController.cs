// Using statement
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using products_and_categories.Models;
namespace products_and_categories.Controllers;     
public class CategoryController : Controller
{    
    private readonly ILogger<CategoryController> _logger;

    private MyContext _context;         

    public CategoryController(ILogger<CategoryController> logger, MyContext context)    
    {        
        _logger = logger;

        _context = context;
    }

    // Renders the Page to both add and view Categories.
    [HttpGet("categories")]
    public IActionResult Categories()
    {
        List<Category> AllCategories = _context.Categories.ToList();
        ViewBag.AllCategories = new List<Category>();

        foreach (Category entry in AllCategories)
        {
            ViewBag.AllCategories.Add(entry);
        }


        return View("Categories");
    }

    // Processes the data from the add category form.
    [HttpPost("categories/create")]
    public IActionResult Create(Category newCategory)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return Categories();
        }
        else
        {
            _context.Add(newCategory);
            _context.SaveChanges();

            return RedirectToAction("Categories");
        }
    }

    // Renders the page to associate products with categories.
    [HttpGet("categories/{categoryId}")]
    public IActionResult CategoryConnect(int categoryId)
    {
        // Products associated with one Category.
        Category singleCategory = _context.Categories.Include(p => p.Products).ThenInclude(p => p.Product).FirstOrDefault(c => c.CategoryId == categoryId);

        ViewBag.Category = singleCategory;
        ViewBag.CategoryProducts = singleCategory.Products;

        // All Products
        List<Product> AllProducts = _context.Products.ToList();

        ViewBag.ProductChoices = new List<SelectListItem>
        {
            new("--choose--", "", true, true)
        };

        foreach (Product entry in AllProducts)
        {
            bool productExists = false;
            foreach (var product in ViewBag.CategoryProducts)
            {
                if (product.Product.Name == entry.Name)
                {
                    productExists = true;
                    break;
                }
            }

            if (!productExists)
            {
                ViewBag.ProductChoices.Add(new SelectListItem(entry.Name, entry.ProductId.ToString()));
            }
        }

        return  View("CategoryConnect");
    }

    // Adds the product to the associated category.
    [HttpPost("categories/addProduct")]
    public IActionResult AddProduct(int productId, int categoryId)
    {
        Category singleCategory = _context.Categories.Include(p => p.Products).FirstOrDefault(c => c.CategoryId == categoryId);

        Product product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

        if (singleCategory != null && product != null)
        {
            if (!singleCategory.Products.Any(p => p.ProductId == productId))
            {
                singleCategory.Products.Add(new Association { Category = singleCategory, Product = product});
                _context.SaveChanges();
            }
        }

        return RedirectToAction("CategoryConnect", new { categoryId });
    }
}



