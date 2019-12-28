using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperShop.Data;
using SuperShop.Data.Interfaces;
using SuperShop.Data.Mocks;
using SuperShop.Data.Models;
using SuperShop.Data.Repository;

namespace SuperShop
{
    public class Startup
    {
        static public IConfigurationRoot _confstring;
        public IHostingEnvironment HostEnviroment;
        public Startup(IHostingEnvironment HostEnv) 
        {
            HostEnviroment = HostEnv;
            _confstring = new ConfigurationBuilder().SetBasePath(HostEnv.ContentRootPath).AddJsonFile("DbSettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IAllCarDetails, CarDetailsRepository>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp =>ShopCard.GetCard(sp));

            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public AppDbContent content;

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();

                app.UseSession();

            //app.UseMvcWithDefaultRoute();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Main}/{id?}");
                    routes.MapRoute(name: "CategoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "GetListGoods" });
                });
                
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                    DbObjects.Initial(content);
                }

              
            
        }
    }
}
