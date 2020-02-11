using System;
using Capstone_Desktop.Database.employee;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>Class handles the business logic that controls the Login page of the application.</summary>
    public class LoginFormController
    {
        #region Properties

        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     <para>
        ///         Checks if the given id and password are valid, if it is valid the current user is changed and true is returned.
        ///     </para>
        ///     <para>False is returned if the employee is not a manager.</para>
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">password - The password cannot be null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">id - The id must be a positive number greater than 0.</exception>
        public bool TryToLogin(int id, string password)
        {
            try
            {
                var employee = SelectEmployeeSqlCommands.GetEmployeeByIdPassword(id, password);
                this.CurrentEmployee = employee;

                if (this.checkIfManager(employee))
                {
                    return true;
                }

                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        private bool checkIfManager(Employee employee)
        {
            return employee.IsManager;
        }

        #endregion
    }
}