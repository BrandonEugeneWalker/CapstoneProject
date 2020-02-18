using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineEntities db = new OnlineEntities();

        public List<Product> AvailableProducts => this.db.retrieveAvailableProducts().ToList();

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
            return View(this.AvailableProducts);
        }

        public ActionResult OrderProduct(int id)
        {
            var results = this.db.findAvailableStockOfProduct(id).ToList();
            var availableStockId = results[0];
            // TODO Remove this hardcoded MemberId when login is complete
            this.db.createMemberOrder(availableStockId, 1);

            return Redirect(HttpContext.Request.UrlReferrer?.AbsoluteUri);
        }
    }
}