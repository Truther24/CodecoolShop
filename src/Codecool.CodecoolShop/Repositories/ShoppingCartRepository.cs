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
        //private SqlConnection connection;

        public ShoppingCartRepository(IConfiguration _configuration) : base(_configuration)
        {
        }

        public void InsertIntoShoppingCart(Guid id)
        {
            //var sql = $"insert into ShoppingCart(id)\r\nvalues({id})";

            //using (var connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Execute(sql);
            //}


            string sql = "insert into ShoppingCart(id) values(@id)";
            using(var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("id",id);
            command.ExecuteNonQuery();
            }    
        }
    }
}
