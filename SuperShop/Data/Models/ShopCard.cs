using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Models
{
    public class ShopCard
    {
        private readonly AppDbContent appDbContent;

        public ShopCard(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public string ShopCardId { get; set; }

        public List<ShopCardItem> ListShopItems { get; set; }
    
        public static ShopCard GetCard(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            
            var context = service.GetService<AppDbContent>();
            
            string ShopCardId = session.GetString("CardId") ?? Guid.NewGuid().ToString();
            
            session.SetString("CardId", ShopCardId);

            return new ShopCard(context) { ShopCardId = ShopCardId };
        }

        public void AddToCard(Car car)
        {
            appDbContent.ShopCardItem.Add(new ShopCardItem
            {
                ShopCardId = ShopCardId,
                car = car,
                priece = Convert.ToInt32(car.priece)
            });

            appDbContent.SaveChanges();
        }

        public List<ShopCardItem> GetShopItems()
        {
            return appDbContent.ShopCardItem.Where(c => c.ShopCardId == ShopCardId).Include(s => s.car).ToList();
        }

    }
}
