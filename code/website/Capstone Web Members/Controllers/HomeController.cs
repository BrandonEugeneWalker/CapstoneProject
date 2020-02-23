using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;
using Microsoft.Ajax.Utilities;

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

        public ActionResult MediaLibrary(string nameSearch, string typeSearch)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            ViewBag.Message = "Available Media:";

            return View(this.AvailableProducts);
        }

        public ActionResult OrderProduct(int productId)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            var results = this.DatabaseContext.findAvailableStockOfProduct(productId).ToList();
            var availableStockId = results[0];
            var memberId = int.Parse(Session["currentMemberId"].ToString());
            this.DatabaseContext.createMemberOrder(availableStockId, memberId);

            return Redirect(HttpContext.Request.UrlReferrer?.AbsoluteUri);
        }
    }
}