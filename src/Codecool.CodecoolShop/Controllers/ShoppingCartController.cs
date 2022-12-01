using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Controllers
{
    public class ShoppingCartController : Controller
    {

        public Product product = new Product();

        public ProductService ProductService { get; set; } = new ProductService();

        public List<Product> products= new List<Product>();

        public ShoppingCartService shoppingCartService= new ShoppingCartService();


        public IActionResult Index()
        {
            return View(DatabaseShoppingCart.shoppingCart);
        }


        public IActionResult IncreaseQuantity(Guid id)
        {
            var products = ProductService.GetALlProducts();
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    shoppingCartService.AddProductToCart(product);
                    break;
                }
            }
            return Redirect("/ShoppingCart");
        }

        public IActionResult DecreaseQuantity(Guid id)
        {
            var products = ProductService.GetALlProducts();
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    shoppingCartService.RemoveProductFromCart(product);
                    break;
                }
            }
            return Redirect("/ShoppingCart");
        }

        public IActionResult Checkout()
        {
            return View("Checkout", DatabaseShoppingCart.shoppingCart);
        }


    }
}
