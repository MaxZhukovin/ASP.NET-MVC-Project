using SuperShop.Data.Interfaces;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                   

                    new Car
                    {
                            name = "Tesla", ShortDescription = "SuperMobile",LongDescription = "",
                            img = "/img/1472042903_31.jpg", priece = 100000, IsFavorite = true, available = true, Category = _carsCategory.AllCategories.First()
                    }


                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }
        
        public Car GetObjectCar(int CarId)
        {
            throw new NotImplementedException();
        }
    }
}
