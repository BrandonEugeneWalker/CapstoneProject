using System;
using System.Drawing;
using System.Windows.Forms;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Database.employee;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    public partial class AddEmployeeForm : Form
    {
        #region Constructors

        private AddEmployeeFormController addEmployeeFormController { get; set; }

        private static string PASSWORD_REQUIREMENTS =
            "A password must be at least 6 characters long, " +
            "\n Contains at least one: " +
            "\n * Number " +
            "\n * Lowercase Letter " +
            "\n * Uppercase Letter " +
            "\n * Special Character " +
            "\n Passwords have a maximum length of 16 characters.";

        public AddEmployeeForm()
        {
            this.InitializeComponent();
            this.addEmployeeFormController = new AddEmployeeFormController();
            this.submitButton.Enabled = false;
            this.passwordRequirementsLabel.Text = PASSWORD_REQUIREMENTS;
            this.isValidLabel.ForeColor = Color.Red;
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
                var newEmployee = new Employee(id, name, isManager);
                InsertEmployeeSqlCommands.InsertEmployee(newEmployee, password);
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

        #endregion

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
    }
}