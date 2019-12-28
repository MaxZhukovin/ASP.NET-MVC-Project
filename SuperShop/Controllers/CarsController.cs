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
    public class CarsController : Controller
    {
        private readonly IAllCars _AllCars;                          //тут храним машины необходимые для отображения
        private readonly ICarsCategory _AllCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategories)    //конструктор
        {
            _AllCars = iAllCars;                                                    //получить все машины и категории 
            _AllCategories = iCarsCategories;                                       //для этих целей используем интерфейсы реализация которых указывается при старте(Startup.cs)
        }

        [Route("Cars/GetListGoods")]
        [Route("Cars/GetListGoods/{category}")]
        public ViewResult GetListGoods(string category)             //получить список "нужных" товаров
        {
            string _category = category;                            
            IEnumerable<Car> cars = null;

            string CurrCategory = "";
            if (string.IsNullOrEmpty(category))             //если категория не указана
            {
                cars = _AllCars.Cars.Where(i => i.available == true).OrderBy(i => i.id);        //вернуть все товары
            }
            else
            {
                if (string.Equals("electro",                            //определяем категорию и выбираем соответствующие товары
                    category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _AllCars.Cars.Where(i => i.Category.CategoryName.Equals("Electromobiles")).Where(i => i.available == true).OrderBy(i => i.id);
                    CurrCategory = "Electromobiles";                //вместо "ViewBag" используем одно из полей класса CarsListViewModels
                }
                else if (string.Equals("fuel",
                        category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _AllCars.Cars.Where(i => i.Category.CategoryName.Equals("Classic")).Where(i=> i.available == true).OrderBy(i => i.id);
                    CurrCategory = "Classic";  
                }
                else if (string.Equals("full",
                       category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _AllCars.Cars.Where(i => i.Category.CategoryName.Equals("full")).Where(i => i.available == true).OrderBy(i => i.id);
                    CurrCategory = "Classic";
                }



            }

            var CarObj = new CarsListViewModels         //формируем обьект для передачи View
            {
                GetAllCars = cars,
                CurrCategory = CurrCategory
            };

            ViewBag.Title = "Page with cars";    //отправляем ViewBag в основную страницу Layout



            return View(CarObj);            //запускаем формирование View
        }
    }
}
