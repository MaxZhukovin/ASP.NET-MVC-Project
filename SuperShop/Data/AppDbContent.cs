using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SuperShop.Data
{
    public class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) 
            : base(options)
        {

        }
       
       

        public DbSet<Car> car { get; set; }

        public DbSet<Category> category { get; set; }

        public DbSet<ShopCardItem> ShopCardItem { get; set; }

        public DbSet<Order> order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<CarDetails> CarDetails { get; set; }

    }
}
