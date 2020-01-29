using Capstone_Web_Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone_Web_Warehouse.Controllers
{
    public class HomeController : Controller
    {
        private DefaultEntity data = new DefaultEntity();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ManageItems()
        {
            ViewBag.Message = "Item management page.";

            return View(this.data.Rentals.ToList());
        }
    }
}