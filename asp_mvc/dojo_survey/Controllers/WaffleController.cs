using Microsoft.AspNetCore.Mvc;

namespace portfolio_two.Controllers;

public class WaffleController : Controller
{      
    [HttpGet]
    [Route("")]
    public ViewResult Form()
    {
        return View();
    }

    [HttpPost]
    [Route("process")]
    public RedirectToActionResult Process(string Name, string Location, string Language, string Comment)
    {
        Console.WriteLine($"Name: {Name} Location: {Location} Language: {Language} Comment: {Comment}");
        return RedirectToAction("Params", new {name=Name, location=Location, language=Language, comment=Comment });
    }

    [HttpGet("param/{name}/{location}/{language}/{comment}")]
    public ViewResult Params(string name, string location, string language, string comment)
    {
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.Language = language;
        ViewBag.Comment = comment;


        return View();
    }
}