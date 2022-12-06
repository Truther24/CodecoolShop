namespace Codecool.CodecoolShop.Repositories
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data.SqlClient;

    namespace Codecool.CodecoolShop.Repositories
    {
        public class BaseRepository
        {

            private IConfiguration Configuration;

            public BaseRepository(IConfiguration _configuration)
            {
                Configuration = _configuration;
            }

            public string ConnectionString => Configuration.GetConnectionString("DefaultConnection");



        }
    }
}
