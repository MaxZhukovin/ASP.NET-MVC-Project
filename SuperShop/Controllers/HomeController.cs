using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SuperShop.Data;
using SuperShop.Data.Interfaces;
using SuperShop.Data.Models;
using SuperShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperShop;
using Microsoft.EntityFrameworkCore;

namespace SuperShop.Controllers
{
    public class HomeController : Controller        //это контроллер по умолчанию он вызывается при старте программы
    {

        private readonly IAllCars _CarRep;          

        public HomeController(IAllCars CarRep)
        {
            _CarRep = CarRep;                        //получить данные с БД
        }

        public ViewResult Index()                   //получить авто с флагом IsFavorite = true
        {
            var HomeCars = new HomeViewModel
            {
                favCars = _CarRep.GetFavCars
            };

            return View(HomeCars);              //вернуть товары 
        }

        public ViewResult Main()                   //получить авто с флагом IsFavorite = true
        {
            

            return View();              //вернуть товары 
        }

        //перейти к view game
        public ViewResult Game()
        {
            return View();
        }



    }
}
