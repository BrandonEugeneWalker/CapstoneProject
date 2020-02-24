using System;
using System.Windows.Forms;
using Capstone_Database.Model;

namespace Capstone_Desktop.View
{
    /// <summary>This form is used to get user confirmation about removing an employee.</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class RemoveConfirmationForm : Form
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="RemoveConfirmationForm"/> class.</summary>
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