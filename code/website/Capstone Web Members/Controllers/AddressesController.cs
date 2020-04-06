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
        ///     Form for creating an address
        ///     <Precondition>Session["currentMemberId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="productId">productId of product ordered</param>
        /// <returns>The create page for Address</returns>
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
        ///     Action for Creating an address from the Create View form
        ///     <Precondition>Session["currentMemberId"] != null</Precondition>
        ///     <Postcondition>Inserts address to Addresses table</Postcondition>
        /// </summary>
        /// <param name="address">The address created.</param>
        /// <returns>Previously called page if successful, back to create page if failed</returns>
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
        ///     Starts the View for editing a specified address
        ///     <Precondition>Session["currentMemberId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="id">addressId of Address to edit</param>
        /// <param name="productId">productId of Product</param>
        /// <returns>The edit page</returns>
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
        ///     Action for Editing an address from the Edit View form
        ///     <Precondition>Session["currentMemberId"] != null</Precondition>
        ///     <Postcondition>Updates address in Addresses table</Postcondition>
        /// </summary>
        /// <param name="address">The address being edited.</param>
        /// <returns>Previously called page if successful, back to edit page if failed</returns>
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
        ///     Removes a specified address and reloads the page
        ///     <Precondition>Session["currentMemberId"] != null</Precondition>
        ///     <Postcondition>Updates status of address in Addresses table</Postcondition>
        /// </summary>
        /// <param name="id">addressId of Address to remove</param>
        /// <param name="productId">productId of Product</param>
        /// <returns>Previously called page</returns>
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