using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Controllers
{
    public class ShoppingCartController : Controller
    {

        public Product product = new Product();

        public List<Product> products= new List<Product>();

        public ShoppingCartService shoppingCartService= new ShoppingCartService();


        public IActionResult Index()
        {
            return View(DatabaseShoppingCart.shoppingCart);
        }


        

    }
}
