using System;
using System.Windows.Forms;
using Capstone_Desktop.Database.employee;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    public partial class AddEmployeeForm : Form
    {
        #region Constructors

        public AddEmployeeForm()
        {
            this.InitializeComponent();
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
    }
}