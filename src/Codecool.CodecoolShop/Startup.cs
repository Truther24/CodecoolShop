using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ProductRepository>();
            services.AddScoped<ShoppingCartRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Welcome}/{action=Index}/{id?}");
            });

            //SetupInMemoryDatabases();
        }

        //private void SetupInMemoryDatabases()
        //{
            //Supplier amazon = new Supplier {IntId = 1, Name = "Amazon", Description = "Digital content and services" };
            //DatabaseSupplier.Suppliers.Add(amazon);
            //Supplier lenovo = new Supplier { IntId = 2, Name = "Lenovo", Description = "Computers" };
            //DatabaseSupplier.Suppliers.Add(lenovo);
            //Supplier apple = new Supplier() { IntId = 3, Name = "Apple", Description = "Electronic devices" };
            //DatabaseSupplier.Suppliers.Add(apple);
            //ProductCategory tablet = new ProductCategory { IntId = 1, Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            //ProductCategory computerMouse = new ProductCategory { IntId = 3, Name = "ComputerMouse", Department = "Hardware", Description = "A computer mouse makes your life easier" };
            //ProductCategory headPhones = new ProductCategory { IntId = 2, Name = "Headphones", Department = "Hardware", Description = "You need headphones to listen the music." };
            //DatabaseProductCategory.Products.Add(tablet);
            //DatabaseProductCategory.Products.Add(headPhones);
            //DatabaseProductCategory.Products.Add(computerMouse);
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "amazonFire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Lenovo IdeaPad Mix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Apple Headphones", DefaultPrice = 50.0m, Currency = "USD", Description = "Apple's latest version of headphones", ProductCategory = headPhones, Supplier = apple });
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Lenovo Headphones", DefaultPrice = 30.0m, Currency = "USD", Description = "The most common heaphones", ProductCategory = headPhones, Supplier = lenovo });
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Lenovo Headphones 2", DefaultPrice = 35.0m, Currency = "USD", Description = "Lenovo's new headphones product", ProductCategory = headPhones, Supplier = lenovo });
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Amazon Mouse", DefaultPrice = 39.0m, Currency = "USD", Description = "Amazon product", ProductCategory = computerMouse, Supplier = amazon });
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Apple mouse", DefaultPrice = 99.0m, Currency = "USD", Description = "Apple product", ProductCategory = computerMouse, Supplier = apple });
            //DatabaseProducts.Products.Add(new Product { Id = Guid.NewGuid(), Name = "Lenovo first Edition", DefaultPrice = 59.0m, Currency = "USD", Description = "Lenovo product", ProductCategory = computerMouse, Supplier = lenovo});
        //}
    }
}
