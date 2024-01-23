// Using statement
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using products_and_categories.Models;
namespace products_and_categories.Controllers;    
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

        return RedirectToAction("Products");
    } 

    // Renders the Page to both add and view Products.
    [HttpGet("products")]
    public IActionResult Products()
    {
        List<Product> AllProducts = _context.Products.ToList();
        ViewBag.AllProducts = new List<Product>();

        foreach (Product entry in AllProducts)
        {
            ViewBag.AllProducts.Add(entry);
        }


        return View("Products");
    }

    // Processes the data from the add product form.
    [HttpPost("products/create")]
    public IActionResult Create(Product newProduct)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return Products();
        }
        else
        {
            _context.Add(newProduct);
            _context.SaveChanges();

            return RedirectToAction("Products");
        }
    }


    // Renders the page to associate categories with products.
    [HttpGet("products/{productId}")]
    public IActionResult ProductConnect(int productId)
    {
        // Categories associated with one Product.
        Product singleProduct = _context.Products.Include(c => c.Categories).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == productId);

        ViewBag.Product = singleProduct;
        ViewBag.ProductCategories = singleProduct.Categories;

        // All Categories
        List<Category> AllCategories = _context.Categories.ToList();

        ViewBag.CategoryChoices = new List<SelectListItem>
        {
            new("---choose---","",true,true),
        };

        foreach (Category entry in AllCategories)
        {
            bool categoryExists = false;
            foreach (var category in ViewBag.ProductCategories)
            {
                if (category.Category.Name == entry.Name)
                {
                    categoryExists = true;
                    break;
                }
            }

            if (!categoryExists)
            {
                ViewBag.CategoryChoices.Add(new SelectListItem(entry.Name, entry.CategoryId.ToString()));
            }
        }

        return View("ProductConnect");
    }


    // Adds the category to the associated Product.
    [HttpPost("products/addCategory")]
    public IActionResult AddCategory(int productId, int categoryId)
    {
        Product singleProduct = _context.Products.Include(c => c.Categories).FirstOrDefault(p => p.ProductId == productId);

        Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);

        if (singleProduct != null && category != null)
        {
            Console.WriteLine("step 1");
            if (!singleProduct.Categories.Any(c => c.CategoryId == categoryId))
            {
                singleProduct.Categories.Add(new Association { Product = singleProduct, Category = category});
                _context.SaveChanges();
            }
        }

        return RedirectToAction("ProductConnect", new { productId });
    }
}
