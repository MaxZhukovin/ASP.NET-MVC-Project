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
    public class ShopCardController : Controller            //отвечает за отображение товаров в корзине, вызов при обращении к корзине
    {

        private readonly IAllCars _CarRep;                  
        private readonly ShopCard _ShopCard;

        public ShopCardController(IAllCars CarRep, ShopCard ShopCard)
        {
            _CarRep = CarRep;
            _ShopCard = ShopCard;
        }

        public ViewResult Index()
        {
            var items = _ShopCard.GetShopItems();
            _ShopCard.ListShopItems = items;
            var obj = new ShopCardViewModel
            {
                shopCard = _ShopCard
            };
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _CarRep.Cars.FirstOrDefault( i => i.id == id);
            if(item != null)
            {
                _ShopCard.AddToCard(item);
            }
            return RedirectToAction("Index");
        }

    }
}
