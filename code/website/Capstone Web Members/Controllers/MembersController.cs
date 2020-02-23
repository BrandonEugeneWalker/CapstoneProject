using System.Linq;
using System.Net;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    /// <summary>
    ///     Controller class for Member Management pages
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class MembersController : Controller
    {
        #region Data members

        public OnlineEntities DatabaseContext = new OnlineEntities();

        #endregion

        #region Methods

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>A list of all members</returns>
        public ActionResult Index()
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            return View(this.DatabaseContext.Members.ToList());
        }

        /// <summary>
        ///     Shows the details of the logged in member.
        /// </summary>
        /// <returns>
        ///     Returns page showcasing details of the logged in member
        /// </returns>
        public ActionResult Details()
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            var memberId = int.Parse(Session["currentMemberId"].ToString());
            var member = this.DatabaseContext.Members.Find(memberId);
            return member == null ? (ActionResult) HttpNotFound() : View(member);
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     Creates the specified member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        ///     Navigates to the Member Web Homepage
        ///     Creates / Registers the new member
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memberId,username,name,password,address,isLibrarian,isBanned")]
            Member member)
        {
            if (ModelState.IsValid)
            {
                this.DatabaseContext.insertMember(member.username, member.name, member.password, member.address, 0);
                this.DatabaseContext.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(member);
        }

        /// <summary>
        ///     Edits the specified Member.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     Returns the edit view page for the selected Member
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var member = this.DatabaseContext.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            member.password = string.Empty;
            return View(member);
        }

        /// <summary>
        ///     Edits the specified member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        ///     Returns the edit view page for the selected Member
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "memberId,username,name,password,address,isLibrarian,isBanned")]
            Member member)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            if (ModelState.IsValid)
            {
                this.DatabaseContext.editMember(member.username, member.name, member.password, member.address,
                    member.memberId);
                return RedirectToAction("Details");
            }

            return View(member);
        }

        /// <summary>
        ///     Deletes the specified Member.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     Returns the Delete page of a given Member
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var member = this.DatabaseContext.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        /// <summary>
        ///     Deletes the confirmed Member.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     Returns to index after confirming member deletion
        /// </returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            var member = this.DatabaseContext.Members.Find(id);
            this.DatabaseContext.Members.Remove(member);
            this.DatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.DatabaseContext.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        ///     Logs in the user and returns to the previous URL
        /// </summary>
        /// <returns>
        ///     Returns to the previous page after logging in
        /// </returns>
        [AllowAnonymous]
        public ActionResult Login(Member member)
        {
            var matchingMembers = this.DatabaseContext.selectMemberByIdAndPassword(member.username, member.password).ToList();

            if (matchingMembers.Count > 0)
            {
                var loggedInMemberId = matchingMembers[0].memberId;
                Session["currentMemberId"] = loggedInMemberId;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        public ActionResult RentalHistory()
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            var memberId = int.Parse(Session["currentMemberId"].ToString());
            var rentedItems = this.DatabaseContext.retrieveMembersRentals(memberId).ToList();

            return View(rentedItems);
        }
    }
}