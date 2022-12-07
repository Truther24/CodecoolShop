using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.Extensions.Configuration;
using Codecool.CodecoolShop.Repositories;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        public readonly IConfiguration Configuration;

        private readonly ILogger<ProductController> _logger;
        private readonly ProductRepository productRepository;
        private readonly ShoppingCartRepository shoppingCartRepository;
        public ProductService ProductService { get; set; }
        public ShoppingCartService shoppingCartService { get; set; } = new();

        public ProductController(ILogger<ProductController> logger,
            ProductRepository productRepository,
            ShoppingCartRepository shoppingCartRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
            this.shoppingCartRepository= shoppingCartRepository;
            ProductService = new ProductService();
        }

        [HttpGet]
        [Route("/Index")]
        public IActionResult Index()
        {
            /*var products = ProductService.GetProductsForCategory(2);*/
            var products = productRepository.GetAllProducts();
            return View(products.ToList());
        }

        [HttpPost]
        [Route("/Cart")]
        public IActionResult Cart()
        {
            /*var products = ProductService.GetProductsForCategory(2);*/
            var products = ProductService.GetALlProducts(Configuration);
            var aaa = Request.Form["name"];
            return View("Index", products.ToList());
        }

        public IActionResult AddToCart(Guid id)
        {
            shoppingCartRepository.InsertIntoShoppingCart(id);
            
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



        [HttpPost]
        [Route("/Sort")]
        public IActionResult Sort(string amazon, string apple, string lenovo, string tablet, string mouse, string headphones)
        {
            List<Product> returnProducts = new List<Product>();

            var allProducts = productRepository.GetAllProducts();

            if (
                amazon is null && apple is null
                && lenovo is null && tablet is null
                && mouse is null && headphones is null
                )
            {
                return View("Index", allProducts);
            }

            if (amazon == "on")
            {
                var amazonProd = productRepository.GetAmazonSupplierProducts(1);
                foreach (var product in amazonProd)
                {
                    returnProducts.Add(product);
                }
            }

            if (lenovo == "on")
            {
                var amazonProd = productRepository.GetAmazonSupplierProducts(2);
                foreach (var product in amazonProd)
                {
                    returnProducts.Add(product);
                }
            }

            if (apple == "on")
            {
                var amazonProd = productRepository.GetAmazonSupplierProducts(1);
                foreach (var product in amazonProd)
                {
                    returnProducts.Add(product);
                }
            }


            if (tablet == "on")
            {
                var amazonProd = productRepository.GetCategoryProducts(1);
                foreach (var product in amazonProd)
                {
                    returnProducts.Add(product);
                }
            }

            if (headphones == "on")
            {
                var amazonProd = productRepository.GetCategoryProducts(2);

                foreach (var product in amazonProd)
                {
                    returnProducts.Add(product);
                }
            }

            if (mouse == "on")
            {
                var amazonProd = productRepository.GetCategoryProducts(3);
                foreach (var product in amazonProd)
                {
                    returnProducts.Add(product);
                }
            }

            returnProducts = returnProducts.Distinct().ToList();
            return View("Index", returnProducts.ToList());
        }

    }


}
