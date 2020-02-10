using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Capstone_Desktop.Database;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    public partial class ManageItemsForm : Form
    {
        #region Data members

        private BindingSource itemListSource = new BindingSource();

        private MySqlDataAdapter tableDataAdapter = new MySqlDataAdapter();

        private MySqlCommandBuilder tableCommandBuilder = new MySqlCommandBuilder();

        private DataTable dataTable;

        #endregion

        #region Properties

        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        public ManageItemsForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.CurrentEmployee = loggedInEmployee;
            if (this.CurrentEmployee.IsManager)
            {
                this.managerButton.Enabled = true;
            }
            this.dataTable = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
        }

        #endregion

        #region Methods

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addEmployeeForm = new AddEmployeeForm();
            this.Hide();
            addEmployeeForm.ShowDialog();
            this.Show();
            this.getData();
        }

        private void SubmitChangesButton_Click(object sender, EventArgs e)
        {

            this.tableDataAdapter.Update(this.dataTable); //TODO
        }

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
        {
            this.itemsGridView.DataSource = this.itemsBindingSource;
            this.getData();
        }

        private void getData()
        {
            try
            {
                var query = "select * from Product";
                this.dataTable.Clear();
                this.tableDataAdapter = new MySqlDataAdapter(query, CapstoneSqlConnection.SqlConnection);
                this.tableCommandBuilder = new MySqlCommandBuilder(this.tableDataAdapter);
                this.tableDataAdapter.Fill(this.dataTable);
                this.itemsBindingSource.DataSource = this.dataTable;

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

        #endregion

        private void markReturnedButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void markShippedButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void managerButton_Click(object sender, EventArgs e)
        {
            if (this.CurrentEmployee.IsManager)
            {
                this.Hide();
                ManageEmployeeForm manageEmployeeForm = new ManageEmployeeForm(this.CurrentEmployee);
                manageEmployeeForm.ShowDialog();
                this.Show();
            }
        }
    }
}