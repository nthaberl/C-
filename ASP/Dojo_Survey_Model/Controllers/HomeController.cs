using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dojo_Survey_Model.Models;

namespace Dojo_Survey_Model.Controllers
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
        public ViewResult Results(Survey result)
        {
            return View(result);
        }
    }
}