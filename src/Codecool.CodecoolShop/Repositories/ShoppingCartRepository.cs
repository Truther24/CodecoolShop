using Codecool.CodecoolShop.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Codecool.CodecoolShop.Repositories
{
    public class ShoppingCartRepository : BaseRepository
    {
        public ShoppingCartRepository(IConfiguration _configuration) : base(_configuration)
        {
        }

        public void InsertIntoShoppingCart(Guid id)
        {
            var sql = $"insert into ShoppingCart(id)\r\nvalues({id})";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql);
            }

        }
    }
}
