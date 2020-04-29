﻿using System;
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

        /// <summary>Initializes a new instance of the <see cref="RentalsController"/> class.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        public RentalsController()
        {
            database = new OnlineEntities();
        }

        /// <summary>Initializes a new instance of the <see cref="RentalsController"/> class.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="entity">The entity.</param>
        public RentalsController(OnlineEntities entity)
        {
            database = entity;
        }

        /// <summary>  Returns manage rentals index page.
        /// <Precondition>Employee != Null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>Returns manage rentals index page with list of rentals.</returns>
        /// <param name="filter">The filter status.</param>
        public ActionResult Index(string filter)
        {
            if (filter is null)
            {
                filter = "All";
            }

            var employee = Session["Employee"] as Employee;

            if (employee == null)
            {
                return Redirect("~/Home/Login");
            }

            ViewBag.Filter = filter;
            if (filter == "All")
            {
                return View(database.ItemRentals);
            }
            else
            {
                return View(database.ItemRentals.Where(s => s.status == filter));
            }
        }

        /// <summary>Updates the status of rental item.
        /// <Precondition>Employee != Null && ID != Null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="id">The id of the rental item.</param>
        /// <returns>The index page refreshed if found || error page if bad id.</returns>
        public ActionResult UpdateStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = Session["Employee"] as Employee;
            var rental = database.ItemRentals.Find(id);

            if (rental == null || employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (rental.status.Equals("WaitingShipment"))
            {
                rental.status = "WaitingReturn";
                rental.shipEmployeeId = employee.employeeId;
                rental.shipDateTime = DateTime.Now;
                rental.dueDateTime = DateTime.Now.AddDays(14);
                rental.returnCondition = rental.Stock.itemCondition;
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        /// <summary>Returns return view page.
        /// <Precondition>Employee != Null && ID != Null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="id">The id of the rental item.</param>
        /// <returns>The return page refreshed if found || error page if bad id.</returns>
        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = Session["Employee"] as Employee;
            var rental = database.ItemRentals.Find(id);

            if (rental == null || employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(rental);
        }

        /// <summary>Returns item with set condition.
        /// <Precondition>Employee != Null && ID != Null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="rental">The rental item being changed.</param>
        /// <returns>The index page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Return([Bind(Include = "itemRentalId,stockId,memberId,addressId,status,rentalDateTime,shipEmployeeId,shipDateTime,returnEmployeeId,returnDateTime,returnCondition,dueDateTime")] ItemRental rental)
        {
            var employee = Session["Employee"] as Employee;
            if (ModelState.IsValid)
            {
                //database.Entry(rental).State = EntityState.Modified;
                var rent = database.ItemRentals.Find(rental.itemRentalId);
                rent.returnCondition = rental.returnCondition;
                rent.Stock.itemCondition = rental.returnCondition;
                rent.returnDateTime = DateTime.Now;
                rent.status = "Returned";
                rent.returnEmployeeId = employee.employeeId;
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rental);
        }

        /// <summary>Releases unmanaged resources and optionally releases managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) database.Dispose();

            base.Dispose(disposing);
        }
    }
}