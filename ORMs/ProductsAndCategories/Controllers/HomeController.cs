using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
        {
            private MyContext _context;
            public HomeController(MyContext context)
                {
                    _context = context;
                }

                //redirects directly to products page 
                [HttpGet("")]
                public IActionResult Index(){
                    return RedirectToAction ("Products");
                }

                //READ ALL + CREATE PRODUCT RENDER
                [HttpGet("products")]
                public IActionResult Products()
                {
                    ViewBag.ListProducts = _context.Products.ToList();

                    return View("Products");
                }

                //ADD PRODUCT POST ROUTE
                [HttpPost("products/create")]
                public IActionResult newProduct(Product newProduct)
                {
                if (ModelState.IsValid)
                {
                    _context.Add(newProduct);
                    _context.SaveChanges();

                    return RedirectToAction ("Products");
                }
                else
                {
                    ViewBag.ListProducts = _context.Products.ToList(); //need to add viewbag here again otherwise will trip up foreach code in View
                    return View("Products");
                }
                }

                //READ ONE + UPDATE RENDER - PRODUCT
                [HttpGet("products/{productId}")]
                // public IActionResult ProductInfo(int productId)
                // {
                //     List<Product> CatOnProd = _context.Products.Include(c=>c.Categories).ThenInclude(c=>c.Product).ToList(); //rendering categories attached to product
            
                //     // ViewBag.AllCategories=_context.Categories.ToList();
                //     ViewBag.NotOnProduct = _context.Categories.Include(c => c.Products).Where(c => c.Products.All(a => a.ProductId != productId)).ToList(); // 
                //     //
                //     Product updateProd = _context.Products.Include(p=>p.Categories).ThenInclude(a=>a.Category).FirstOrDefault(p=>p.ProductId == productId);
                //     // access list from inside product class, theninclude category navigator, firstordefault productID in category table

                //     // ViewBag.productId = productId;

                //     return View("ProductInfo", updateProd);
                // }

                public IActionResult ProductInfo(int productId)
                {
                    ProductInfoView ViewModel = new ProductInfoView()
                    {
                        ToRender = _context.Products.Include(p => p.Categories).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == productId),
                        ToAdd = _context.Categories.Include(c => c.Products).Where(a => !a.Products.Any(cat => cat.ProductId == productId)).ToList()
                    };

                    return View("ProductInfo", ViewModel);
                }

                //UPDATE PRODUCT
                [HttpPost("products/update/{productId}")]
                public IActionResult UpdateProduct(int productId, ProductInfoView viewModel)
                {
                    if (ModelState.IsValid)
                    {
                        Association toAdd = viewModel.AddForm;
                        _context.Add(toAdd);
                        _context.SaveChanges();

                        return RedirectToAction("ProductInfo", new {productId = productId});
                    }
                    else
                    {
                        return ProductInfo(productId);
                    }
                }


                //READ ALL + ADD CATEGORY RENDER
                [HttpGet("categories")]
                public IActionResult Categories()
                {
                    ViewBag.ListCategories = _context.Categories.ToList();
                    return View("Categories");
                }


                //ADD POST ROUTE
                [HttpPost("categories/create")]
                public IActionResult newCategory(Category newCategory)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(newCategory);
                        _context.SaveChanges();

                        return RedirectToAction ("Categories");
                    }
                    else
                    {
                        ViewBag.ListCategories = _context.Categories.ToList();
                        return View("Categories");
                    }
                }

                //READ ONE + UPDATE RENDER
                [HttpGet("categories/{categoryId}")]
                public IActionResult CategoryInfo(int categoryId)
                {
                    CategoryInfoView ViewModel = new CategoryInfoView()
                    {
                        ToRender = _context.Categories.Include(p => p.Products).ThenInclude(a => a.Product).FirstOrDefault(p => p.CategoryId == categoryId),
                        ToAdd = _context.Products.Include(c => c.Categories).Where(a => !a.Categories.Any(cat => cat.CategoryId == categoryId)).ToList()
                    };

                    return View("CategoryInfo", ViewModel);
                }


                //UPDATE CATEGORY POST 
                [HttpPost("categories/update/{categoryId}")]
                public IActionResult UpdateCategory(int categoryId, CategoryInfoView viewModel)
                {
                    if (ModelState.IsValid)
                    {
                        Association toAdd = viewModel.AddForm;
                        _context.Add(toAdd);
                        _context.SaveChanges();

                        return RedirectToAction("CategoryInfo", new {categoryId = categoryId});
                    }
                    else
                    {
                        return CategoryInfo(categoryId);
                    }
                }
        }
}