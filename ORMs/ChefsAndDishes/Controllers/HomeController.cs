using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController (MyContext context)
        {
            _context = context;
        }

        //read all chefs
        [HttpGet("")]
        public IActionResult Index()
        {
            IndexView ViewModel = new IndexView()
            {
                AllChefs = _context.Chefs.Include(chef => chef.CreatedDishes).ToList(),
                AllDishes = _context.Dishes.Include(dish => dish.CreatedBy).ToList()
            };
            // ViewBag.ChefCount = _context.Chefs.Include(chef => chef.CreatedDishes).ToList();
            // List<Chef> AllChefs = _context.Chefs.Include(chef => chef.CreatedDishes).ToList();
            return View(ViewModel);
        }

        //read all dishes
        [HttpGet("/dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = _context.Dishes.Include(dish => dish.CreatedBy).ToList();

            return View(AllDishes);
        }

        //Create New Chef Render
        [HttpGet("newchef")]
        public IActionResult NewChef()
        {
            return View();
        }

        // Create New Chef POST
    [HttpPost("createchef")]
    public IActionResult NewChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();

            return RedirectToAction ("Index");
        }
        else
        {
            return View ("NewChef");
        }
    }

    //Create new dish Render
    [HttpGet("dish/new")]
    public IActionResult NewDish()
    {
        Dish newDish = new Dish()
            {
                AllChefs = _context.Chefs.ToList()
            };
        return View(newDish);
    }


    //Create new dish POST
    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();

            return RedirectToAction("Dishes");
        }
        else
        {
            return View ("NewDish");
        }
    }

    }
}

    // {
    //     NewDishView ViewModel = new NewDishView()
    //     {
    //         AllChefs = _context.Chefs.ToList()
    //     };

    //     return View(ViewModel);
    // }