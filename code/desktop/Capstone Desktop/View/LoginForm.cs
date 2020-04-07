using System;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Capstone_Desktop.View;

namespace Capstone_Desktop
{
    /// <summary>
    ///     <para>The login page of the application.</para>
    ///     <para>The LoginForm is the form that will greet a user upon starting the program.</para>
    ///     <para>
    ///         The LoginForm allows a user to verify their status as an employee in order to access other parts of the
    ///         system.
    ///     </para>
    ///     <para>
    ///         The LoginForm is able to tell the difference between a regular employee and a manager, sending them to
    ///         different places depending on their status.
    ///     </para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LoginForm : Form
    {
        #region Data members

        private Employee currentEmployee;

        private readonly LoginController loginController;

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="LoginForm" /> class.</para>
        ///     <para>The LoginForm exits to the operating system.</para>
        ///     <para>The LoginForm will open the ManageItemsForm or ManageEmployeesForm depending on the login status.</para>
        ///     <para>The LoginForm will provide feedback on user input.</para>
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.loginController = new LoginController();
        }

        #endregion

        #region Methods

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var id = int.Parse(this.usernameTextbox.Text);
            var password = this.passwordTextbox.Text;

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
                this.currentEmployee =
                    this.loginController.GetEmployeeByIdAndPassword(id, password);

                return this.currentEmployee.isManager == true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}