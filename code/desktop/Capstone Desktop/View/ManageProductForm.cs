using System;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///     <para>This form is used to managed view stock items in the database.</para>
    ///     <para>The ManageProductForm is opened by the LoginForm and the ManageEmployeesForm.</para>
    ///     <para>The ManageProductForm can open the ManageRentalsForm and the ManageEmployeesForm.</para>
    ///     <para>
    ///         The ManageProductForm keeps track of the currently logged in employee and changes available transitions
    ///         accordingly.
    ///     </para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ManageProductForm : Form
    {
        #region Data members

        private ManageProductsController manageProductsController;

        #endregion

        #region Properties


        #endregion

        #region Constructors

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="ManageProductForm" /> class.</para>
        ///     <para>The ManageProductForm handles the user interactions relating to managing items in the database.</para>
        /// </summary>
        /// <param name="loggedInEmployee">The logged in employee.</param>
        public ManageProductForm()
        {
            this.InitializeComponent();
            this.manageProductsController = new ManageProductsController();
        }

        #endregion

        #region Methods

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
            this.getData();
        }

        private void ManageItemsForm_Load(object sender, EventArgs e)
        {
            this.getData();
        }

        private void getData()
        {
            try
            {
                this.productGridView.DataSource = this.manageProductsController.GetAllProducts();

                this.refreshTable();
            }
            catch (MySqlException)
            {
                MessageBox.Show(@"There was a problem connecting to the database, is the VPN enabled?");
            }
        }

        private void refreshTable()
        {
            this.productGridView.Columns[5].Visible = false;
        }

        #endregion
    }
}