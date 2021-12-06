using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dojo_Survey_Validation.Models;

namespace Dojo_Survey_Validation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("submit")]

        //utilizing a contructor
        // public ViewResult Results(string name, string location, string language, string comments)
        // {

        //     Survey fromForm = new Survey(name, location, language, comments);
        //     return View(fromForm);
        // }
        public IActionResult Results(Survey result)
        {
            if(ModelState.IsValid)
            {
                return View(result);
            }
            else
            {
                return View("Index");
            }
        }
    }
}