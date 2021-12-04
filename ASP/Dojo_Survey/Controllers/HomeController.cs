using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Dojo_Survey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            // ViewBag.ListOfLocations = new List<string>()
            // {
            //     "Seattle",
            //     "Portland",
            //     "San Jose",
            //     "Boise",
            // };

            // ViewBag.ListOfLanguages = new List<string>()
            // {
            //     "C# (obvi)",
            //     "Java",
            //     "1337",
            // };

            return View();
        }

        // [HttpGet("results")]
        // public ViewResult Result()
        // {
        //     return View();
        // }

        [HttpPost("submit")]

        public ViewResult Results(string name, string location, string language, string comments)
        {
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comments = comments;
            return View();
        }
    }
}