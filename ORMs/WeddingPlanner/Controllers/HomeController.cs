using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using System;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                //check if email is already registered
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }

                //otherwise encrypt password
                PasswordHasher<User> hasher = new PasswordHasher<User>();

                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser login)
        {
            if(ModelState.IsValid)
            {
                User inDb = _context.Users.FirstOrDefault(u => u.Email == login.LoginEmail);

                if(inDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("Index");
                }

                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(login, inDb.Password, login.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Incorrect Password");
                    return View("Index");
                }

                HttpContext.Session.SetInt32("UserId", inDb.UserId);
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("dashboard")]
        public IActionResult Success()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }

            DashboardView ViewModel = new DashboardView
            {
                UserName = _context.Users.FirstOrDefault(u => u.UserId == (int)UserId).FirstName,
                AllWeddings = _context.Weddings.ToList()
            };
            return View(ViewModel);
        }

        [HttpGet("planwedding")]
        public IActionResult PlanWedding()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }

            return View("PlanWedding");
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}