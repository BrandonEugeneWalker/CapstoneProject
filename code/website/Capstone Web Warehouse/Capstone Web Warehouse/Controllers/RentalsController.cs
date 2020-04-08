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
        public ActionResult Index()
        {
            var employee = Session["Employee"] as Employee;

            if (employee == null) return Redirect("~/Home/Login");

            return View(database.ItemRentals.Where(i => i.status.Equals("WaitingReturn") || i.status.Equals("WaitingShipment")));
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
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            if (rental.status.Equals("WaitingReturn"))
            {
                rental.status = "Returned";
                rental.returnEmployeeId = employee.employeeId;
                rental.returnDateTime = DateTime.Now;
                rental.returnCondition = "Good";
                var stock = database.Stocks.Find(rental.stockId);
                stock.itemCondition = rental.returnCondition;
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
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