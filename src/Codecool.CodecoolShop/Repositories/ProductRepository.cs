using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using Codecool.CodecoolShop.Repositories.Codecool.CodecoolShop.Repositories;

namespace Codecool.CodecoolShop.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(IConfiguration _configuration) : base(_configuration)
        {
        }

        public List<Product> GetAllProducts()
        {
            var sql = "select * from product";
            var products = new List<Product>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                products = connection.Query<Product>(sql).ToList();
            }
            return products;
        }
    }
}