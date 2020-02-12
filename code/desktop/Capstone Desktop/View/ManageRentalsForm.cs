using System;
using System.Data.Entity;
using System.Windows.Forms;
using Capstone_Database.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    /// <summary>This form is used to view and manage the status of the rentals.</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ManageRentalsForm : Form
    {
        #region Data members

        private readonly BindingSource rentalListSource = new BindingSource();

        private readonly OnlineEntities capstoneDatabaseContext;

        #endregion

        #region Properties

        /// <summary>Gets or sets the current employee.</summary>
        /// <value>The current employee.</value>
        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ManageRentalsForm" /> class.</summary>
        /// <param name="loggedInEmployee">The logged in employee.</param>
        public ManageRentalsForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.CurrentEmployee = loggedInEmployee;
            this.capstoneDatabaseContext = new OnlineEntities();
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

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
        {
            //WaitingShipment
            //WaitingReturn
            this.rentalGridView.DataSource = this.rentalListSource;
            this.rentalStatusComboBox.SelectedIndex = 0;
            //this.rentedButton.Enabled = true;
            //this.returnButton.Enabled = false;
            this.getData();
        }

        private void getData()
        {
            try
            {
                this.capstoneDatabaseContext.ItemRentals.Load();
                this.rentalListSource.DataSource = this.capstoneDatabaseContext.ItemRentals.Local.ToBindingList();

                for (var i = 0; i < this.rentalGridView.Columns.Count; i++)
                {
                    this.rentalGridView.Columns[i].MinimumWidth = 100;
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
            this.rentalGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
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

        private void manageItemsButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rentedButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow currentRow in this.rentalGridView.SelectedRows)
            {
                var currentItem = (ItemRental) currentRow.DataBoundItem;

                if (currentItem.status.Equals("WaitingShipment"))
                {
                    currentItem.status = "Rented";
                    this.capstoneDatabaseContext.SaveChanges();
                    this.rentalGridView.Refresh();
                }
                else
                {
                    MessageBox.Show(@"That rental cannot be updated to shipped status.");
                }
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow currentRow in this.rentalGridView.SelectedRows)
            {
                var currentItem = (ItemRental) currentRow.DataBoundItem;

                if (currentItem.status.Equals("WaitingReturn"))
                {
                    currentItem.status = "Returned";
                    this.capstoneDatabaseContext.SaveChanges();
                    this.rentalGridView.Refresh();
                }
                else
                {
                    MessageBox.Show(@"That rental cannot be updated to returned status.");
                }
            }
        }

        private void rentalStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion
    }
}