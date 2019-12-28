using SuperShop.Data.Interfaces;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Repository
{
    public class CarDetailsRepository : IAllCarDetails
    {
        private readonly AppDbContent appDbContent;

        public IEnumerable<CarDetails> Detail => appDbContent.CarDetails;

        public IEnumerable<Car> cars => appDbContent.car;

        public CarDetailsRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
    }
}
