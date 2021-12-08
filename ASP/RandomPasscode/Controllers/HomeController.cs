using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; //This is where session comes from

namespace RandomPasscode.Controllers
{
    public class Homecontroller : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count") == null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            int? count = HttpContext.Session.GetInt32("Count");

            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var charsarr = new char[14];
            var random = new Random();

            for (int i = 0; i < charsarr.Length; i++)
            {
                charsarr[i] = characters[random.Next(characters.Length)];
            }

            var passcode = new String(charsarr);
            ViewBag.Passcode = passcode;
            ViewBag.SessionCount = count;
            
            return View();
        }

        [HttpGet("add_session")]
        public IActionResult AddSession()
        {
            int? count = HttpContext.Session.GetInt32("Count");
            count++;
            HttpContext.Session.SetInt32("Count", (int) count);
            return RedirectToAction("Index");
        }
    }
}