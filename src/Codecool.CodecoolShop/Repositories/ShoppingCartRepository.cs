using Codecool.CodecoolShop.Models;
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
        //private SqlConnection connection;

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
            foreach (Guid eachId in productIds)
            {
                if (eachId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<ShoppingCart> GetAllProductsfromCart()
        {
            var sql = "select p.name ,p.id, p.defaultPrice , sp.quantity , (p.defaultPrice * sp.quantity) as subtotal from Product p\r\nleft join ShoppingCart sp on p.id = sp.productId\r\nwhere sp.quantity is not null\r\norder by subtotal";
            var products = new List<ShoppingCart>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                products = connection.Query<ShoppingCart>(sql).ToList();
            }
            return products;
        }

        public void IncreaseQuantity(Guid id)
        {
            string sql = "update ShoppingCart set quantity = quantity +1 where productId = @id";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }

        }

        public void DecreaseQuantity(Guid id)
        {
            string sql = "update ShoppingCart set quantity = quantity -1 where productId = @id";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }

        }
    }
}