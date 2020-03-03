using System;
using System.Windows.Forms;
using Capstone_Database.Model;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///   <para>This form is used to get user confirmation about removing an employee.</para>
    ///   <para>A simple form used by the ManageEmployeeForm to confirm if a user wants to remove an employee.</para>
    ///   <para>Opened by the ManageEmployeeForm.</para>
    ///   <para>Closes to the ManageEmployeeForm.</para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form"/>
    public partial class RemoveConfirmationForm : Form
    {
        #region Constructors

        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="RemoveConfirmationForm"/> class.</para>
        ///   <para>The RemoveConfirmationForm handles user interactions relating to confirming if a user would like to remove an employee from the database.</para>
        /// </summary>
        /// <param name="employee">The employee to ask about.</param>
        public RemoveConfirmationForm(Employee employee)
        {
            this.InitializeComponent();
            if (employee == null)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }

            this.employeeNameLabel.Text = employee.name;
        }

        #endregion

        #region Methods

        private void yesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        #endregion
    }
}