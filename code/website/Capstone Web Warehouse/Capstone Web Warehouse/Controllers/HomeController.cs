using System;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Warehouse.Controllers
{
    /// <summary>Controller for the home page and navigation bar items.</summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        private readonly OnlineEntities data = new OnlineEntities();


        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
        {
            data = new OnlineEntities();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="entity"></param>
        public HomeController(OnlineEntities entity)
        {
            data = entity;
        }

        /// <summary>  Returns home page index page.</summary>
        /// <returns>Home index view.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>  Redirect to manage items index page.</summary>
        /// <returns>Manage items index view.</returns>
        public ActionResult ManageItems()
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Login");
            }

            return Redirect("~/Rentals/Index");
        }

        /// <summary>  Redirect to manage employee index page.</summary>
        /// <returns>The manage employee index view.</returns>
        public ActionResult ManageEmployees()
        {
            var employee = Session["Employee"] as Employee;

            if (employee == null || (bool) !employee.isManager)
            {
                return RedirectToAction("Login");
            }

            return Redirect("~/Employees/Index");
        }

        /// <summary>  Redirect to stocks index.</summary>
        /// <returns>stocks index page.</returns>
        public ActionResult ManageStock()
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Login");
            }

            return Redirect("~/Stocks/Index");
        }


        /*
         * Validates login information from employee table.
         */
        /// <summary>Logins the employee</summary>
        /// <param name="model">The employee to login</param>
        /// <returns>Manage rentals page if good, same page if bad.</returns>
        public ActionResult Login(Employee model)
        {
            if (!ModelState.IsValid) return View(model);
            var employee = data.selectEmployeeByIdAndPassword(model.employeeId, model.password).ToList();
            if (employee.Count > 0)
            {
                var currentEmp = employee[0];
                Session["Employee"] = currentEmp;
                Session["Name"] = currentEmp.name;
                Session["ID"] = currentEmp.employeeId;
                return RedirectToAction("ManageItems");
            }

            return View(model);
        }

        /*
        * Clears current employee session and logs user off.
        */
        /// <summary>Logs the employee off.</summary>
        /// <returns>home page.</returns>
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}