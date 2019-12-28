using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Models
{
    public class Car
    {


        public int id { set; get; }

        [Display(Name = "Название")]
        [StringLength(30, MinimumLength = 5)]
        [Required(ErrorMessage = "Длина от 5 до 30 символов")]
        public string name { set; get; }

        [Display(Name = "Краткое описание")]
        [Required(ErrorMessage = "Длина от 5 до 100 символов")]
        public string ShortDescription { set; get; }

        [Display(Name = "Полное описание")]
        [StringLength(1000, MinimumLength = 5)]
        [Required(ErrorMessage = "Длина от 5 до 1000 символов")]
        public string LongDescription { set; get; }

        [Display(Name = "image")]
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Длина от 5 до 50 символов")]
        public string img { set; get; }

        [Display(Name = "Цена")]
        [Range(1, 17000000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public uint priece { set; get; }

        [Display(Name = "Товар будет отображаться на главной странице")]
        public bool IsFavorite { set; get; }

        [Display(Name = "Доступность товара")]
        public bool available { set; get; }
        

        public int CategoryId { set; get; }
        
        public virtual Category Category { set; get; }

    }
}
