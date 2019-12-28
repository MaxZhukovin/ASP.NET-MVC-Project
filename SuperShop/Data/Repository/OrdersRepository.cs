using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Interfaces;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Repository
{
    public class OrdersRepository :IAllOrders
    {
        private readonly AppDbContent appDbContent;

        private readonly ShopCard shopCard;

        public IEnumerable<OrderDetail> Detail => appDbContent.OrderDetail;
        public IEnumerable<Order> orders => appDbContent.order;
        public IEnumerable<Car> cars => appDbContent.car;

        public OrdersRepository(AppDbContent appDbContent, ShopCard shopCard)
        {
            this.appDbContent = appDbContent;
            this.shopCard = shopCard;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDbContent.order.Add(order);

            var items = shopCard.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.car.id,
                    OrderId = order.id,
                    price = el.car.priece
                };
                appDbContent.OrderDetail.Add(orderDetail);
            }

            appDbContent.SaveChanges();

        }
    }
}
