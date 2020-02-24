using System;
using System.Linq;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.View;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop
{
    /// <summary>The login page of the application.</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LoginForm : Form
    {
        #region Data members

        private Employee currentEmployee;

        private readonly OnlineEntities capstoneDatabaseContext = new OnlineEntities();

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="LoginForm" /> class.</summary>
        public LoginForm()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var id = int.Parse(this.usernameTextbox.Text);
            var password = this.passwordTextbox.Text;

            try
            {
                var results = this.tryToLogin(id, password);
                if (results)
                {
                    var manageEmployeeForm = new ManageEmployeeForm(this.currentEmployee);
                    Hide();
                    manageEmployeeForm.ShowDialog();
                    this.emptyTextBoxes();
                    Show();
                }
                else if (this.currentEmployee != null)
                {
                    var manageItemsForm = new ManageItemsForm(this.currentEmployee);
                    Hide();
                    manageItemsForm.ShowDialog();
                    this.emptyTextBoxes();
                    Show();
                }
                else
                {
                    this.showLoginError();
                }
            }
            catch (MySqlException)
            {
                this.showLoginError();
            }
        }

        private void emptyTextBoxes()
        {
            this.usernameTextbox.Text = "";
            this.passwordTextbox.Text = "";
        }

        private void showLoginError()
        {
            MessageBox.Show(@"Was unable to login.");
            this.emptyTextBoxes();
        }

        private bool tryToLogin(int id, string password)
        {
            try
            {
                var employee =
                    this.capstoneDatabaseContext.selectEmployeeByIdAndPassword(id, password).ToList()[0];
                this.currentEmployee = employee;

                if (employee.isManager == true)
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

        #endregion
    }
}