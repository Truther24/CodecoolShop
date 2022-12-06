using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace Codecool.CodecoolShop.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(IConfiguration _configuration) : base(_configuration)
        {
        }

        public List<Product> GetAllProducts()
        {
            var sql = "select p.name , p.defaultPrice, p.currency , p.description , s.name as supplierName , pr.name as CategoryName from Product p \r\ninner join Supplier s on p.supplierId = s.id\r\ninner join ProductCategory pr on p.productCategoryId = pr.id";
            var products = new List<Product>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                products = connection.Query<Product>(sql).ToList();
            }
            return products;
        }


        public List<Product> GetAmazonSupplierProducts()
        {
            var sql = "select p.name , p.defaultPrice, p.currency , p.description , s.name as supplierName , pr.name as CategoryName from Product p \r\ninner join Supplier s on p.supplierId = s.id\r\ninner join ProductCategory pr on p.productCategoryId = pr.id\r\nwhere s.id = 1";
            var products = new List<Product>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                products = connection.Query<Product>(sql).ToList();
            }
            return products;
        }


    }
}
