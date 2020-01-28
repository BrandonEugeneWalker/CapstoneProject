using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone_Desktop.Database.employee;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>Class handles the business logic that controls the Login page of the application.</summary>
    public class LoginFormController
    {
        public Employee CurrentEmployee { get; set; }

        /// <summary>
        ///   <para>
        /// Checks if the given id and password are valid, if it is valid the current user is changed and true is returned.</para>
        ///   <para>False is returned if the employee is not a manager.</para>
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">password - The password cannot be null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">id - The id must be a positive number greater than 0.</exception>
        public bool TryToLogin(int id, string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), "The password cannot be null or empty.");
            }

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "The id must be a positive number greater than 0.");
            }

            try
            {
                 var employee = SelectEmployeeSqlCommands.GetEmployeeByIdPassword(id, password);

                if (this.checkIfManager(employee))
                {
                    this.CurrentEmployee = employee;
                    return true;
                }
                else
                {
                    return false;
                }
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
            return employee.IsManager == true;
        }

    }
}
