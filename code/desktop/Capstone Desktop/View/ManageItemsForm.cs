﻿using System;
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

        private readonly BindingSource itemListSource = new BindingSource();

        private MySqlDataAdapter tableDataAdapter = new MySqlDataAdapter();

        private MySqlCommandBuilder tableCommandBuilder = new MySqlCommandBuilder();

        private readonly DataTable dataTable;

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
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void SubmitChangesButton_Click(object sender, EventArgs e)
        {
            this.tableDataAdapter.Update(this.dataTable); //TODO
        }

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Capstone_DatabaseDataSet.Product' table. You can move, or remove it, as needed.
            this.itemsGridView.DataSource = this.itemListSource;
            this.getData();
        }

        private void getData()
        {
            try
            {
                var query =
                    "SELECT p.`productId`, p.`name`, p.`category`, p.`type`, COUNT(s.`productId`) AS \"In Stock\" " +
                    "FROM `Product` AS p, `Stock` AS s " +
                    "WHERE p.`productId` = s.`productId` " +
                    "GROUP BY p.`productId`";
                this.dataTable.Clear();
                this.tableDataAdapter = new MySqlDataAdapter(query, CapstoneSqlConnection.SqlConnection);
                this.tableCommandBuilder = new MySqlCommandBuilder(this.tableDataAdapter);
                this.tableDataAdapter.Fill(this.dataTable);
                this.itemListSource.DataSource = this.dataTable;

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
            if (this.CurrentEmployee.IsManager)
            {
                Hide();
                var manageEmployeeForm = new ManageEmployeeForm(this.CurrentEmployee);
                manageEmployeeForm.ShowDialog();
                Show();
            }
        }

        #endregion

        private void manageRentalsButton_Click(object sender, EventArgs e)
        {

        }
    }
}