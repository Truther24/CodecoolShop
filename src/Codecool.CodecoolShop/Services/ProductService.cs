using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
       
        public IEnumerable<Product> GetALlProducts()
        {
            return DatabaseProducts.Products;
        }




    }
}
