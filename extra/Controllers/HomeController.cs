using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using extra.Models;

namespace extra.Controllers;

public static Game[] AllGames = new Game[] {
    new Game {Title="Elden Ring", Price=59.99, Genre="Action RPG", Rating="M", Platform="PC"},
    new Game {Title="League of Legends", Price=0.00, Genre="MOBA", Rating="T", Platform="PC"},
    new Game {Title="Chivalry II", Price=39.99, Genre="Hack & Slash", Rating="M", Platform="PC, PS4, PS5, Xbox One, Xbox Series X/S"},
    new Game {Title="Baldur's Gate 3", Price=59.99, Genre="RPG", Rating="M", Platform="PC"},
    new Game {Title="PUBG", Price=0.00, Genre="Action BR", Rating="M", Platform="PC"},
    new Game {Title="World of Warcraft", Price=39.99, Genre="MMORPG", Rating="T", Platform="PC"},
    new Game {Title="Elder Scrolls Skyrim", Price=9.99, Genre="Action RPG", Rating="M", Platform="PC"},
    new Game {Title="Smite", Price=0.00, Genre="MOBA", Rating="T", Platform="All"},
    new Game {Title="Stardew Valley", Price=14.99, Genre="RPG", Rating="E", Platform="PC, PS4, Xbox One, Switch, iOS, Android"},
    new Game {Title="Overwatch", Price=39.00, Genre="First-person Shooter", Rating="T", Platform="PC"},
    new Game {Title="Overwatch 2", Price=0.00, Genre="Disappointment", Rating="T", Platform="PC, Console"},
    new Game {Title="Scarlet Nexus", Price=59.99, Genre="Action JRPG", Rating="T", Platform="All"},
    new Game {Title="Wonderlands", Price=59.99, Genre="RPG FPS", Rating="M", Platform="All"},
    new Game {Title="Rocket League", Price=0.00, Genre="Sports", Rating="E", Platform="All"},
    new Game {Title="StarCraft", Price=0.00, Genre="RTS", Rating="T", Platform="PC"},
    new Game {Title="God of War", Price=29.99, Genre="Action-adventure ", Rating="M", Platform="PC"},
    new Game {Title="Doki Doki Literature Club Plus!", Price=10.00, Genre="Casual", Rating="E", Platform="PC"},
    new Game {Title="Red Dead Redemption", Price=40.00, Genre="Action adventure", Rating="M", Platform="All"},
    new Game {Title="My Little Pony A Maretime Bay Adventure", Price=39.99, Genre="Adventure", Rating="E",Platform="All"},
    new Game {Title="Fallout New Vegas", Price=10.00, Genre="Open World RPG", Rating="M", Platform="PC"}
};


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // all games
        List<Game> allGamesFromData = AllGames.OrderBy(s => s.Title).OrderByDescending(d => d.Price).ToList();
        ViewBag.AllGames = allGamesFromData;

        List<Game> allPlatforms = AllGames.Where(f => f.Platform == "All" || f.Rating == "T").ToList;
        ViewBag.allPlatforms = allPlatforms;

        List<Game> topMGames = AllGames.Where(a => a.Rating == "M").OrderBy(s => s.Price).Take(4).ToList;
        ViewBag.topMGames = topMGames;

        Game singleGame = AllGames.FirstOrDefault(r => r.Title == "Rocket League");
        ViewBag.singleGame = singleGame;
        return View();
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
