using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using wedding_planner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace wedding_planner.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    private MyContext _context;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;

        _context = context;
    }

// Renders the page displaying the form.
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

// Handles the register data and redirects to the success page upon successful validation.
    [HttpPost("users/create")]
    public IActionResult Create(User newUser)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return View("Index");
        }
        else
        {
            PasswordHasher<User> Hasher = new();

            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("UserName", newUser.FirstName);

            _context.Add(newUser);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Wedding");
        }
    }

// Handles the login data 
    [HttpPost("users/login")]
    public IActionResult LogIn(LogUser user)
    {

        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == user.LogEmail);
            
            if (userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return View("Index");
            }

            PasswordHasher<LogUser> hasher = new();

            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LogPassword);

            if (result == 0)
            {
                ModelState.AddModelError("LogPassword", "Invalid Email/Password");
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                HttpContext.Session.SetString("UserName", userInDb.FirstName);

                return RedirectToAction("Dashboard", "Wedding");
            }
        }
        // if (ModelState.ContainsKey("LogPassword") && !ModelState.ContainsKey("LogEmail"))
        // {
        //     ModelState["LogPassword"].Errors.Clear();
        // }
        return View("Index");
    }

    [HttpPost("users/logout")]
    public RedirectToActionResult LogOut()
    {
        // HttpContext.Session.Clear();
        HttpContext.Session.Remove("UserId");
        HttpContext.Session.Remove("UserName");

        Console.WriteLine("Session has been cleared.");

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
