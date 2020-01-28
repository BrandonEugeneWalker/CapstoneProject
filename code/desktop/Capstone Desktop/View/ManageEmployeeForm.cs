using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Capstone_Desktop.Database;
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

        #endregion

        #region Properties

        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        public ManageEmployeeForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.CurrentEmployee = loggedInEmployee;
        }

        #endregion

        #region Methods

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var table = (DataTable) this.employeeListSource.DataSource;

            foreach (DataGridViewRow currentRow in this.employeeGridView.SelectedRows)
            {
                table.Rows.RemoveAt(currentRow.Index);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();
            this.getData();
        }

        private void SubmitChangesButton_Click(object sender, EventArgs e)
        {
            this.tableDataAdapter.Update((DataTable) this.employeeListSource.DataSource); //TODO
        }

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
        {
            this.employeeGridView.DataSource = this.employeeBindingSource;
            this.getData();
        }

        private void getData()
        {
            try
            {
                var query = "select * from Employee";
                this.tableDataAdapter = new MySqlDataAdapter(query, CapstoneSqlConnection.SqlConnection);
                this.tableCommandBuilder = new MySqlCommandBuilder(this.tableDataAdapter);
                var table = new DataTable {
                    Locale = CultureInfo.InvariantCulture
                };
                this.tableDataAdapter.Fill(table);
                this.employeeBindingSource.DataSource = table;

                this.refreshTable();
            }
            catch (MySqlException)
            {
                MessageBox.Show(@"There was a problem connecting to the database, is the VPN enabled?");
            }
        }

        private void refreshTable()
        {
            this.employeeGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        #endregion
    }
}