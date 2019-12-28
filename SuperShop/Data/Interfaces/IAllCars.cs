using SuperShop.Controllers;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Interfaces
{
    public interface IAllCars           //интерфейс, реализация в CarRepository
    {
        IEnumerable<Car> Cars { get; }
        
        IEnumerable<Car> GetFavCars { get; }

        Car GetObjectCar(int CarId);
    }
}
