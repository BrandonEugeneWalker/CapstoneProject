using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Warehouse.Controllers
{
    /// <summary>Controller for manage rental pages.</summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class RentalsController : Controller
    {
        private readonly OnlineEntities database = new OnlineEntities();

        public RentalsController()
        {
            database = new OnlineEntities();
        }

        public RentalsController(OnlineEntities entity)
        {
            database = entity;
        }

        /// <summary>  Returns manage rentals index page.</summary>
        /// <returns>Returns manage rentals index page with list of rentals.</returns>
        public ActionResult Index()
        {
            var employee = Session["Employee"] as Employee;

            if (employee == null) return Redirect("~/Home/Login");

            var itemRentals = database.ItemRentals.Include(i => i.Member).Include(i => i.Stock).Where(i => i.status.Equals("WaitingReturn") || i.status.Equals("WaitingShipment"));
            return View(itemRentals.ToList());
        }
/*
        /// <summary>
        ///     <para>
        ///         Returns update page for manage rentals.
        ///     </para>
        ///     <precondition>The selected rental ID != null && must exist in the database.</precondition>
        /// </summary>
        /// <param name="id">  The selected itemRental ID for the rental to be modified.</param>
        /// <returns>The item rental update page view with selected rental ID.</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var itemRental = database.ItemRentals.Find(id);
            return itemRental == null ? (ActionResult) HttpNotFound() : View(itemRental);
        }

        /// <summary>
        ///     Edits the specified item rental.
        ///     Used for update button.
        /// </summary>
        /// <param name="itemRental">The itemRental to be updated.</param>
        /// <returns>The item rentals index page if input valid. || The item rentals update page with entered information.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemRentalId,stockId,memberId,status")]
            ItemRental itemRental)
        {
            if (ModelState.IsValid)
            {
                database.Entry(itemRental).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemRental);
        }*/

        public ActionResult UpdateStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rental = database.ItemRentals.Find(id);
            if (rental.status.Equals("WaitingShipment"))
            {
                rental.status = "Rented";
                database.SaveChanges();
            }else if (rental.status.Equals("WaitingReturn"))
            {
                rental.status = "Returned";
                database.SaveChanges();
            }
            return Redirect(HttpContext.Request.UrlReferrer?.AbsoluteUri);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) database.Dispose();

            base.Dispose(disposing);
        }
    }
}