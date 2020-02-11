using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Capstone_Desktop.Database;
using Capstone_Desktop.Database.employee;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    public partial class ManageEmployeeForm : Form
    {
        #region Data members

        private readonly BindingSource employeeListSource = new BindingSource();

        private MySqlDataAdapter tableDataAdapter = new MySqlDataAdapter();

        private MySqlCommandBuilder tableCommandBuilder = new MySqlCommandBuilder();

        private readonly DataTable dataTable;

        #endregion

        #region Properties

        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        public ManageEmployeeForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.CurrentEmployee = loggedInEmployee;
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

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var removedCount = 0;
            foreach (DataGridViewRow currentRow in this.employeeGridView.SelectedRows)
            {
                var rowIndex = currentRow.Index;
                var id = int.Parse(this.dataTable.Rows[rowIndex][0].ToString());
                try
                {
                    var results = DeleteEmployeeSqlCommands.DeleteEmployeeById(id);
                    removedCount += results;
                    this.dataTable.Rows.RemoveAt(rowIndex);
                }
                catch (MySqlException)
                {
                    MessageBox.Show(@"Trouble removing Employee of id: " + id);
                }
            }

            MessageBox.Show(@"Successfully removed " + removedCount + @"employee(s) from the database.");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addEmployeeForm = new AddEmployeeForm();
            Hide();
            addEmployeeForm.ShowDialog();
            Show();
            this.getData();
        }

        private void SubmitChangesButton_Click(object sender, EventArgs e)
        {
            this.tableDataAdapter.Update(this.dataTable); //TODO
        }

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
        {
            this.employeeGridView.DataSource = this.employeeListSource;
            this.getData();
        }

        private void getData()
        {
            try
            {
                var query = "select * from Employee";
                this.dataTable.Clear();
                this.tableDataAdapter = new MySqlDataAdapter(query, CapstoneSqlConnection.SqlConnection);
                this.tableCommandBuilder = new MySqlCommandBuilder(this.tableDataAdapter);
                this.tableDataAdapter.Fill(this.dataTable);
                this.employeeListSource.DataSource = this.dataTable;

                this.refreshTable();
            }
            catch (MySqlException)
            {
                MessageBox.Show(@"There was a problem connecting to the database, is the VPN enabled?");
            }
        }

        private void getDbContextData()
        {
            
        }

        private void refreshTable()
        {
            this.employeeGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void manageItemsButton_Click(object sender, EventArgs e)
        {
            var manageItemsForm = new ManageItemsForm(this.CurrentEmployee);
            Hide();
            manageItemsForm.ShowDialog();
            Show();
        }

        #endregion
    }
}