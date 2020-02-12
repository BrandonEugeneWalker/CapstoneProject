using System;
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

        /// <summary>Initializes a new instance of the <see cref="LoginForm"/> class.</summary>
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
                    Hide();
                    manageEmployeeForm.ShowDialog();
                    this.emptyTextBoxes();
                    Show();
                }
                else if (this.LoginController.CurrentEmployee != null)
                {
                    var manageItemsForm = new ManageItemsForm(this.LoginController.CurrentEmployee);
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

        #endregion
    }
}