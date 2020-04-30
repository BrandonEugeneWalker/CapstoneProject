using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///     <para>This form is used to view and manage the status of the rentals.</para>
    ///     <para>The ManageRentalsForm is opened by the ManageItemsForm and the ManageEmployeeForm.</para>
    ///     <para>The ManageRentalsForm can return to the forms that opened it, or to the LoginForm.</para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ManageRentalsForm : Form
    {
        #region Data members

        private List<string> itemConditions = new List<string> {
            "Excellent",
            "Good",
            "Fair",
            "Unusable"
        };

        private readonly BindingSource rentalListSource = new BindingSource();

        private readonly ManageRentalsController manageRentalsController;

        #endregion

        #region Properties

        /// <summary>Gets or sets the current employee.</summary>
        /// <value>The current employee.</value>
        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="ManageRentalsForm" /> class.</para>
        ///     <para>The ManageRentalsForm handles user interactions relating to viewing and managing rentals and their status.</para>
        /// </summary>
        /// <param name="loggedInEmployee">The logged in employee.</param>
        public ManageRentalsForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.manageRentalsController = new ManageRentalsController();
            this.CurrentEmployee = loggedInEmployee;
            this.populateComboBox();
            if (this.CurrentEmployee.isManager == true)
            {
                this.managerButton.Enabled = true;
            }
        }

        #endregion

        #region Methods

        private void populateComboBox()
        {
            this.itemConditionComboBox.DataSource = this.itemConditions;
            this.itemConditionComboBox.SelectedIndex = 1;
        }

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
                this.rentalListSource.DataSource =
                    this.manageRentalsController.GetAllRentals();

                //this.refreshTable();
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
                this.rentalListSource.DataSource =
                    this.manageRentalsController.GetRentalsWaitingShipment();

                //this.refreshTable();
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
                this.rentalListSource.DataSource =
                    this.manageRentalsController.GetRentalsWaitingReturn();

                //this.refreshTable();
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
                var currentItem = (DetailedRentalView) currentRow.DataBoundItem;
                string itemCondition = (string)this.itemConditionComboBox.SelectedItem;

                var results = this.manageRentalsController.MarkRentalAsWaitingReturn(currentItem, this.CurrentEmployee, itemCondition);

                if (!results)
                {
                    MessageBox.Show(@"That rental cannot be changed to that state.");
                }

                this.getData();
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow currentRow in this.rentalGridView.SelectedRows)
            {
                var currentItem = (DetailedRentalView) currentRow.DataBoundItem;
                string itemCondition = (string) this.itemConditionComboBox.SelectedItem;

                var results = this.manageRentalsController.MarkRentalAsReturned(currentItem, this.CurrentEmployee, itemCondition);

                if (!results)
                {
                    MessageBox.Show(@"That rental cannot be changed to that state.");
                }

                this.getData();
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