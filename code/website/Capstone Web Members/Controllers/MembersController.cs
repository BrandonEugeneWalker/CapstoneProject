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

        /// <summary>
        ///     The database context
        /// </summary>
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
        ///     Lists index list of all members
        ///     <Precondition>Session["currentLibrarianId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>Members Index page</returns>
        public ActionResult Index()
        {
            if (Session["currentLibrarianId"] != null)
            {
                return View(this.DatabaseContext.retrieveNonlibrarians());
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        ///     Shows the details of the logged in member including their profile, current Addresses, and ItemRental history
        ///     <Precondition>Session["currentMemberId"] != null OR Session["currentLibrarianId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="memberId">memberId of given Member</param>
        /// <returns>Member's profile page</returns>
        public ActionResult Details(int? memberId)
        {
            if (Session["currentMemberId"] == null && Session["currentLibrarianId"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Login", "Members");
            }

            if (memberId == null)
            {
                memberId = int.Parse(Session["currentMemberId"].ToString());
            }

            var member = this.DatabaseContext.Members.Find(memberId);
            var rentedItems = this.DatabaseContext.retrieveMembersRentals(memberId).ToList();
            var addresses = this.DatabaseContext.retrieveMembersAddresses(memberId).ToList();
            var memberProfileViewModel = new MemberProfileViewModel
                {MemberModel = member, ItemRentalsModel = rentedItems, AddressesModel = addresses};

            if (Session["currentLibrarianId"] != null)
            {
                memberProfileViewModel.LibrarianLoggedIn = true;
            }

            return View(memberProfileViewModel);
        }

        /// <summary>
        ///     Form for registering/creating a Member.
        ///     <Precondition>None</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>Create Member page</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     Creates the specified member from the Registration page
        ///     <Precondition>None</Precondition>
        ///     <Postcondition>Member object inserted to Members table</Postcondition>
        /// </summary>
        /// <param name="member">The member object created in the Create Form.</param>
        /// <returns>The login page if successful, Create page is unsuccessful</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memberId,username,name,password")]
            Member member)
        {
            if (ModelState.IsValid)
            {
                this.DatabaseContext.insertMember(member.username, member.name, member.password);

                return RedirectToAction("Login");
            }

            return View(member);
        }

        /// <summary>
        ///     Form for editing a Member
        ///     <Precondition>Session["currentMemberId"] != null OR Session["currentLibrarianId"] != null</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Returns the edit page for the selected Member</returns>
        public ActionResult Edit(int? id)
        {
            if (Session["currentMemberId"] == null && Session["currentLibrarianId"] == null)
            {
                Session.Abandon();
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
        ///     Edits Member after Edit form is submitted
        ///     <Precondition>Session["currentMemberId"] != null OR Session["currentLibrarianId"] != null</Precondition>
        ///     <Postcondition>Updates Member object in Members table</Postcondition>
        /// </summary>
        /// <param name="member">The member object edited in the Edit Form</param>
        /// <returns>Member's profile if successful, edit form if unsuccessful</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "memberId,username,name,password,isLibrarian,isBanned")]
            Member member)
        {
            if (Session["currentMemberId"] == null && Session["currentLibrarianId"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Login", "Members");
            }

            if (ModelState.IsValid)
            {
                this.DatabaseContext.editMember(member.username, member.name, member.password, member.memberId);
                return RedirectToAction("Details");
            }

            return View(member);
        }

        /// <summary>
        ///     Bans selected member.
        ///     <Precondition>none</Precondition>
        ///     <Postcondition>Updates IsBanned field for member object</Postcondition>
        /// </summary>
        /// <param name="memberId">The memberId of member to ban.</param>
        /// <returns>Index of Members</returns>
        public ActionResult BanMember(int memberId)
        {
            this.DatabaseContext.banMember(memberId);
            return RedirectToAction("Index");
        }

        /// <summary>
        ///     UnBans selected member.
        ///     <Precondition>none</Precondition>
        ///     <Postcondition>Updates IsBanned field for member object</Postcondition>
        /// </summary>
        /// <param name="memberId">The memberId of member to unban.</param>
        /// <returns>Index of Members</returns>
        public ActionResult UnBanMember(int memberId)
        {
            this.DatabaseContext.unBanMember(memberId);
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
        ///     Logs in the user and returns to HomeController Index
        ///     <Precondition>None</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <param name="member">The member object that is logging in</param>
        /// <returns>HomeController Index if true, login form if false</returns>
        [AllowAnonymous]
        public ActionResult Login(Member member)
        {
            var matchingMembers = this.DatabaseContext.selectMemberByIdAndPassword(member.username, member.password)
                                      .ToList();

            if (matchingMembers.Count > 0 && matchingMembers[0].isLibrarian.Equals(1))
            {
                var loggedInMemberId = matchingMembers[0].memberId;
                Session["currentLibrarianId"] = loggedInMemberId;
                return RedirectToAction("Index", "Home");
            }

            if (matchingMembers.Count > 0)
            {
                var loggedInMemberId = matchingMembers[0].memberId;
                Session["currentMemberId"] = loggedInMemberId;
                return RedirectToAction("MediaLibrary", "Home");
            }

            return View();
        }

        /// <summary>
        ///     Logs current Member out
        ///     <Precondition>None</Precondition>
        ///     <Postcondition>None</Postcondition>
        /// </summary>
        /// <returns>Login page</returns>
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