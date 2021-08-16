using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using V_View.Models;

namespace V_View.Controllers
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
            return View();
        }
        [HttpPost]//Attribute HttpPost ทำการรับข้อมูลที่ user กรอกไว้ใน form
        public IActionResult GetIndex(Customer customer)//ผ่าน
        {
            if (ModelState.IsValid)
            {
                return View("Finish", customer);//ส่งข้อมูลที่เก็บอยู่ใน customer ไปแสดงผลใน Finish.csthml
            }
            return View(customer);//ถ้าข้อมูลไม่สมบูรณ์หรือไม่ถูกต้อง ให้แสดงผลหน้า index.cshtml
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
