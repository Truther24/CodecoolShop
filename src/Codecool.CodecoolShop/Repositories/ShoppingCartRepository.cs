using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Repositories.Codecool.CodecoolShop.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Codecool.CodecoolShop.Repositories
{
    public class ShoppingCartRepository : BaseRepository
    {
        public ShoppingCartRepository(IConfiguration _configuration) : base(_configuration)
        {

        }

        public void InsertIntoShoppingCart(Guid id)
        {
            bool productAlreadyExistsInCart = CheckIfProductExistsInCart(id);
            string sql = "";
            if (productAlreadyExistsInCart)
            {
                sql = "update ShoppingCart set quantity = quantity +1 where productId = @id";
            }
            else
            {

                sql = "insert into ShoppingCart(productId, quantity) values(@id, 1)";
            }
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private bool CheckIfProductExistsInCart(Guid id)
        {
            var sql = "select sp.productId from ShoppingCart sp";
            var productIds = new List<Guid>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                productIds = connection.Query<Guid>(sql).ToList();
            }
            foreach(Guid eachId in productIds)
            {
                if(eachId == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
