using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Models
{
    public class Order
    {

        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(15,MinimumLength = 3)]
        [Required(ErrorMessage ="Длина имени должна содержать не мене 5 символов")]
        public string name { get; set; }

        [Display(Name = "Фамилию")]
        [StringLength(15, MinimumLength = 3)]
        [Required(ErrorMessage = "Длина фамилии должна содержать не мене 5 символов")]
        public string SurName { get; set; }

        [Display(Name = "Аддресс")]
        [StringLength(25, MinimumLength = 10)]
        [Required(ErrorMessage = "Длина строки должна содержать не мене 10 символов")]
        public string adress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Неправильный номер телефон")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина строки не мене 10 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        [Display(Name = "Confirm")]
        public bool confirm { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }
    }
}
