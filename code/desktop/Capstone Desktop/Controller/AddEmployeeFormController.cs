using System;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     This class acts as a controller for the AddEmployeeForm. Because of this the class contains methods related to
    ///     handling data given by the user in its parent form.
    /// </summary>
    public class AddEmployeeFormController
    {
        #region Properties

        /// <summary>Gets or sets the capstone database handler.</summary>
        /// <value>The capstone database handler, used for interactions with the database.</value>
        public IDbContextHandler CapstoneDatabaseHandler { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="AddEmployeeFormController" /> class.
        ///     </para>
        ///     <para>Separates the view from database logic.</para>
        /// </summary>
        public AddEmployeeFormController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="AddEmployeeFormController" /> class.
        ///     </para>
        ///     <para>Separates the view from database logic. Constructor overload allows for mocking.</para>
        /// </summary>
        /// <param name="capstoneDbContextHandler">The capstone database context handler.</param>
        /// <exception cref="ArgumentNullException">capstoneDbContextHandler - The database handler cannot be null!</exception>
        public AddEmployeeFormController(IDbContextHandler capstoneDbContextHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDbContextHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDbContextHandler),
                                               @"The database handler cannot be null!");
        }

        #endregion

        #region Methods

        /// <summary>
        ///     <para>Determines whether [is valid password] [the specified password]. </para>
        ///     <para>Password requirements are as follows:</para>
        ///     <para>* Contains at least one lowercase letter.</para>
        ///     <para>* Contains at least one uppercase letter.</para>
        ///     <para>* Contains at least one symbol.</para>
        ///     <para>* Must be a minimum of 6 characters long.</para>
        ///     <para>* Cannot be longer than 16 characters.</para>
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>
        ///     <c>true</c> if [is valid password] [the specified password]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            var lowerCases = 0;
            var upperCases = 0;
            var numbers = 0;
            var specialChars = 0;

            foreach (var currentChar in password)
            {
                if (char.IsNumber(currentChar))
                {
                    numbers++;
                }

                if (char.IsLower(currentChar))
                {
                    lowerCases++;
                }

                if (char.IsUpper(currentChar))
                {
                    upperCases++;
                }

                if (char.IsPunctuation(currentChar) | char.IsSymbol(currentChar))
                {
                    specialChars++;
                }
            }

            var hasLowerCase = lowerCases > 0;
            var hasUpperCase = upperCases > 0;
            var hasNumbers = numbers > 0;
            var hasSpecialChars = specialChars > 0;
            var isMinimumLength = password.Length >= 6;
            var isNotPastMaximumLength = password.Length <= 16;

            var isValid = hasLowerCase && hasUpperCase && hasNumbers && hasSpecialChars && isMinimumLength &&
                          isNotPastMaximumLength;

            return isValid;
        }

        public void AddEmployee(string password, bool isManager, string name)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), @"The password cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), @"The name cannot be null or empty!");
            }

            var addingEmployee = new Employee {
                password = password,
                isManager = isManager,
                name = name
            };
            this.CapstoneDatabaseHandler.AddEmployee(addingEmployee);
        }

        #endregion
    }
}