using Microsoft.EntityFrameworkCore;
using SuperShop.Controllers;
using SuperShop.Data.Interfaces;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Repository
{
    public class CarRepository : IAllCars                   //класс служит для "вытаскивания" данных из БД
    {
        private readonly AppDbContent appDbContent;

        public CarRepository(AppDbContent appDbContent)     //взять данные у БД, конструктор
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Car> Cars => appDbContent.car.Include(c => c.Category);  //Выбираем все товары с указаной категорией




        public IEnumerable<Car> GetFavCars => appDbContent.car.Where(p => p.IsFavorite).Include(c => c.Category); //выбираем только лучшие авто(флаг IsFavorite в БД таблица Car)

        public Car GetObjectCar(int CarId) => appDbContent.car.FirstOrDefault(p => p.id == CarId);
       
    }
}
