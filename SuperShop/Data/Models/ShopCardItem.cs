using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Models
{
    public class ShopCardItem
    {
        public int id { get; set; }
        
        public Car car { get; set; }

        public int priece { get; set; }
        
        public string ShopCardId { get; set; }
    }
}
