using System.Web.Mvc;

namespace Capstone_Web_Warehouse.Controllers
{
    /// <summary>Controller for the home page and navigation bar items.</summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
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
            return Redirect("~/Rentals/Index");
        }

        /// <summary>  Redirect to manage employee index page.</summary>
        /// <returns>The manage employee index view.</returns>
        public ActionResult ManageEmployees()
        {
            return Redirect("~/Employees/Index");
        }
    }
}