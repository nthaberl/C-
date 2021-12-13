using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LoginAndReg.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace LoginAndReg.Controllers
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

        [HttpPost("create")]
        public IActionResult CreateUser(User newUser)
        {
            if(ModelState.IsValid)
            {
            // If a User exists with provided email
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                    ModelState.AddModelError("Email", "Email already in use!");
            
                // You may consider returning to the View at this point
                    return View ("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();

                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction ("Success");
            }
            else
            {
                return View("Index");
            }
        }


        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("signin")]
                public IActionResult LoginUser(LoginUser userSubmission)
            {
                if(ModelState.IsValid)
                {
                    // If inital ModelState is valid, query for a user with provided email
                    User userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                    // If no user exists with provided email
                    if(userInDb == null)
                    {
                        // Add an error to ModelState and return to View!
                        ModelState.AddModelError("Email", "Invalid Email/Password");
                        return View("Login");
                    }
                    
                    // Initialize hasher object
                    var hasher = new PasswordHasher<LoginUser>();
                    
                    // verify provided password against hash stored in db
                    var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                    
                    // result can be compared to 0 for failure
                    if(result == 0)
                    {
                        // handle failure (this should be similar to how "existing email" is handled)
                        ModelState.AddModelError("Password", "Incorrect Password");
                        return View ("Login");
                    }

                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return RedirectToAction("Success");
                }
                else
                {
                    return View("Login");
                }
            }


        [HttpGet("success")]
        public IActionResult Success()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }

            return View("Success");
        }


        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
