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
    public class ProductsController : Controller
    {
        private OnlineEntities db = new OnlineEntities();


        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        public ProductsController()
        {
            db = new OnlineEntities();
        }

        /// <summary>Initializes a new instance of the <see cref="ProductsController" /> class.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="entity">The entity to be used.</param>
        public ProductsController(OnlineEntities entity)
        {
            db = entity;
        }

        // GET: Products

        /// <summary> Loads the index products view page.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>Returns product index page.</returns>
        public ActionResult Index()
        {
            var employee = Session["Employee"] as Employee;
            if (employee == null || (bool)!employee.isManager)
            {
                return Redirect("~/Home/Login");
            }

            return View(db.Products.ToList());
        }

        // GET: Products/Create

        /// <summary> Loads the create products view page.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>Returns product creation page.</returns>
        public ActionResult Create()
        {
            var employee = Session["Employee"] as Employee;
            if (employee == null || (bool)!employee.isManager)
            {
                return Redirect("~/Home/Login");
            }
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary> Loads the create products view page.
        /// <Precondition>Product must be valid.</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="product">The product to be created.</param>
        /// <returns>Returns product index page if valid data; Otherwise return creation page until valid..</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productId,name,description,type,category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
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
