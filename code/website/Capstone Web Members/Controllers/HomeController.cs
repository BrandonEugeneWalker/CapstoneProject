using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database;
using Capstone_Database.DAL;
using Capstone_Web_Members.Models;

namespace Capstone_Web_Members.Controllers
{
    public class HomeController : Controller
    {
        //private readonly Capstone_Database.cs4982s20dDataSet data = new cs4982s20dDataSet();
        private Capstone_Database.DAL.CapstoneContext data = new CapstoneContext();

        public ActionResult Index()
        {
            var fl = Capstone_Database.Class1.Connected;
            var clas = new Capstone_Database.Class1();
            var tr = Capstone_Database.Class1.Connected;
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