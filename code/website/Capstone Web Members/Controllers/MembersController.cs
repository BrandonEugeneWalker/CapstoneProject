using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone_Database.Model;

namespace Capstone_Web_Members.Controllers
{
    /// <summary>
    /// Controller class for Member Management pages
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class MembersController : Controller
    {
        #region Data members

        private readonly OnlineEntities dbContext = new OnlineEntities();

        #endregion

        #region Methods

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>A list of all members</returns>
        public ActionResult Index()
        {
            return View(this.dbContext.Members.ToList());
        }

        /// <summary>
        /// Shows the details the specified member.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns page showcasing details of a given member
        /// </returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var member = this.dbContext.Members.Find(id);
            return member == null ? (ActionResult)HttpNotFound() : View(member);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        /// Navigates to the Member Web Homepage
        /// Creates / Registers the new member
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memberId,username,name,password,address,isLibrarian,isBanned")]
            Member member)
        {
            if (ModelState.IsValid)
            {
                this.dbContext.insertMember(member.username, member.name, member.password, member.address, 0);
                this.dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(member);
        }

        /// <summary>
        /// Edits the specified Member.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the edit view page for the selected Member
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var member = this.dbContext.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        /// <summary>
        /// Edits the specified member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        /// Returns the edit view page for the selected Member
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "memberId,username,name,password,address,isLibrarian,isBanned")]
            Member member)
        {
            if (ModelState.IsValid)
            {
                this.dbContext.Entry(member).State = EntityState.Modified;
                this.dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        /// <summary>
        /// Deletes the specified Member.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the Delete page of a given Member
        /// </returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var member = this.dbContext.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        /// <summary>
        /// Deletes the confirmed Member.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns to index after confirming member deletion
        /// </returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var member = this.dbContext.Members.Find(id);
            this.dbContext.Members.Remove(member);
            this.dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dbContext.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        /// <summary>
        /// Logs in the user and returns to the previous URL
        /// </summary>
        /// <returns>
        /// Returns to the previous page after logging in
        /// </returns>
        [AllowAnonymous]
        public ActionResult Login(Member member)
        {
            var matchingMembers = dbContext.selectMemberByIdAndPassword(member.username, member.password).ToList();

            if (matchingMembers.Count > 0)
            {
                // Session the member ID here
                var loggedInMemberId = matchingMembers[0].memberId;

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(Member member)
        //{
            

        //    return View();
        //}

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns>
        /// Returns to the Index, logged out
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //TODO remove session
            return RedirectToAction("Index", "Home");
        }
    }
}