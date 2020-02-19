using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Warehouse.Controllers
{
    /// <summary>Controller class for employee management pages.</summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class EmployeesController : Controller
    {
        private readonly OnlineEntities database = new OnlineEntities();

        /// <summary>  Index/Home page for employee management.</summary>
        /// <returns>employee management index page with list of all employees.</returns>
        public ActionResult Index()
        {
            return View(database.Employees.ToList());
        }

        /// <summary>
        ///     Detail view of the selected employee.
        ///     <precondtion>the selected employeeID != null && employee with ID must exist in database.</precondtion>
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <returns>view of the employee details for selected ID.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = database.Employees.Find(id);
            return employee == null ? (ActionResult) HttpNotFound() : View(employee);
        }

        /// <summary>  Returns employee creation page view.</summary>
        /// <returns>The employee creation view.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     Creates the specified employee.
        ///     Used for create button on employee creation page.
        ///     <postcondition>Employee is added to the database.</postcondition>
        /// </summary>
        /// <param name="employee">The employee to be created and added to database.</param>
        /// <returns>
        ///     Returns to employee management index page if input valid || the same page with the employee data previously
        ///     entered if input is invalid.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeId,password,isManager,name")]
            Employee employee)
        {
            if (ModelState.IsValid)
            {
                sbyte manager = 0;
                if (employee.isManager != null && (bool)employee.isManager)
                {
                    manager = 1;
                }

                database.insertEmployee(null, employee.password, manager, employee.name);
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        /// <summary>
        ///     Returns employee edit page view.
        ///     <precondition>employee ID can not be null && employee with ID must exist in database.</precondition>
        /// </summary>
        /// <param name="id">  The employee ID.</param>
        /// <returns>Employee edit view for selected ID.</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = database.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        /// <summary>
        ///     <para>
        ///         Edits the specified employee.
        ///         For the employee edit button.
        ///     </para>
        ///     <postcondition>Employee is edited in the database.</postcondition>
        /// </summary>
        /// <param name="employee">The employee to be edited.</param>
        /// <returns>The employee management index if valid. || Employee edit page with entered data.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeId,password,isManager,name")]
            Employee employee)
        {
            if (ModelState.IsValid)
            {
                database.Entry(employee).State = EntityState.Modified;
                database.Entry(employee).Property("password").IsModified = false;
                database.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        /// <summary>
        ///     <para>
        ///         Returns employee deletions page view.
        ///     </para>
        ///     <precondition>employee id != null && employee ID must exist in database.</precondition>
        /// </summary>
        /// <param name="id">  The employee id to delete.</param>
        /// <returns>Returns employee deletion page.</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = database.Employees.Find(id);
            return employee == null ? (ActionResult) HttpNotFound() : View(employee);
        }


        /// <summary>  Returns delete confirmation message.</summary>
        /// <param name="id">  the employee id to be deleted.</param>
        /// <returns>Employee management index page.</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = database.Employees.Find(id);
            database.Employees.Remove(employee);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                database.Dispose();
            }

            base.Dispose(disposing);
        }
    }

}