using System;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>This class handles interactions between the database and the LoginForm.</para>
    ///     <para>Primarily handles logging into the system using information given by the user.</para>
    /// </summary>
    public class LoginController
    {
        #region Properties

        /// <summary>
        ///   <para>
        ///  Gets or sets the capstone database handler.
        /// Handles interactions with the database.</para>
        /// </summary>
        /// <value>The capstone database handler.</value>
        public IDbContextHandler CapstoneDatabaseHandler { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="LoginController" /> class.
        ///     </para>
        ///     <para>Handles interactions with the database, acting as an intermediary.</para>
        /// </summary>
        /// <Precondition> None </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public LoginController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="LoginController" /> class.
        ///     </para>
        ///     <para>Handles interactions with the database handler, acting as an intermediary.</para>
        /// </summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler.</param>
        /// <exception cref="ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition> The database handler cannot be null! </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public LoginController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }

        #endregion

        #region Methods

        /// <summary>
        ///     <para>
        ///         Gets the employee by identifier and password.
        ///     </para>
        ///     <para>
        ///         <font color="#333333">
        ///             id must be a positive integer, password cannot be null or empty, database cannot be null
        ///             or empty.
        ///         </font>
        ///     </para>
        ///     <para></para>
        /// </summary>
        /// <param name="id">The employee's id.</param>
        /// <param name="password">The employee's password.</param>
        /// <returns>Null if not found, the employee otherwise.</returns>
        /// <exception cref="ArgumentOutOfRangeException">id - The id must be a positive integer greater than zero.</exception>
        /// <exception cref="ArgumentNullException">
        ///     password - The password cannot be null or empty!
        ///     or
        ///     capstoneDbContext - The database to get the employee from must not be null!
        /// </exception>
        /// <Precondition> Id must be a positive integer, password cannot be null or empty. </Precondition>
        /// <Postcondition> Returns an employee if found, null if not. </Postcondition>
        public Employee GetEmployeeByIdAndPassword(int id, string password)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id),
                    @"The id must be a positive integer greater than zero.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), @"The password cannot be null or empty!");
            }

            return this.CapstoneDatabaseHandler.GetEmployeeByIdAndPassword(id, password);
        }

        #endregion
    }
}