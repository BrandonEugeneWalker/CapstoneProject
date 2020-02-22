using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    public class HomeController : Controller
    {
        public OnlineEntities DatabaseContext;

        public List<Product> AvailableProducts;

        public HomeController()
        {
            this.DatabaseContext = new OnlineEntities();
            this.AvailableProducts = this.DatabaseContext.retrieveAvailableProducts().ToList();
        }

        public HomeController(OnlineEntities databaseContext)
        {
            this.DatabaseContext = databaseContext;
            //this.AvailableProducts = this.DatabaseContext.Products.ToList();
        }

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
            ViewBag.Message = "Available Media:";

            return View(this.AvailableProducts);
        }

        public ActionResult OrderProduct(int productId)
        {
            var results = this.DatabaseContext.findAvailableStockOfProduct(productId).ToList();
            var availableStockId = results[0];
            // TODO Remove this hardcoded MemberId when login is complete
            this.DatabaseContext.createMemberOrder(availableStockId, 1);

            return Redirect(HttpContext.Request.UrlReferrer?.AbsoluteUri);
        }
    }
}