using System.Linq;
using System.Web.Mvc;
using Capstone_Web_Members.Models;

namespace Capstone_Web_Members.Controllers
{
    public class HomeController : Controller
    {
        private readonly DefaultEntity data = new DefaultEntity();

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
            return View(data.Products.ToList());
        }

        [HttpPost]
        public ActionResult SearchByName(string nameSearch)
        {
            //return RedirectToAction("", "", search);
            var searchedData = new DefaultEntity();
            foreach (var product in data.Products.ToList().Where(product => product.name.Contains(nameSearch)))
            {
                searchedData.Products.Add(product);
            }

            if (searchedData.Products.ToList().Count < 1)
            {
                searchedData = data;
            }

            return View("MediaLibrary", searchedData.Products.ToList());
        }
    }
}