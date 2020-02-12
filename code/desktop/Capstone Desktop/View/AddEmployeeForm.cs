using System;
using System.Drawing;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    /// <summary>This form is used to add employees to the database.</summary>
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

        private readonly OnlineEntities capstoneDatabaseContext;

        #endregion

        #region Properties

        private AddEmployeeFormController addEmployeeFormController { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="AddEmployeeForm" /> class.</summary>
        public AddEmployeeForm()
        {
            this.InitializeComponent();
            this.addEmployeeFormController = new AddEmployeeFormController();
            this.submitButton.Enabled = false;
            this.passwordRequirementsLabel.Text = PASSWORD_REQUIREMENTS;
            this.isValidLabel.ForeColor = Color.Red;

            this.capstoneDatabaseContext = new OnlineEntities();
        }

        #endregion

        #region Methods

        private void submitButton_Click(object sender, EventArgs e)
        {
            var id = (int) this.idNummericUpDown.Value;
            var password = this.passwordTextBox.Text;
            var isManager = this.isManagerCheckBox.Checked;
            var name = this.nameTextBox.Text;

            try
            {
                var newEmployee = new Employee {
                    employeeId = id,
                    password = password,
                    isManager = isManager,
                    name = name
                };
                this.capstoneDatabaseContext.Employees.Add(newEmployee);
                this.capstoneDatabaseContext.SaveChanges();
                Close();
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                MessageBox.Show(argumentOutOfRangeException.Message);
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

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            var password = this.passwordTextBox.Text;
            var isValid = this.addEmployeeFormController.IsValidPassword(password);

            if (isValid)
            {
                this.isValidLabel.Text = @"Valid";
                this.isValidLabel.ForeColor = Color.Green;
                this.submitButton.Enabled = true;
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