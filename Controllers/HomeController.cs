using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
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
            int? Count = HttpContext.Session.GetInt32("Count");
            if(Count ==null)
            {
                HttpContext.Session.SetInt32("Count", 0);
                Count = 0;
            }
            else
            {
                int newCount = (int)Count + 1;
                HttpContext.Session.SetInt32("Count", newCount);
                Count = newCount;
            }
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";
            Random rand = new Random();
            string randomString = "";
            for(int i=0;i<14;i++)
            {
                randomString += chars[rand.Next(0, chars.Length)];
            }
            ViewBag.Count = Count;
            ViewBag.Password = randomString;
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
