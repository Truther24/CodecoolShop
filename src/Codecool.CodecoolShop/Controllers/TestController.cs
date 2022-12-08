using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Codecool.CodecoolShop.Controllers
{
    public class TestController : Controller
    {

        private IConfiguration Configuration;

        public TestController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public string ConnectionString => Configuration.GetConnectionString("DefaultConnection");

        public bool TestConnection()
        {
            using var connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private void EnsureConnectionSuccessful()
        {
            if (!TestConnection())
            {
                Environment.Exit(1); // if we cannot connect to DB we terminate the app
            }

        }
        public IActionResult Index()
        {
            EnsureConnectionSuccessful();
            return View();
        }
    }


}
