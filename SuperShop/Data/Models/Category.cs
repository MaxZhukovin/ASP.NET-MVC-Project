using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Models
{
    public class Category
    {
        public int id { set; get; }
        
        public string CategoryName { set; get; }
        
        public string description { set; get; }
        
        public List<Car> cars { set; get; }
    }
}
