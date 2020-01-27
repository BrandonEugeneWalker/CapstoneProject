using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone_Web_Warehouse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageItems()
        {
            ViewBag.Message = "Item management page.";

            return View();
        }


        public ActionResult ManageEmployee()
        {
            ViewBag.Message = "Employee management page.";

            return View();
        }

    }
}