using Microsoft.AspNetCore.Mvc;
namespace Razor_Fun.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet("")]       //type of request
        public ViewResult Index()
        {
            return View();
        }
    }
}

