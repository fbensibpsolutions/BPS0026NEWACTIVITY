using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NEW_BPS0026_MVC_ACTIVITY.Models;

namespace NEW_BPS0026_MVC_ACTIVITY.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Order> orderList = new List<Order>();

            orderList = OrderDetailsData();

            return View(orderList);
        }

        public IActionResult Orderdetails(string no)
        {
            ViewData["no"] = no;

            var data = OrderDetailsData().FirstOrDefault(x => x.No == no);

            var orderdetailsdatas = new List<Order>();
            
            orderdetailsdatas.Add(new Order{
                No = data.No,
                CustomerName = data.CustomerName,
                Date = data.Date,
                Amount = data.Amount
            });

            return View(orderdetailsdatas);
        }
        public List<Order> OrderDetailsData()
        {
            var orders = new List<Order>();

            orders.Add(new Order
            {
                No = "OD-1",
                CustomerName = "Test-1",
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = 1000
            });
            orders.Add(new Order
            {
                No = "OD-2",
                CustomerName = "Test-2",
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = 1050
            });

            orders.Add(new Order
            {
                No = "OD-3",
                CustomerName = "Test-3",
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = 1050
            });

            orders.Add(new Order
            {
                No = "OD-4",
                CustomerName = "Test-4",
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = 1050
            });

            return orders;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
