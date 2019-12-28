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
    public class CarsDetailController : Controller
    {
        private readonly IAllCarDetails _CarRep;

        public CarsDetailController(IAllCarDetails _CarRep)
        {
            this._CarRep = _CarRep;
        }
        public ViewResult MoreDetail(int id)
        {
            


                CarDetails details = _CarRep.Detail.FirstOrDefault(i => i.CarId == id);
                Car cars = _CarRep.cars.FirstOrDefault(i => i.id == id);
                var FullCarDesc = new CarDetailsViewModels
                {
                    GetAllCars = cars,
                    GetAllDetails = details
                };

                return View(FullCarDesc);            //запускаем формирование View

        }

    }
}
