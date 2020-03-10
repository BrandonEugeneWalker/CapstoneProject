using System.Linq;
using System.Net;
using System.Web.Mvc;
using Capstone_Database.Model;
using Capstone_Web_Members.ViewModels;

namespace Capstone_Web_Members.Controllers
{
    /// <summary>
    ///     Controller class for Member Management pages
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class MembersController : Controller
    {
        #region Data members

        public OnlineEntities DatabaseContext;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MembersController" /> class.
        /// </summary>
        public MembersController()
        {
            this.DatabaseContext = new OnlineEntities();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MembersController" /> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public MembersController(OnlineEntities databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }

        #endregion

        #region Methods

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
            var rentedItems = this.DatabaseContext.retrieveMembersRentals(memberId).ToList();
            var addresses = this.DatabaseContext.retrieveMembersAddresses(memberId).ToList();
            var memberProfileViewModel = new MemberProfileViewModel
                {MemberModel = member, ItemRentalsModel = rentedItems, AddressesModel = addresses};

            return View(memberProfileViewModel);
        }

        /// <summary>
        ///     Creates first instance of the Create / Registration page
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            return View();
        }

        /// <summary>
        ///     Creates the specified member from the Registration page.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        ///     Navigates to the Member Web Homepage
        ///     Creates / Registers the new member
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memberId,username,name,password,isLibrarian,isBanned")]
            Member member)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            if (ModelState.IsValid)
            {
                this.DatabaseContext.insertMember(member.username, member.name, member.password, 0);

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
        public ActionResult Edit([Bind(Include = "memberId,username,name,password,isLibrarian,isBanned")]
            Member member)
        {
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            if (ModelState.IsValid)
            {
                this.DatabaseContext.editMember(member.username, member.name, member.password, member.memberId);
                return RedirectToAction("Details");
            }

            return View(member);
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
            if (Session["currentMemberId"] == null)
            {
                return RedirectToAction("Login", "Members");
            }

            var matchingMembers = this.DatabaseContext.selectMemberByIdAndPassword(member.username, member.password)
                                      .ToList();

            if (matchingMembers.Count > 0)
            {
                var loggedInMemberId = matchingMembers[0].memberId;
                Session["currentMemberId"] = loggedInMemberId;
                return RedirectToAction("MediaLibrary", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Members");
        }

        #endregion
    }
}