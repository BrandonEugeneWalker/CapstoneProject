using System;
using System.Data.Entity;
using System.Linq;
using Capstone_Database.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///   <para>This class handles interactions between the database and the LoginForm.</para>
    ///   <para>Primarily handles logging into the system using information given by the user.</para>
    /// </summary>
    public class LoginController
    {

        /// <summary>
        ///   <para>
        ///  Gets the employee by identifier and password.</para>
        ///   <para>
        ///     <font color="#333333">id must be a positive integer, password cannot be null or empty, database cannot be null or empty.</font>
        ///   </para>
        ///   <para></para>
        /// </summary>
        /// <param name="id">The employee's id.</param>
        /// <param name="password">The employee's password.</param>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <returns>Null if not found, the employee otherwise.</returns>
        /// <exception cref="ArgumentOutOfRangeException">id - The id must be a positive integer greater than zero.</exception>
        /// <exception cref="ArgumentNullException">password - The password cannot be null or empty!
        /// or
        /// capstoneDbContext - The database to get the employee from must not be null!</exception>
        public Employee GetEmployeeByIdAndPassword(int id, string password, OnlineEntities capstoneDbContext)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), @"The id must be a positive integer greater than zero.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), @"The password cannot be null or empty!");
            }

            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext), @"The database to get the employee from must not be null!");
            }

            capstoneDbContext.Employees.Load();

            return capstoneDbContext.selectEmployeeByIdAndPassword(id, password).First();
        }
    }
}