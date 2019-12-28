using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Interfaces
{
    public interface IAllOrders
    {
        IEnumerable<Order> orders { get; }
        IEnumerable<OrderDetail> Detail { get; }
        IEnumerable<Car> cars { get; }

        void CreateOrder(Order order);
    }
}
