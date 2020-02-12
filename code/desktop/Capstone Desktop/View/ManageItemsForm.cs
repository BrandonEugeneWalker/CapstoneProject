using System;
using System.Data.Entity;
using System.Windows.Forms;
using Capstone_Database.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    /// <summary>This form is used to managed view stock items in the database.</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ManageItemsForm : Form
    {
        #region Data members

        private readonly BindingSource itemListSource = new BindingSource();

        private readonly OnlineEntities capstoneDatabaseContext;

        #endregion

        #region Properties

        /// <summary>Gets or sets the current employee.</summary>
        /// <value>The current employee.</value>
        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ManageItemsForm" /> class.</summary>
        /// <param name="loggedInEmployee">The logged in employee.</param>
        public ManageItemsForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.capstoneDatabaseContext = new OnlineEntities();
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

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
        {
            this.itemsGridView.DataSource = this.itemListSource;
            this.getData();
        }

        private void getData()
        {
            try
            {
                this.capstoneDatabaseContext.Stocks.Load();
                this.itemListSource.DataSource = this.capstoneDatabaseContext.Stocks.Local.ToBindingList();

                for (var i = 0; i < this.itemsGridView.Columns.Count; i++)
                {
                    this.itemsGridView.Columns[i].MinimumWidth = 100;
                }

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
                Show();
            }
        }

        private void manageRentalsButton_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}