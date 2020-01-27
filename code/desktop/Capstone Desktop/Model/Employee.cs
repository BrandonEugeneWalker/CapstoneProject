using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Desktop.Model
{

    /// <summary>Represents a local instance of a Employee. Stores necessary information about an Employee for modification and retreival.</summary>
    public class Employee
    {

        /// <summary>Gets or sets the employee identifier.</summary>
        /// <value>The employee identifier.</value>
        public int EmployeeId { get; set; }

        /// <summary>Gets or sets the name of the employee.</summary>
        /// <value>The name of the employee.</value>
        public string EmployeeName { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is manager.</summary>
        /// <value>
        ///   <c>true</c> if this instance is manager; otherwise, <c>false</c>.</value>
        public bool IsManager { get; set; }

        public Employee(int id, string name, bool isManager)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "The employee id must be greater than zero.");
            }

            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "The employee's name cannot be null or empty.");
            }

            this.EmployeeId = id;
            this.EmployeeName = name;
            this.IsManager = isManager;
        }

    }
}
