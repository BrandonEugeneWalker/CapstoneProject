using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineEntities db = new OnlineEntities();

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
            var availableProducts = this.db.retrieveAvailableProducts().ToList();
            return View(availableProducts);
        }

        public ActionResult OrderProduct(int id)
        {
            //TODO assign stockId and updateOrder here
            var results = this.db.findAvailableStockOfProduct(id).ToList();
            var availableStockId = results[0];
            this.db.createMemberOrder(availableStockId, 1);

            return Redirect(HttpContext.Request.UrlReferrer?.AbsoluteUri);
        }
    }
}