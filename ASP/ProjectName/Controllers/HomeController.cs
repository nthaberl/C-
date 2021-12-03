using Microsoft.AspNetCore.Mvc;

namespace ProjectName.Controllers // using the name of project.controllers is best practice
{
    public class HomeController : Controller //inheriting from controller
    {
        //for each route this controller is to handle
        // [HttpGet] 
        //type of request
        // [Route("")] 
        //associated route string (exclude leading /)

        //now lets condense
        [HttpGet("")]
        public ViewResult Index() //view result means we will always render on this route
        {
            return View("Something");
        }

        [HttpGet("hello/{name}")] //name is route and method parameter
        public string HelloThere(string name)
        {
            return $"Hello there {name}! Welcome~~";
        }

        //REdirecting directly to URL
        [HttpPost("someroute")]


        
        //Redirecting based on the method itself
        [HttpPost("someroute")]

        public RedirectToActionResult RedirectToMethod()
        {
            return RedirectToAction("NameofMethod");
        }

        [HttpGet("some/url/here")]
        public ViewResult NameOfMethod()
        {
            return View();
        }

        [HttpGet("hello/{name}/{quest}/{average_air_velocity_of_african_swallow}")]
        public string TimsRiddle(string name, string quest, int average_air_velocity_of_african_swallow)
        {
            //don't really want this to be a string, would rather have an html page
            return $"Hello {name}, I'm please to hear you're on a quest to {quest}, I don't under why you're you're telling me that a bird can fly {average_air_velocity_of_african_swallow} knots, I'm just an accountant";
        }
    }
}  