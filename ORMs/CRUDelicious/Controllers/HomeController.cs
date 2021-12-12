using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CRUDelicious.Controllers
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
            IEnumerable<Dish> AllDishes = _context.Dishes.OrderByDescending(dish => dish.CreatedAt).ToList();
            return View(AllDishes);
        }

        //Create - Render
        [HttpGet("new")]
        public IActionResult CreateDish()
        {
            return View();
        }

        //Create - Post
        [HttpPost("create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();

                return RedirectToAction ("DishInfo", new {dishId = newDish.DishId});
            }
            else
            {
                return View("CreateDish");
            }
        }

        //Read - One
        [HttpGet("{dishId}")]
        public IActionResult DishInfo(int dishId)
        {
            //need to pull a single dish from the database
            //_context.Dishes = All dishes in database
            Dish toRender = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            return View(toRender);
        }

        //Update - Render
        [HttpGet("edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish toEdit = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            //next block prevents an error if the dishId is manually typed into the URL and it doesn't actually exist :)
            if (toEdit == null)
            {
                return RedirectToAction("Index");
            }

            return View("EditDish", toEdit);
        }

        //Update - Post
        [HttpPost("update/{dishId}")]
        public IActionResult UpdateDish(int dishId, Dish editDish)
        {
            if(ModelState.IsValid)
            {
                Dish inDataBase = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

                inDataBase.Name = editDish.Name;
                inDataBase.Chef = editDish.Chef;
                inDataBase.Tastiness = editDish.Tastiness;
                inDataBase.Calories = editDish.Calories;
                inDataBase.Description = editDish.Description;
                inDataBase.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return RedirectToAction("DishInfo", new {dishId = dishId});
            }
            else
            {
                return EditDish(dishId);
            }
        }


        //Delete
        [HttpGet("delete/{dishId}")]
        public RedirectToActionResult DeleteRecipe(int dishId)
        {
            Dish toDelete = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            _context.Dishes.Remove(toDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}