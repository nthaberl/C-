using System;
using Microsoft.AspNetCore.Mvc;
namespace Time_Display.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet("")]       //type of request
        public ViewResult Index() //ViewResult means we will always render on this route
        {
            DateTime aDate = DateTime.Now;
            
            return View();
        }
    }
}

