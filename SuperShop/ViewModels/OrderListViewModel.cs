using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.ViewModels
{
    public class OrderListViewModel
    {
        public Order GetAllOrders { get; set; }

        public OrderDetail GetAllDetail { get; set; }

        public Car GetAllCars{ get; set; }
    }
}
