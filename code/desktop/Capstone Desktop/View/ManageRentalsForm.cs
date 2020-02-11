using System;
using System.CodeDom;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Capstone_Desktop.Database;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    public partial class ManageRentalsForm : Form
    {
        #region Data members

        private readonly BindingSource rentalListSource = new BindingSource();

        private MySqlDataAdapter tableDataAdapter = new MySqlDataAdapter();

        private MySqlCommandBuilder tableCommandBuilder = new MySqlCommandBuilder();

        private readonly DataTable dataTable;

        private static string waitingShipmentQuery = "SELECT p.`productId`, p.`name`, p.`category`, p.`type`, s.`stockId` " +
                                                     "FROM `Product` AS p " +
                                                     "INNER JOIN `Stock` AS s ON p.`productId` = s.`productId` " +
                                                     "WHERE EXISTS (SELECT * FROM `ItemRental` AS r WHERE r.`stockId` = s.`stockId` AND `status` = \"WaitingShipment\")";

        private static string waitingReturnQuery = "SELECT p.`productId`, p.`name`, p.`category`, p.`type`, s.`stockId` " +
                                                   "FROM `Product` AS p " +
                                                   "INNER JOIN `Stock` AS s ON p.`productId` = s.`productId` " +
                                                   "WHERE EXISTS (SELECT * FROM `ItemRental` AS r WHERE r.`stockId` = s.`stockId` AND `status` = \"WaitingReturn\")";

        #endregion

        #region Properties

        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        public ManageRentalsForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.CurrentEmployee = loggedInEmployee;
            if (this.CurrentEmployee.IsManager)
            {
                this.managerButton.Enabled = true;
            }

            this.dataTable = new DataTable {
                Locale = CultureInfo.InvariantCulture
            };
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
            this.rentedButton.Enabled = true;
            this.returnButton.Enabled = false;
        }

        private void getData(string query)
        {
            try
            {
                this.dataTable.Clear();
                this.tableDataAdapter = new MySqlDataAdapter(query, CapstoneSqlConnection.SqlConnection);
                this.tableCommandBuilder = new MySqlCommandBuilder(this.tableDataAdapter);
                this.tableDataAdapter.Fill(this.dataTable);
                this.rentalListSource.DataSource = this.dataTable;

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
            if (this.CurrentEmployee.IsManager)
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
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private void rentalStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rentalStatusComboBox.SelectedIndex == 0)
            {
                this.getData(waitingReturnQuery);
                this.swapEnabledRentalButtons();
            }
            else
            {
                this.getData(waitingShipmentQuery);
                this.swapEnabledRentalButtons();
                
            }
        }

        private void swapEnabledRentalButtons()
        {
            this.returnButton.Enabled = !this.returnButton.Enabled;
            this.rentedButton.Enabled = !this.rentedButton.Enabled;
        }
    }
}