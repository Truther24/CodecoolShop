using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;
using Codecool.CodecoolShop.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Repositories
{
    public class RegisterRepository : BaseRepository
    {
        public RegisterRepository(IConfiguration _configuration) : base(_configuration)
        {
        }


        public void InsertUserIntoDb(string username, string password)
        {
            string sql = "insert into [User] (id,email,password) values (NEWID(),@username,@password)";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                command.ExecuteNonQuery();
            }
            
        }

        public bool IsUserRegistered(string username, string password)
        {
            var sql = "select u.id,u.email, u.password from [User] u";
            var users = new List<User>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                users = connection.Query<User>(sql).ToList();
            }
            foreach (var user in users)
            {
                if (user.email == username && user.password == password)
                {
                    
                    return true;
                }


            }
            return false;


        }


        public Guid GetUSerId(string username, string password)
        {
            var sql = "select u.id,u.email, u.password from [User] u";
            var users = new List<User>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                users = connection.Query<User>(sql).ToList();
            }
            foreach (var user in users)
            {
                if (user.email == username && user.password == password)
                {

                    return user.id;
                }


            }

            return Guid.Empty;

        }


    }
}
