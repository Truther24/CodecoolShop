using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;
using Microsoft.Extensions.Configuration;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        public IEnumerable<Product> GetALlProducts()
        {
            return DatabaseProducts.Products;
        }

        public IEnumerable<Product> GetProductsForCategory(int category_id)
        {
            return DatabaseProducts.Products.Where(product => product.ProductCategory.IntId == category_id).ToList();
        }

        public IEnumerable<Product> GetProductsForSupplier(int supplier_id)
        {
            return DatabaseProducts.Products.Where(product => product.Supplier.IntId == supplier_id).ToList();

        }


    }
}
