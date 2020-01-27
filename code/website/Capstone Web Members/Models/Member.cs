using System;

namespace Capstone_Web_Members.Models
{
    /// <summary>
    /// Defines a member logging into the website to borrow media
    /// </summary>
    public class Member
    {

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        public int MemberId { get; set; }


        //TODO Username/Password might store separately
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is librarian.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is librarian; otherwise, <c>false</c>.
        /// </value>
        public bool IsLibrarian { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="isLibrarian">if set to <c>true</c> [is librarian].</param>
        /// <exception cref="ArgumentOutOfRangeException">memberId - Member ID must be greater than zero</exception>
        /// <exception cref="ArgumentNullException">
        /// userName - Member Username can not be Null or Empty.
        /// or
        /// password - Member Password can not be Null or Empty.
        /// or
        /// firstName - Member first name can not be Null or Empty.
        /// or
        /// lastName - Member last name can not be Null or Empty.
        /// </exception>
        public Member(int memberId, string userName, string password, string firstName, string lastName, bool isLibrarian)
        {
            if (memberId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(memberId), "Member ID must be greater than zero");
            }

            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Member Username can not be Null or Empty.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), "Member Password can not be Null or Empty.");
            }

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException(nameof(firstName), "Member first name can not be Null or Empty.");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException(nameof(lastName), "Member last name can not be Null or Empty.");
            }

            this.MemberId = memberId;

            //TODO might store separately
            this.UserName = userName;
            this.Password = password;
            //

            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsLibrarian = isLibrarian;
        }
    }
}