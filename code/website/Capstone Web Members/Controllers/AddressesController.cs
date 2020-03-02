using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    public class AddressesController : Controller
    {
        private readonly OnlineEntities databaseContext;

        public AddressesController()
        {
            this.databaseContext = new OnlineEntities();
        }
        public AddressesController(OnlineEntities databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        // GET: Addresses
        public ActionResult Index()
        {
            var addresses = databaseContext.Addresses.Include(a => a.Member);
            return View(addresses.ToList());
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.memberId = new SelectList(databaseContext.Members, "memberId", "username");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "address")] Address address)
        {
            if (ModelState.IsValid)
            {
                databaseContext.Addresses.Add(address);
                databaseContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberId = new SelectList(databaseContext.Members, "memberId", "username", address.memberId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var address = databaseContext.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberId = new SelectList(databaseContext.Members, "memberId", "username", address.memberId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "addressId,address,memberId,removed")] Address address)
        {
            if (ModelState.IsValid)
            {
                databaseContext.Entry(address).State = EntityState.Modified;
                databaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberId = new SelectList(databaseContext.Members, "memberId", "username", address.memberId);
            return View(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                databaseContext.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Remove(int id)
        {
            // TODO update address column "removed" to 1
            return Redirect(HttpContext.Request.UrlReferrer?.AbsoluteUri);
        }
    }
}
