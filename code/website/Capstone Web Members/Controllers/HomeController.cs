﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database;
using Capstone_Database.Model;
using Capstone_Web_Members.Models;

namespace Capstone_Web_Members.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineEntities data = new OnlineEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information:";

            return View();
        }

        public ActionResult MediaLibrary()
        {
            return View(this.data.Products.ToList());
        }
    }
}