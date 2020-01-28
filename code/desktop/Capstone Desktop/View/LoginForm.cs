using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Database.employee;
using Capstone_Desktop.Model;
using Capstone_Desktop.View;

namespace Capstone_Desktop
{
    /// <summary>The login page of the application.</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LoginForm : Form
    {

        /// <summary>Gets or sets the login controller.</summary>
        /// <value>The login controller.</value>
        public LoginFormController LoginController { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            this.LoginController = new LoginFormController();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.usernameTextbox.Text);
            string password = this.passwordTextbox.Text;

            try
            {
                var results = this.LoginController.TryToLogin(id, password);
                if (results)
                {
                    ManageEmployeeForm manageEmployeeForm = new ManageEmployeeForm(this.LoginController.CurrentEmployee);
                    manageEmployeeForm.Show();
                }
                else
                {
                    Form errorDialog = new Form
                    {
                        Text = "Permission Denied, contact a supervisor."
                    };
                    errorDialog.ShowDialog(this);
                    this.usernameTextbox.Text = "";
                    this.passwordTextbox.Text = "";
                }
            }
            catch (SqlException)
            {
                Form errorDialog = new Form
                {
                    Text = "Login Failed."
                };
                errorDialog.ShowDialog(this);
                this.usernameTextbox.Text = "";
                this.passwordTextbox.Text = "";
            }
        }
    }
}
