using System.Net;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    /// <summary>
    ///     Controller for managing the address views and actions for adding and maintaining addresses.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class AddressesController : Controller
    {
        #region Data members

        /// <summary>
        ///     The database context
        /// </summary>
        private readonly OnlineEntities databaseContext;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddressesController" /> class.
        /// </summary>
        public AddressesController()
        {
            this.databaseContext = new OnlineEntities();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddressesController" /> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public AddressesController(OnlineEntities databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Starts the View for creating an address. If called from Profile, calls with addressId. If called from
        ///     OrderProduct, calls with addressId and productId. Creates null productId Session and then stores in Session.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="productId">The product id if called from Order Product.</param>
        /// <returns>The create page with form for editing an address</returns>
        public ActionResult Create(int? productId)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            Session["productId"] = null;
            Session["productId"] = productId;

            return View();
        }

        /// <summary>
        ///     Action for Creating an address from the Create View form. If Address is valid, redirects to Member Profile after
        ///     adding to database or Order Product if productId is valid. If both invalid, redirects to form.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="address">The address created.</param>
        /// <returns>
        ///     Member Profile if Created Address is valid or OrderProduct if Address and ProductId are valid Create Page if
        ///     invalid.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "address1,address2,city,state,zip")]
            Address address)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            if (ModelState.IsValid)
            {
                var memberId = int.Parse(Session["currentMemberId"].ToString());
                this.databaseContext.insertAddress(address.address1, memberId, address.address2, address.city,
                    address.state, address.zip);

                if (Session["productId"] != null)
                {
                    var productId = int.Parse(Session["productId"].ToString());
                    return RedirectToAction("OrderProduct", "Home", new {productId});
                }

                return RedirectToAction("Details", "Members");
            }

            return View(address);
        }

        /// <summary>
        ///     Starts the View for editing a specified address. If called from Profile, calls with addressId. If called from
        ///     OrderProduct, calls with addressId and productId. Creates null productId Session and then stores in Session.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="id">The addressId to edit.</param>
        /// <param name="productId">The product id if called from Order Product.</param>
        /// <returns>The edit page with form for editing an address</returns>
        public ActionResult Edit(int? id, int? productId)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            Session["productId"] = null;
            Session["productId"] = productId;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var address = this.databaseContext.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }

            return View(address);
        }

        /// <summary>
        ///     Action for Editing an address from the Edit View form. If edited Address is valid, redirects to Member Profile
        ///     after updating in database. If invalid, redirects to form.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="address">The address being edited.</param>
        /// <returns>Member Profile if Edited Address is valid. Edit Page if invalid.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "addressId,address1,address2,city,state,zip,memberId,removed")]
            Address address)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            if (ModelState.IsValid)
            {
                this.databaseContext.editAddress(address.addressId, address.address1, address.address2, address.city,
                    address.state, address.zip);

                if (Session["productId"] != null)
                {
                    var productId = int.Parse(Session["productId"].ToString());
                    return RedirectToAction("OrderProduct", "Home", new {productId});
                }

                return RedirectToAction("Details", "Members");
            }

            return View(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.databaseContext.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        ///     Removes a specified address and reloads the page. Calls removeAddress stored procedure, keeps address but marks as
        ///     removed. If this action is called from the OrderProduct page, will reroute back with its stored product, otherwise
        ///     redirects to Member Profile.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="id">The addressId being removed.</param>
        /// <param name="productId">The product id of the OrderProduct page if accessed from there.</param>
        /// <returns>
        ///     Member Profile view
        /// </returns>
        public ActionResult Remove(int id, int? productId)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            this.databaseContext.removeAddress(id);

            if (productId != null)
            {
                return RedirectToAction("OrderProduct", "Home", new {productId});
            }

            return RedirectToAction("Details", "Members");
        }

        #endregion
    }
}