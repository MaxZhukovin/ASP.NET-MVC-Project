using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Models
{
    public class Account
    {
        [Display(Name = "Your login")]
        public string Login { set; get; }

        [Display(Name = "Your password")]
        public string Password { set; get; }


      
    }
}
