using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.ViewModels
{
    public class CarsListViewModels                 //класс будет заполнен с конроллера CarsController и передан View "GetListGoods" для формирования 
                                                    //списка товаров, который будет подставлен в RenderBody в основной html странице Layout
    {
        public IEnumerable<Car> GetAllCars { get; set; }

        public string CurrCategory { get; set; }
    }
}
