using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Interfaces
{
    public interface IAllCarDetails
    {
        IEnumerable<CarDetails> Detail { get; }
        IEnumerable<Car> cars { get; }
    }
}
