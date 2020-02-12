using Capstone_Web_Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Warehouse.Controllers
{
    public class HomeController : Controller
    {
        private OnlineEntities data = new OnlineEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageItems()
        {
            ViewBag.Message = "Item management page.";

            return View(this.data.ItemRentals.ToList());
        }

        public ActionResult ManageEmployees()
        {
            return Redirect("~/Employees/Index");
        }
    }
}