using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Warehouse.Controllers
{
    /// <summary>Controller class for managing stocks.</summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class StocksController : Controller
    {
        private OnlineEntities db = new OnlineEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="StocksController"/> class.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        public StocksController()
        {
            db = new OnlineEntities();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StocksController"/> class.  List of stocks
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        public StocksController(OnlineEntities entity)
        {
            db = entity;
        }

        // GET: Stocks

        /// <summary>  List of stocks
        /// <Precondition>Session["Employee"] != null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>Index page</returns>
        public ActionResult Index()
        {
            if (Session["Employee"] == null)
            {
                return Redirect("~/Home/Login");
            }

            //var stocks = db.Stocks.Include(s => s.Product);

            return View(db.Stocks.ToList());
        }

        // GET: Stocks/Details/5

        /// <summary>Detail of stock info
        /// <Precondition>Stock != null && ID != Null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>stock detail page.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Stocks/Create

        /// <summary>Creates stock
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>stock creation page.</returns>
        public ActionResult Create()
        {
            var employee = Session["Employee"] as Employee;

            if (employee == null || (bool)!employee.isManager)
            {
                return Redirect("~/Home/Login");
            }

            ViewBag.productId = new SelectList(db.Products, "productId", "name");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>Creates the specified stock.
        /// <Precondition>Session["Employee"] != null && ModelState != Invalid</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>index if good, same page if bad.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stockId,productId,itemCondition")] Stock stock)
        {
            var employee = Session["Employee"] as Employee;

            if (employee == null || (bool)!employee.isManager) return Redirect("~/Home/Login");

            if (ModelState.IsValid)
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Stocks/Delete/5

        /// <summary>Deletes the specified stock.
        /// <Precondition>Session["Employee"] != null && ID != Invalid</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete confirmaton page.</returns>
        public ActionResult Delete(int? id)
        {
            var employee = Session["Employee"] as Employee;

            if (employee == null || (bool)!employee.isManager) return Redirect("~/Home/Login");

            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5

        /// <summary>Deletes the confirmed.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Index page</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stocks.Find(id);
            stock.itemCondition = "Unusable";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
