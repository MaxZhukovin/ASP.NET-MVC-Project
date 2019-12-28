using SuperShop.Data.Interfaces;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ CategoryName = "Electromobiles", description = "Uses power for movement"},
                    new Category{ CategoryName = "Classic", description = "Uses fuel for movement"}

                };
            }
        }
    }
}
