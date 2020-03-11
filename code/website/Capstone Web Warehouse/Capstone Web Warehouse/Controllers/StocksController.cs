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

        public StocksController()
        {
            db = new OnlineEntities();
        }

        public StocksController(OnlineEntities entity)
        {
            db = entity;
        }

        // GET: Stocks
        /// <summary>  List of stocks</summary>
        /// <returns>Index page</returns>
        public ActionResult Index()
        {
            if (Session["Employee"] == null)
            {
                return Redirect("~/Home/Login");
            }
            var stocks = db.Stocks.Include(s => s.Product);
            return View(stocks.ToList());
        }

        // GET: Stocks/Details/5
        /// <summary>Detail of stock info</summary>
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

/*        // GET: Stocks/Create
        /// <summary>Creates stock</summary>
        /// <returns>stock creation page.</returns>
        public ActionResult Create()
        {
            ViewBag.productId = new SelectList(db.Products, "productId", "name");
            return View();
        }*/

/*        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>Creates the specified stock.</summary>
        /// <param name="stock">The stock.</param>
        /// <returns>index if good, same page if bad.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stockId,productId,itemCondition")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.Products, "productId", "name", stock.productId);
            return View(stock);
        }
*/
/*        // GET: Stocks/Delete/5
        /// <summary>Deletes the specified stock.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete confirmaton page.</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }*/
/*
        // POST: Stocks/Delete/5
        /// <summary>Deletes the confirmed.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Index page</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stocks.Find(id);
            db.Stocks.Remove(stock);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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
