using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;
using Capstone_Web_Members.Settings;
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
        ///     Index of the Website, required for running of Website
        ///     <Precondition>Session["currentMemberId"] != null OR Session["currentLibrarianId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>The Media Library Page or Member Index</returns>
        public ActionResult Index()
        {
            if (Session["currentLibrarianId"] != null)
            {
                return RedirectToAction("Index", "Members");
            }

            return RedirectToAction("MediaLibrary");
        }

        /// <summary>
        ///     The Media Library page, showing all items available to order with filters
        ///     <Precondition>Session["currentMemberId"] != null OR Session["currentLibrarianId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="nameSearch">The name search field.</param>
        /// <param name="typeSearch">The type search field.</param>
        /// <returns>The MediaLibrary page</returns>
        public ActionResult MediaLibrary(string nameSearch, string typeSearch)
        {
            if (Session["currentMemberId"] == null && Session["currentLibrarianId"] == null)
            {
                Session.Abandon();
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

            int? rentalCount = 0;
            if (Session["currentMemberId"] != null)
            {
                var memberId = int.Parse(Session["currentMemberId"].ToString());
                var rentedCountResult = this.DatabaseContext.retrieveRentedCount(memberId).ToList();
                if (rentedCountResult.Count > 0)
                {
                    rentalCount = rentedCountResult[0];
                }
            }

            var mediaLibraryViewModel = new MediaLibraryViewModel
                {ProductsModel = this.AvailableProducts, RentalCount = rentalCount};

            if (Session["currentLibrarianId"] != null)
            {
                mediaLibraryViewModel.IsLibrarian = true;
            }

            return View(mediaLibraryViewModel);
        }

        /// <summary>
        ///     Navigates to the Order Product view to confirm order.
        ///     Showcases the selected product and gives list of Addresses
        ///     <Precondition>Session["currentMemberId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="productId">productId of product ordered</param>
        /// <returns>The Order Product view detailing the selected product</returns>
        public ActionResult OrderProduct(int productId)
        {
            if (Session["currentMemberId"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Login", "Members");
            }

            var product = this.DatabaseContext.Products.Find(productId);
            var memberId = int.Parse(Session["currentMemberId"].ToString());
            var addresses = this.DatabaseContext.retrieveMembersAddresses(memberId).ToList();
            var orderProductViewModel = new OrderProductViewModel {ProductModel = product, AddressesModel = addresses};
            return View(orderProductViewModel);
        }

        /// <summary>
        ///     Orders the product following user confirmation, creating an ItemRental entry
        ///     <Precondition>Session["currentMemberId"] != null</Precondition>
        ///     <Postcondition>ItemRentals table entry created</Postcondition>
        /// </summary>
        /// <param name="productId">productId of product ordered</param>
        /// <param name="addressId">addressId of address selected</param>
        /// <returns>OrderConfirmation ActionResult</returns>
        [HttpPost]
        public ActionResult OrderProduct(string productId, string addressId)
        {
            if (Session["currentMemberId"] == null)
            {
                Session.Abandon();
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
        ///     Shows Order Confirmation information for Product just ordered
        ///     <Precondition>Session["currentMemberId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="productId">productId of product ordered</param>
        /// <param name="addressId">addressId of address selected</param>
        /// <returns>Page detailing ItemRental and order info</returns>
        public ActionResult OrderConfirmation(int productId, int addressId)
        {
            if (Session["currentMemberId"] == null)
            {
                Session.Abandon();
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