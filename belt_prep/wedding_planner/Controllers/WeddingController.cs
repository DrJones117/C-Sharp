using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using wedding_planner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Controllers;

[SessionCheck]
public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;

    private MyContext _context;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;

        _context = context;
    }

    // Renders the dashboard of weddings.
    [HttpGet("weddings")]
    public ViewResult Dashboard()
    {
        List<Wedding> AllWeddings = _context.Weddings.Include(p => p.Planner).Include(a => a.Attendees).ToList();

        return View(AllWeddings);
    }

    // Renders the form to add a Wedding.
    [HttpGet("weddings/new")]
    public ViewResult NewWedding()
    {
        return View("NewWedding");
    }

    [HttpGet("weddings/{weddingId}")]
    public IActionResult ShowWedding(int weddingId)
    {
        Wedding singleWedding = _context.Weddings
                                .Include(p => p.Planner)
                                .Include(u => u.Attendees)
                                .ThenInclude(r => r.Responder)
                                .FirstOrDefault(w => w.WeddingId == weddingId);
        if (singleWedding == null)
        {
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View(singleWedding);
        }
    }


    // Processes the form data and adds the new Wedding to the database.
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return NewWedding();
        }
        else
        {
            newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newWedding);
            _context.SaveChanges();

            return RedirectToAction("ShowWedding", new{weddingId = newWedding.WeddingId});
        }
    }

    // This a User delete a wedding they have created.
    [HttpPost("weddings/{weddingId}/destroy")]
    public RedirectToActionResult DeleteWedding(int weddingId)
    {
        Wedding? weddingToDelete = _context.Weddings.SingleOrDefault(w => w.WeddingId == weddingId);
        if (weddingToDelete != null)
        {
            _context.Remove(weddingToDelete);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
    }


    // Toggles whether a person has clicked the RSVP or not.
    [HttpPost("weddings/{weddingId}/rsvp")]
    public IActionResult ToggleAttendence(int weddingId)
    {
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        RSVP? response = _context.RSVPs.FirstOrDefault(r => r.UserId == UserId && r.WeddingId == weddingId);

        if (response == null)
        {
            RSVP newResponse = new() { UserId = UserId, WeddingId = weddingId };
            _context.Add(newResponse);
        }
        else
        {
            _context.Remove(response);
        }
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }
}
