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
    public class RentalsController : Controller
    {
        private OnlineEntities db = new OnlineEntities();

        // GET: Rentals
        public ActionResult Index()
        {
            var itemRentals = db.ItemRentals.Include(i => i.Member).Include(i => i.Stock);
            return View(itemRentals.ToList());
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRental itemRental = db.ItemRentals.Find(id);
            if (itemRental == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberId = new SelectList(db.Members, "memberId", "name", itemRental.memberId);
            ViewBag.stockId = new SelectList(db.Stocks, "stockId", "stockId", itemRental.stockId);
            return View(itemRental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemRentalId,stockId,memberId,status")] ItemRental itemRental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemRental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberId = new SelectList(db.Members, "memberId", "name", itemRental.memberId);
            ViewBag.stockId = new SelectList(db.Stocks, "stockId", "stockId", itemRental.stockId);
            return View(itemRental);
        }

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
