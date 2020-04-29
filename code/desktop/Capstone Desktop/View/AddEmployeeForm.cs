using System;
using System.Drawing;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///     <para>This form is used to add employees to the database.</para>
    ///     <para></para>
    ///     <para>
    ///         The form contains text box controls for user input and wil provide feedback over user input such as
    ///         passwords.
    ///     </para>
    ///     <para>This form will return to the ManageEmployees view upon closing.</para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AddEmployeeForm : Form
    {
        #region Data members

        private static readonly string PASSWORD_REQUIREMENTS =
            "A password must be at least 6 characters long, " +
            "\n Contains at least one: " +
            "\n * Number " +
            "\n * Lowercase Letter " +
            "\n * Uppercase Letter " +
            "\n * Special Character " +
            "\n Passwords have a maximum length of 16 characters.";

        #endregion

        #region Properties

        private AddEmployeeFormController EmployeeController { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="AddEmployeeForm" /> class.</para>
        ///     <para>The AddEmployeeForm is responsible for the user interactions related to adding an employee.</para>
        /// </summary>
        public AddEmployeeForm()
        {
            this.InitializeComponent();
            this.EmployeeController = new AddEmployeeFormController();
            this.submitButton.Enabled = false;
            this.passwordRequirementsLabel.Text = PASSWORD_REQUIREMENTS;
            this.isValidLabel.ForeColor = Color.Red;

        }

        #endregion

        #region Methods

        private void submitButton_Click(object sender, EventArgs e)
        {
            var password = this.passwordTextBox.Text;
            var isManager = this.isManagerCheckBox.Checked;
            var name = this.nameTextBox.Text;

            try
            {
                this.EmployeeController.AddEmployee(password, isManager, name);
                Close();
            }
            catch (ArgumentNullException argumentNullException)
            {
                MessageBox.Show(argumentNullException.Message);
            }
            catch (MySqlException mySqlException)
            {
                MessageBox.Show(mySqlException.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool isTextBoxNotEmpty()
        {
            return !String.IsNullOrEmpty(this.nameTextBox.Text);
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            var password = this.passwordTextBox.Text;
            var isValid = this.EmployeeController.IsValidPassword(password);

            if (isValid)
            {
                if (this.isTextBoxNotEmpty())
                {
                    this.submitButton.Enabled = true;
                }
                else
                {
                    this.submitButton.Enabled = false;
                }
                this.isValidLabel.Text = @"Valid";
                this.isValidLabel.ForeColor = Color.Green;
            }
            else
            {
                this.isValidLabel.Text = @"Invalid";
                this.isValidLabel.ForeColor = Color.Red;
                this.submitButton.Enabled = false;
            }

        }

        #endregion
    }
}