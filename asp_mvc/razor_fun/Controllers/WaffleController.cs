using Microsoft.AspNetCore.Mvc;

namespace razor_fun.Controllers; 

public class WaffleController : Controller
{
    [HttpGet]
    [Route("")]

    public ViewResult Index()
    {
        return View();
    }
}