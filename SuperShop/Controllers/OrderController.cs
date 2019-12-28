using Microsoft.AspNetCore.Mvc;
using SuperShop.Data.Interfaces;
using SuperShop.Data.Models;
using SuperShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders AllOrders;

        private readonly ShopCard shopCard;

        public OrderController(IAllOrders AllOrders, ShopCard shopCard)
        {
            this.AllOrders = AllOrders;
            this.shopCard = shopCard;
        }

        //view order
        public ViewResult GetListOrders()             //получить список "нужных" заказов
        {
            
            List<Order> orders = AllOrders.orders.OrderBy(i => i.OrderTime).ToList();
            List<OrderDetail> details = AllOrders.Detail.ToList();
            List<Car> cars = AllOrders.cars.ToList();

            var FullOrders = from det in details
                             join ord in orders on det.OrderId equals ord.id into table1
                             from ord in table1.DefaultIfEmpty()
                             join c in cars on det.CarId equals c.id into table2
                             from c in table2.DefaultIfEmpty()
                             select new OrderListViewModel { GetAllDetail = det, GetAllCars = c, GetAllOrders = ord };

            return View(FullOrders);            //запускаем формирование View
        }





        //add new order
        public IActionResult Checkout(){
            return View();
        }


        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCard.ListShopItems = shopCard.GetShopItems();

            if (shopCard.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Вы ещё ничего  не выбрали");
            }

            if (ModelState.IsValid)
            {
                AllOrders.CreateOrder(order);
                return RedirectToAction("Complete", "Order");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
