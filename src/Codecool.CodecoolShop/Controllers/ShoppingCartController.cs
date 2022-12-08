using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Repositories;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        
        
        public Product product = new Product();
        private readonly ShoppingCartRepository shoppingCartRepository;
        public ProductService ProductService { get; set; } = new ProductService();

        public List<Product> products= new List<Product>();

        public ShoppingCartService shoppingCartService= new ShoppingCartService();


        public ShoppingCartController(ShoppingCartRepository shoppingCartRepository)
        {
            
           
            this.shoppingCartRepository = shoppingCartRepository;
         
        }


        [Route("/ShoppingCart")]
        public IActionResult Index()
        {
            ViewBag.id = HttpContext.Session.GetString("id");
            return View(shoppingCartRepository.GetAllProductsfromCart(ViewBag.id));
        }


        

        

        public IActionResult Checkout()
        {
            return View("Checkout", shoppingCartRepository.GetAllProductsfromCart(ViewBag.id = HttpContext.Session.GetString("id")));
        }


        public IActionResult DecreaseQuantity(Guid id)
        {
            shoppingCartRepository.DecreaseQuantity(id);
            return Redirect("/ShoppingCart");
        }

        public IActionResult IncreaseQuantity(Guid id)
        {
            shoppingCartRepository.IncreaseQuantity(id);
            return Redirect("/ShoppingCart");
        }


    }
}
