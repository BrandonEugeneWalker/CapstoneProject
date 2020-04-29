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
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        public HomeController()
        {
            data = new OnlineEntities();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="entity"></param>
        public HomeController(OnlineEntities entity)
        {
            data = entity;
        }

        /// <summary>  Returns home page index page.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
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

        /// <summary>  Redirect to manage employee index page.
        /// <Precondition>Employee != Null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>The manage employee index view.</returns>
        public ActionResult ManageEmployees()
        {
            var employee = Session["Employee"] as Employee;

            if (employee == null || (bool)!employee.isManager)
            {
                return RedirectToAction("Login");
            }

            return Redirect("~/Employees/Index");
        }

        /// <summary>  Redirect to stocks index.
        /// <Precondition>Employee != Null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>stocks index page.</returns>
        public ActionResult ManageStock()
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Login");
            }

            return Redirect("~/Stocks/Index");
        }

        /// <summary>  Redirect to stocks index.
        /// <Precondition>Employee != Null</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>stocks index page.</returns>
        public ActionResult ManageProducts()
        {
            var employee = Session["Employee"] as Employee;
            if (employee == null || (bool)!employee.isManager)
            {
                return RedirectToAction("Login");
            }

            return Redirect("~/Products/Index");
        }

        /// <summary>Logins the employee
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="model">The employee to login</param>
        /// <returns>Manage rentals page if good, same page if bad.</returns>
        public ActionResult Login(Employee model)
        {
            var employee = data.selectEmployeeByIdAndPassword(model.employeeId, model.password).ToList();
            if (employee.Count > 0)
            {
                var currentEmp = employee[0];
                Session["Employee"] = currentEmp;
                Session["Manager"] = currentEmp.isManager;
                return RedirectToAction("ManageItems");
            }

            return View(model);
        }

        /// <summary>Logs the employee off.
        /// <Precondition>None</Precondition>
        /// <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>home page.</returns>
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}