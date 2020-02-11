using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database;
using Capstone_Web_Members.Models;

namespace Capstone_Web_Members.Controllers
{
    public class HomeController : Controller
    {
        private readonly Capstone_Database.cs4982s20dDataSet data = new cs4982s20dDataSet();

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

        [Authorize]
        public ActionResult MediaLibrary()
        {
            return View(this.data.Product.ToList());
        }
    }
}