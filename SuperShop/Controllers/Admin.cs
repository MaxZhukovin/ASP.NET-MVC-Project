using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data;
using SuperShop.Data.Models;
using SuperShop.Data.Repository;
using SuperShop.Email;
using SuperShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Controllers
{
    
    public class Admin : Controller 
    {

        //login 
        private string login = "admin";
        private string password = "12345";

        public ViewResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(Account acc)
        {
            if (acc.Login == this.login && acc.Password == this.password)
            {
                return RedirectToAction("AdminPanel", "Admin");
            }

            return RedirectToAction("FailAuthentication", "Admin");
        }

        public IActionResult AdminPanel()
        {
            ViewBag.Message = "Admin - panel";
            return View();
        }

        public IActionResult FailAuthentication()
        {
            ViewBag.Message = "Fail Authentication";
            return RedirectToAction("LogIn", "Admin");
        }

        private AppDbContent db;
        //change goods

        public IActionResult Change(int? CarId)
        {
            CarId = 2;
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContent>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options;


             this.db = new AppDbContent(options);
  
            Car car = db.car.FirstOrDefault(g => g.id == CarId);

            IEnumerable < Car >  cars= db.car;

            var CarObj = new CarsListViewModels         //формируем обьект для передачи View
            {
                GetAllCars = cars,
                CurrCategory = ""
            };

            return View(CarObj);
        }

        [HttpPost]
        public IActionResult CompleteChange(Car car)
        {
            var existingBlog = new Car { };
            existingBlog = car;
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContent>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options;


            this.db = new AppDbContent(options);
           
                db.Entry(existingBlog).State = EntityState.Modified;

                // Do some more work...  

                db.SaveChanges();
            

            

            ViewBag.Message = "Товар успешно обновлён";
            return RedirectToAction("AdminPanel", "Admin");
        }







        //add cars
        public ViewResult Add()                   //получить авто с флагом IsFavorite = true
        {

            return View();              //вернуть товары 
        }

        [HttpPost]
        public IActionResult Add(Car car)           
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContent>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options;

            using (AppDbContent db = new AppDbContent(options))
            {
                if (ModelState.IsValid)
                {
                    db.car.Add(
                    new Car
                    {
                        name = car.name,
                        ShortDescription = car.ShortDescription,
                        LongDescription = car.LongDescription,
                        img = car.img,
                        priece = car.priece,
                        IsFavorite = car.IsFavorite,
                        available = car.available,
                        CategoryId = car.CategoryId
                    }
                    );
                    db.SaveChanges();
                    return RedirectToAction("Complete", "Admin");
                }
            }
            return View();
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Товар успешно добавлен";
            return View();
        }

        public IActionResult ConfirmOrder(string[] items, int OrderId, int CarId)
        {
            

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContent>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options;

            using (AppDbContent db = new AppDbContent(options))
            {
               

                    var order = db.order
                    // Загрузить заказ
                    .Where(c => c.id == OrderId)
                    .FirstOrDefault();

                    // Внести изменения
                    order.confirm = true;

                    var car = db.car
                    .Where(c => c.id == CarId)
                    .FirstOrDefault();

                     car.available = false;    

                    db.SaveChanges();
                    
                
            }



            return RedirectToAction("GetListOrders", "Order");
        }

        public IActionResult CancelOrder(string[] items, int OrderId, int CarId)
        {


            var optionsBuilder = new DbContextOptionsBuilder<AppDbContent>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options;

            using (AppDbContent db = new AppDbContent(options))
            {


                var customer = db.order
                // Загрузить заказ
                .Where(c => c.id == OrderId)
                .FirstOrDefault();

                // Внести изменения
                customer.confirm = false;
                var car = db.car
                   .Where(c => c.id == CarId)
                   .FirstOrDefault();

                car.available = true;



                db.SaveChanges();


            }



            return RedirectToAction("GetListOrders", "Order");
        }

        public IActionResult DeleteOrder(string[] items, int OrderId, int CarId)
        {


            var optionsBuilder = new DbContextOptionsBuilder<AppDbContent>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options;

            using (AppDbContent db = new AppDbContent(options))
            {


                var order = db.order
                // Загрузить заказ
                .Where(c => c.id == OrderId)
                .FirstOrDefault();

                // Внести изменения
                db.order.Remove(order);

                var car = db.car
               .Where(c => c.id == CarId)
               .FirstOrDefault();

               car.available = true;
                db.SaveChanges();

                db.SaveChanges();


            }



            return RedirectToAction("GetListOrders", "Order");
        }

        public async Task<IActionResult> SendMessage(string[] items, int OrderId, int CarId)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContent>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options;

            AppDbContent db = new AppDbContent(options);


                var order = db.order
                // Загрузить заказ
                .Where(c => c.id == OrderId)
                .FirstOrDefault();

            


            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(order.email, "Вы приобрели авто - поздравляем!!!", "Здраствуйте "+
                                               items[0]+". номер вашего заказа "+OrderId+", цена ->"+items[1]+"$, авто - "+items[2]);




            return RedirectToAction("GetListOrders", "Order");
        }

    }
}

