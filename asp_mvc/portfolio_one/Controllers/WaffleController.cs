using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace YourNamespace.Controllers;   
public class WaffleController : Controller   // Remember inheritance?    
{      
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public string Index()        
    {            
        return "This is my Index.";        
    }

    [HttpGet] // We will go over this in more detail on the next page    
    [Route("projects")] // We will go over this in more detail on the next page
    public string Projects()        
    {            
        return "These are my Projects.";        
    }

    [HttpGet] // We will go over this in more detail on the next page    
    [Route("contacts")] // We will go over this in more detail on the next page
    public string Contacts()        
    {            
        return "This is my Contact.";        
    }    
}