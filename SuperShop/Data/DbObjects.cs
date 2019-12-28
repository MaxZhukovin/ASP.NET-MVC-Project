using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SuperShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContent content)
        {

          

            if (!content.category.Any())

                content.category.AddRange(Categories.Select(c => c.Value));
           
            if (!content.car.Any())
            {
                content.AddRange(

                  new Car
                  {
                      name = "Tesla",
                      ShortDescription = "SuperMobile",
                      LongDescription = "",
                      img = "/img/BMW_3.jpg.jpg",
                      priece = 100000,
                      IsFavorite = true,
                      available = true,
                      Category = Categories["Electromobiles"]
                  },

                    new Car
                    {
                        name = "Tesla",
                        ShortDescription = "SuperMobile",
                        LongDescription = "",
                        img = "/img/BMW_3.jpg.jpg",
                        priece = 100000,
                        IsFavorite = true,
                        available = true,
                        Category = Categories["Electromobiles"]
                    },

                    new Car
                    {
                        name = "Tesla",
                        ShortDescription = "SuperMobile",
                        LongDescription = "",
                        img = "/img/BMW_3.jpg.jpg",
                        priece = 100000,
                        IsFavorite = true,
                        available = true,
                        Category = Categories["Electromobiles"]
                    },

                    new Car
                    {
                        name = "Tesla",
                        ShortDescription = "SuperMobile",
                        LongDescription = "",
                        img = "/img/BMW_3.jpg.jpg",
                        priece = 100000,
                        IsFavorite = true,
                        available = true,
                        Category = Categories["Electromobiles"]
                    },

                    new Car
                    {
                        name = "Tesla",
                        ShortDescription = "SuperMobile",
                        LongDescription = "",
                        img = "/img/BMW_3.jpg.jpg",
                        priece = 100000,
                        IsFavorite = true,
                        available = true,
                        Category = Categories["Electromobiles"]
                    },

                    new Car
                    {
                        name = "Tesla",
                        ShortDescription = "SuperMobile",
                        LongDescription = "",
                        img = "/img/BMW_3.jpg.jpg",
                        priece = 100000,
                        IsFavorite = true,
                        available = true,
                        Category = Categories["Electromobiles"]
                    },

                    new Car
                    {
                        name = "Tesla",
                        ShortDescription = "SuperMobile",
                        LongDescription = "",
                        img = "/img/BMW_3.jpg.jpg",
                        priece = 100000,
                        IsFavorite = true,
                        available = true,
                        Category = Categories["Electromobiles"]
                    }




                );
            }

            content.SaveChanges();
        }


        public static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                          new Category{ CategoryName = "Electromobiles", description = "Uses power for movement"},
                          new Category{ CategoryName = "Classic", description = "Uses fuel for movement"}

                    };

                    category = new Dictionary<string, Category>();

                    foreach (Category element in list)
                        category.Add(element.CategoryName, element);
                }

                return category;
            }

          
        }
         
    }
}
