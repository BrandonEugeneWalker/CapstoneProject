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
        ///     Index of the Website, required for running of Website. Redirects to Media Library. Redirects to Login if no login
        ///     session found.
        /// </summary>
        /// <returns>Media Library Page</returns>
        public ActionResult Index()
        {
            if (Session["currentLibrarianId"] != null)
            {
                return View(this.DatabaseContext.Members.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        ///     Shows the details of the logged in member, showing their Member Profile info, their Addresses, and their Rental
        ///     History. Addresses allows Creation, Editing, and Removal.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <returns>
        ///     Returns page showcasing details of the logged in member
        /// </returns>
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

            return View(memberProfileViewModel);
        }

        /// <summary>
        ///     Page for the Create Member form.
        /// </summary>
        /// <returns>
        ///     Returns the create view page
        /// </returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     Creates the specified member from the Registration page after the Create form is submitted. Calls database to
        ///     insert the new Member data. Redirects to Login if valid, reloads the Registration page if invalid.
        /// </summary>
        /// <param name="member">The member object created in the Create Form.</param>
        /// <returns>
        ///     Returns to the Member Web Login
        ///     Returns to the Create form if failed
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memberId,username,name,password,isLibrarian,isBanned")]
            Member member)
        {
            if (ModelState.IsValid)
            {
                this.DatabaseContext.insertMember(member.username, member.name, member.password, 0);

                return RedirectToAction("Login");
            }

            return View(member);
        }

        /// <summary>
        ///     Page for the Edit Member form, all fields except for password will default contain current information. Returns
        ///     View of form. If the memberId parameter is null or the Member is not found, returns an error.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     Returns the edit view page for the selected Member
        /// </returns>
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
        ///     Edits Member after Edit form is submitted. Calls Database to edit the given member to the form's new information.
        ///     Redirects to Member Profile if valid, Returns to Edit form if invalid.
        ///     Redirects to Login if Login is invalid (prevents accessing while logged out / unauthorized)
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>
        ///     Returns to the Member Profile
        ///     Returns to the Edit form if failed
        /// </returns>
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.DatabaseContext.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        ///     Logs in the user and Returns to Media Library
        ///     If login is invalid, returns to the Login Page
        /// </summary>
        /// <returns>
        ///     Returns to Media Library
        /// </returns>
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