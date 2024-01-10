using Microsoft.AspNetCore.Mvc;

namespace portfolio_two.Controllers;   
public class WaffleController : Controller
{      
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("projects")]
    public ViewResult Projects()
    {
        return View();
    }

    [HttpGet]
    [Route("contacts")]
    public ViewResult Contact()
    {
        return View();
    }
}