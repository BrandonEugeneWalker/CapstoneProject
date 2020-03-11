using System;
using System.Data.Entity;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///     <para>This form is used to managed view stock items in the database.</para>
    ///     <para>The ManageItemsForm is opened by the LoginForm and the ManageEmployeesForm.</para>
    ///     <para>The ManageItemsForm can open the ManageRentalsForm and the ManageEmployeesForm.</para>
    ///     <para>
    ///         The ManageItemsForm keeps track of the currently logged in employee and changes available transitions
    ///         accordingly.
    ///     </para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ManageItemsForm : Form
    {
        #region Data members

        private readonly BindingSource itemListSource = new BindingSource();

        private readonly OnlineEntities capstoneDatabaseContext;

        private ManageItemsController manageItemsController;

        #endregion

        #region Properties

        /// <summary>Gets or sets the current employee.</summary>
        /// <value>The current employee.</value>
        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="ManageItemsForm" /> class.</para>
        ///     <para>The ManageItemsForm handles the user interactions relating to managing items in the database.</para>
        /// </summary>
        /// <param name="loggedInEmployee">The logged in employee.</param>
        public ManageItemsForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.capstoneDatabaseContext = new OnlineEntities();
            this.manageItemsController = new ManageItemsController();
            this.CurrentEmployee = loggedInEmployee;
            if (this.CurrentEmployee.isManager == true)
            {
                this.managerButton.Enabled = true;
            }
        }

        #endregion

        #region Methods

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void SubmitChangesButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void ManageItemsForm_Load(object sender, EventArgs e)
        {
            this.itemsGridView.DataSource = this.itemListSource;
            this.getData();
        }

        private void getData()
        {
            try
            {
                this.itemListSource.DataSource = this.manageItemsController.GetAllStock(this.capstoneDatabaseContext);

                this.refreshTable();
            }
            catch (MySqlException)
            {
                MessageBox.Show(@"There was a problem connecting to the database, is the VPN enabled?");
            }
        }

        private void refreshTable()
        {
            this.itemsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void managerButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentEmployee.isManager == true)
            {
                Hide();
                var manageEmployeeForm = new ManageEmployeeForm(this.CurrentEmployee);
                manageEmployeeForm.ShowDialog();
                Close();
            }
        }

        private void manageRentalsButton_Click(object sender, EventArgs e)
        {
            Hide();
            var manageRentalsForm = new ManageRentalsForm(this.CurrentEmployee);
            manageRentalsForm.ShowDialog();
            Close();
        }

        private void viewHistoryButton_Click(object sender, EventArgs e)
        {
            StockDetailView currentDetailStock = null;

            if (this.itemsGridView.SelectedRows.Count != 0)
            {
                currentDetailStock = (StockDetailView) this.itemsGridView.SelectedRows[0].DataBoundItem;
            }

            if (currentDetailStock != null)
            {
                this.capstoneDatabaseContext.Stocks.Load();
                var currentStock = this.capstoneDatabaseContext.Stocks.Find(currentDetailStock.stockId);
                var itemHistoryForm = new ItemHistoryForm(currentStock);
                itemHistoryForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"No stock item selected to view the history of.");
            }
        }

        #endregion
    }
}