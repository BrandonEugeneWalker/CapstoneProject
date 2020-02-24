using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    /// <summary>
    ///     Controller managing the main sites of the Member side of the West GA Electronic Library
    /// </summary>
    /// <seealso cref="Controller" />
    public class HomeController : Controller
    {
        #region Data members

        /// <summary>
        ///     The database context
        /// </summary>
        public OnlineEntities DatabaseContext;

        /// <summary>
        ///     The available products
        /// </summary>
        public List<Product> AvailableProducts;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        public HomeController()
        {
            this.DatabaseContext = new OnlineEntities();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public HomeController(OnlineEntities databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Index / Home page of the website
        /// </summary>
        /// <returns>
        ///     The home page of the website
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     About page of the website
        /// </summary>
        /// <returns>
        ///     The contact page of the website
        /// </returns>
        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        /// <summary>
        ///     Contact page of the website
        /// </summary>
        /// <returns>
        ///     The contact page of the website
        /// </returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information:";

            return View();
        }

        /// <summary>
        ///     The Media Library page, showing all items available to order
        /// </summary>
        /// <param name="nameSearch">The name search.</param>
        /// <param name="typeSearch">The type search.</param>
        /// <returns>
        ///     The media library page
        /// </returns>
        public ActionResult MediaLibrary(string nameSearch, string typeSearch)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            if (nameSearch == null)
            {
                nameSearch = string.Empty;
            }

            if (typeSearch == null)
            {
                typeSearch = string.Empty;
            }

            this.AvailableProducts = this.DatabaseContext.retrieveAvailableProductsWithSearch(nameSearch, typeSearch)
                                         .ToList();

            var memberId = int.Parse(Session["currentMemberId"].ToString());

            var rentedCountResult = this.DatabaseContext.retrieveRentedCount(memberId).ToList();
            int? rentedCount = 0;
            if (rentedCountResult.Count > 0)
            {
                rentedCount = rentedCountResult[0];
            }

            ViewBag.HasThreeOrders = false;

            if (rentedCount >= 3)
            {
                ViewBag.HasThreeOrders = true;
            }

            ViewBag.Message = "Available Media:";

            return View(this.AvailableProducts);
        }

        /// <summary>
        ///     Orders the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>
        ///     The media library page after ordering selected product
        /// </returns>
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

        /// <summary>
        ///     Returns a product rental item
        /// </summary>
        /// <param name="rentalId">The rental identifier.</param>
        /// <returns>
        ///     The rental history page after returning selected rental
        /// </returns>
        public ActionResult ReturnProduct(int rentalId)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            this.DatabaseContext.updateMemberReturn(rentalId);
            return Redirect(HttpContext.Request.UrlReferrer?.AbsoluteUri);
        }

        #endregion
    }
}