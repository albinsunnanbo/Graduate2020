using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraduateDotNet2020.Models;
using GraduateDotNet2020.Db;
using GraduateDotNet2020.Utilities;

namespace GraduateDotNet2020.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //using (var context = new GraduateContext())
            //{
            //    var customers = context.Customers.Select(c => new
            //    {
            //        Name = c.Name,
            //        TotalAmount = c.Orders.Where(o => o.Price > 10).Sum(o => o.Price),
            //    });

            //    var data = Newtonsoft.Json.JsonConvert.SerializeObject(customers, Newtonsoft.Json.Formatting.Indented);
            //    return View((object)data);
            //}

            var fizzBuzz = new FizzBuzz().Generate().Take(10000);
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(fizzBuzz, Newtonsoft.Json.Formatting.Indented);
                return View((object)data);
        }

        public IActionResult NewCustomer(string name)
        {
            using (var context = new GraduateContext())
            {
                var customer = new Customer
                {
                    Name = name
                };
                var customers = context.Customers.Add(customer);
                context.SaveChanges();


                return RedirectToAction("Index");
            }
        }

        public IActionResult UpdateCustomer(int customerId, string name)
        {
            using (var context = new GraduateContext())
            {
                var customer = context.Customers.Single(c => c.CustomerId == customerId);
                customer.Name = name;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy(string data)
        {
            PrivacyModel model = BuildPrivacyModel(data);
            return View(model);
        }

        public static PrivacyModel BuildPrivacyModel(string data)
        {
            return new PrivacyModel
            {
                Name = data
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
