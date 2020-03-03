using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    public class AddressesController : Controller
    {
        #region Data members

        private readonly OnlineEntities databaseContext;

        #endregion

        #region Constructors

        public AddressesController()
        {
            this.databaseContext = new OnlineEntities();
        }

        public AddressesController(OnlineEntities databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        #endregion

        #region Methods

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.memberId = new SelectList(this.databaseContext.Members, "memberId", "username");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "address1,address2,city,state,zip")]
            Address address)
        {
            if (ModelState.IsValid)
            {
                var memberId = int.Parse(Session["currentMemberId"].ToString());
                this.databaseContext.insertAddress(address.address1, memberId, address.address2, address.city,
                    address.state, address.zip);
                return RedirectToAction("Details", "Members");
            }

            ViewBag.memberId = new SelectList(this.databaseContext.Members, "memberId", "username", address.memberId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var address = this.databaseContext.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }

            ViewBag.memberId = new SelectList(this.databaseContext.Members, "memberId", "username", address.memberId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "addressId,address1,address2,city,state,zip,memberId,removed")]
            Address address)
        {
            if (ModelState.IsValid)
            {
                this.databaseContext.editAddress(address.addressId, address.address1, address.address2, address.city,
                    address.state, address.zip);
                return RedirectToAction("Details", "Members");
            }

            ViewBag.memberId = new SelectList(this.databaseContext.Members, "memberId", "username", address.memberId);
            return View(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.databaseContext.Dispose();
            }

            base.Dispose(disposing);
        }

        public ActionResult Remove(int id)
        {
            this.databaseContext.removeAddress(id);
            return Redirect(HttpContext.Request.UrlReferrer?.AbsoluteUri);
        }

        #endregion
    }
}