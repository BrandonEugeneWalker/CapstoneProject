using System;
using System.Data.Entity;
using System.Linq;
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

        private void ManageRentalsForm_Load(object sender, EventArgs e)
        {
            this.rentalGridView.DataSource = this.rentalListSource;
            this.rentalStatusComboBox.SelectedIndex = 0;
            this.getData();
        }

        private void getData()
        {
            try
            {
                this.capstoneDatabaseContext.ItemRentals.Load();
                this.rentalListSource.DataSource = this.capstoneDatabaseContext.ItemRentals.Local.ToBindingList();

                this.refreshTable();
            }
            catch (MySqlException)
            {
                MessageBox.Show(@"There was a problem connecting to the database, is the VPN enabled?");
            }
        }

        private void filterByWaitingShipment()
        {
            try
            {
                this.capstoneDatabaseContext.ItemRentals.Load();

                var rentalWaitingForShipment =
                    this.capstoneDatabaseContext.ItemRentals.Where(rental => rental.status.Equals("WaitingShipment"));
                this.rentalListSource.DataSource = rentalWaitingForShipment.ToList();

                this.refreshTable();
            }
            catch (MySqlException)
            {
                MessageBox.Show(@"There was a problem connecting to the database, is the VPN enabled?");
            }
        }

        private void filterByWaitingReturn()
        {
            try
            {
                this.capstoneDatabaseContext.ItemRentals.Load();

                var rentalWaitingForShipment =
                    this.capstoneDatabaseContext.ItemRentals.Where(rental => rental.status.Equals("WaitingReturn"));
                this.rentalListSource.DataSource = rentalWaitingForShipment.ToList();

                this.refreshTable();
            }
            catch (MySqlException)
            {
                MessageBox.Show(@"There was a problem connecting to the database, is the VPN enabled?");
            }
        }

        private void refreshTable()
        {
            for (var i = 0; i < this.rentalGridView.Columns.Count; i++)
            {
                this.rentalGridView.Columns[i].MinimumWidth = 200;
            }

            this.rentalGridView.Columns[4].Visible = false;
            this.rentalGridView.Columns[5].Visible = false;
            this.rentalGridView.Columns[6].Visible = false;
            this.rentalGridView.Columns[7].Visible = false;
            this.rentalGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
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

        private void manageItemsButton_Click(object sender, EventArgs e)
        {
            var manageItemsForm = new ManageItemsForm(this.CurrentEmployee);
            Hide();
            manageItemsForm.ShowDialog();
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
            if (this.rentalStatusComboBox.SelectedIndex == 0)
            {
                this.getData();
            }
            else if (this.rentalStatusComboBox.SelectedIndex == 1)
            {
                this.filterByWaitingShipment();
            }
            else if (this.rentalStatusComboBox.SelectedIndex == 2)
            {
                this.filterByWaitingReturn();
            }
        }

        #endregion
    }
}