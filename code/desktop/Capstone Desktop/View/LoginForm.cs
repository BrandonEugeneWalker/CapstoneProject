using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Capstone_Desktop.Controller;
using Capstone_Desktop.View;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop
{
    /// <summary>The login page of the application.</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LoginForm : Form
    {
        #region Properties

        /// <summary>Gets or sets the login controller.</summary>
        /// <value>The login controller.</value>
        public LoginFormController LoginController { get; set; }

        #endregion

        #region Constructors

        public LoginForm()
        {
            this.InitializeComponent();
            this.LoginController = new LoginFormController();
        }

        #endregion

        #region Methods

        private void loginButton_Click(object sender, EventArgs e)
        {
            var id = int.Parse(this.usernameTextbox.Text);
            var password = this.passwordTextbox.Text;

            try
            {
                var results = this.LoginController.TryToLogin(id, password);
                if (results)
                {
                    var manageEmployeeForm = new ManageEmployeeForm(this.LoginController.CurrentEmployee);
                    this.Hide();
                    manageEmployeeForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show(@"Access denied, contact a supervisor.");
                    this.usernameTextbox.Text = "";
                    this.passwordTextbox.Text = "";
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(@"Was unable to login.");
                this.usernameTextbox.Text = "";
                this.passwordTextbox.Text = "";
            }
        }

        #endregion
    }
}