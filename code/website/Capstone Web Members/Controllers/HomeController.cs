using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;
using Capstone_Web_Members.ViewModels;

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
        ///     Index of the Website, required for running of Website. Redirects to Media Library. Redirects to Login if no login
        ///     session found.
        /// </summary>
        /// <returns>Media Library Page</returns>
        public ActionResult Index()
        {
            return RedirectToAction("MediaLibrary");
        }

        /// <summary>
        ///     The Media Library page, showing all items available to order. If reloading after the Search form is submitted,
        ///     sends filter information to the database to filter during stored procedure call. Checks if Member's active
        ///     ItemRentals are 3 or higher.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="nameSearch">The name search field.</param>
        /// <param name="typeSearch">The type search field.</param>
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

            ViewBag.NameSearch = nameSearch;
            ViewBag.TypeSearch = typeSearch;
            this.AvailableProducts = this.DatabaseContext.retrieveAvailableProductsWithSearch(nameSearch, typeSearch)
                                         .ToList();
            var memberId = int.Parse(Session["currentMemberId"].ToString());
            var rentedCountResult = this.DatabaseContext.retrieveRentedCount(memberId).ToList();
            int? rentedCount = 0;
            if (rentedCountResult.Count > 0)
            {
                rentedCount = rentedCountResult[0];
            }

            var mediaLibraryViewModel = new MediaLibraryViewModel
                {ProductsModel = this.AvailableProducts, RentedCountModel = rentedCount};

            return View(mediaLibraryViewModel);
        }

        /// <summary>
        ///     Navigates to the Order Product view to confirm order. Showcases the selected product and gives list of Addresses
        ///     for member to select. If member has no address, they are prompted to create one.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="productId">The product id, referencing Product being ordered.</param>
        /// <returns>The Order Product view detailing the selected product</returns>
        public ActionResult OrderProduct(int productId)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            var product = this.DatabaseContext.Products.Find(productId);
            var memberId = int.Parse(Session["currentMemberId"].ToString());
            var addresses = this.DatabaseContext.retrieveMembersAddresses(memberId).ToList();
            var orderProductViewModel = new OrderProductViewModel {ProductModel = product, AddressesModel = addresses};
            return View(orderProductViewModel);
        }

        /// <summary>
        ///     Orders the product following user confirmation, finds the available Stock object of the given product and creates
        ///     an Item Rental of the item.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="productId">The product ID, referencing Product being ordered.</param>
        /// <param name="addressId">The address id, referencing the selected Address being ordered to</param>
        /// <returns>
        ///     The media library page after ordering selected product
        /// </returns>
        [HttpPost]
        public ActionResult OrderProduct(string productId, string addressId)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            var results = this.DatabaseContext.findAvailableStockOfProduct(int.Parse(productId)).ToList();
            var availableStockId = results[0];
            var memberId = int.Parse(Session["currentMemberId"].ToString());
            this.DatabaseContext.createMemberOrder(availableStockId, memberId, int.Parse(addressId));

            return RedirectToAction("OrderConfirmation",
                new {productId = int.Parse(productId), addressId = int.Parse(addressId)});
        }

        /// <summary>
        ///     Shows Order Confirmation information for Product just ordered. Shows the info of the Product and the Address used
        ///     to order. Links back to Media Library. Called from OrderProduct.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="productId">The product id, referencing Product just ordered.</param>
        /// <param name="addressId">The address id, referencing Address ordered to.</param>
        /// <returns></returns>
        public ActionResult OrderConfirmation(int productId, int addressId)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            var product = this.DatabaseContext.Products.Find(productId);
            var address = this.DatabaseContext.Addresses.Find(addressId);
            var orderConfirmationViewModel = new OrderConfirmationViewModel
                {ProductModel = product, AddressModel = address};

            return View(orderConfirmationViewModel);
        }

        #endregion
    }
}