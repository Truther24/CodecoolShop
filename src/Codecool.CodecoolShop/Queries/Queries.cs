using Codecool.CodecoolShop.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace Codecool.CodecoolShop.Queries
{
    public static class Queries
    {

        private static IConfiguration Configuration;

        public static string ConnectionString => Configuration.GetConnectionString("DefaultConnection");


        public static void GetAllProducts(IConfiguration configuration)
        {
            Configuration = configuration;

            const string sql = @"SELECT *
                                FROM Product
                                ";

            using (var connection = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand(sql, connection);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Guid id = (Guid)reader["id"];

                    string name = (string)reader["name"];

                    decimal defaultPrice = (decimal)reader["defaultPrice"];

                    string currency = reader["currency"] as string;

                    string description = reader["description"] as string;

                    int productCategoryId = (int)reader["productCategoryId"];

                    int supplierId = (int)reader["supplierId"];

                }
            }



            


        }
    }
}
