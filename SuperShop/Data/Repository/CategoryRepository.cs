using SuperShop.Data.Interfaces;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDbContent appDbContent;

        public CategoryRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories =>appDbContent.category;
    }
}
