using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }
        public ShoppingCartService shoppingCartService { get; set; } = new();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService();
        }

        [HttpGet]
        [Route("/Index")]
        public IActionResult Index()
        {
            /*var products = ProductService.GetProductsForCategory(2);*/
            var products = ProductService.GetALlProducts();
            return View(products.ToList());
        }

        [HttpPost]
        [Route("/Cart")]
        public IActionResult Cart()
        {
            /*var products = ProductService.GetProductsForCategory(2);*/
            var products = ProductService.GetALlProducts();
            var aaa = Request.Form["name"];
            return View("Index", products.ToList());
        }

        public IActionResult AddToCart(Guid id)
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
            return Redirect("/Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        /*[HttpPost]
        public IActionResult GetData()
        {
            string nname = Request.Form["name"];
            return View("Index",nname);
        }*/

    }


}
