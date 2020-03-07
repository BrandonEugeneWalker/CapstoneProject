using System;
using System.Data.Entity;
using System.Windows.Forms;
using Capstone_Database.Model;
using MySql.Data.MySqlClient;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///   <para>This form is used to manage employees in the database.</para>
    ///   <para>The ManageEmployeeForm can be opened by the LoginForm, ManageItemsForm, and the ManageRentalsForm.</para>
    ///   <para>The ManageEmployeeForm can open the ManageItemsForm, ManageRentalsForm and the AddEmployeeForm</para>
    ///   <para>The ManageEmployeeForm closes to the LoginForm.</para>
    ///   <para>The ManageEmployeeForm allows a user to see current employees in the database and add/remove them.</para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form"/>
    public partial class ManageEmployeeForm : Form
    {
        #region Data members

        private readonly BindingSource employeeListSource = new BindingSource();

        private readonly OnlineEntities capstoneDatabaseContext;

        #endregion

        #region Properties

        /// <summary>Gets or sets the current employee.</summary>
        /// <value>The current employee.</value>
        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="ManageEmployeeForm"/> class.</para>
        ///   <para>The ManageEmployeeForm handles user interactions relating to viewing managing employees.</para>
        /// </summary>
        /// <param name="loggedInEmployee">The logged in employee.</param>
        public ManageEmployeeForm(Employee loggedInEmployee)
        {
            this.InitializeComponent();
            this.CurrentEmployee = loggedInEmployee;
            this.capstoneDatabaseContext = new OnlineEntities();
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
                try
                {
                    var currentEmployee = (Employee) currentRow.DataBoundItem;
                    removedCount += this.AttemptToRemoveEmployee(currentEmployee, rowIndex);
                }
                catch (MySqlException)
                {
                    MessageBox.Show(@"Trouble removing that employee.");
                }
            }

            MessageBox.Show(@"Successfully removed " + removedCount + @" employee(s) from the database.");
        }

        private int AttemptToRemoveEmployee(Employee employee, int rowIndex)
        {
            var confirmationForm = new RemoveConfirmationForm(employee);
            var dialogResult = confirmationForm.ShowDialog();

            var results = 0;

            switch (dialogResult)
            {
                case DialogResult.Yes:
                    this.employeeGridView.Rows.RemoveAt(rowIndex);
                    this.capstoneDatabaseContext.SaveChanges();
                    results = 1;
                    break;
                case DialogResult.Abort:
                    MessageBox.Show("No employee was selected.");
                    break;
            }

            return results;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();
            this.getData();
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
                this.capstoneDatabaseContext.Employees.Load();
                this.employeeListSource.DataSource = this.capstoneDatabaseContext.Employees.Local.ToBindingList();

                for (var i = 0; i < this.employeeGridView.Columns.Count; i++)
                {
                    this.employeeGridView.Columns[i].MinimumWidth = 200;
                }

                this.employeeGridView.Columns[4].Visible = false;

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

        private void manageItemsButton_Click(object sender, EventArgs e)
        {
            var manageItemsForm = new ManageItemsForm(this.CurrentEmployee);
            Hide();
            manageItemsForm.ShowDialog();
            Close();
        }

        #endregion

        private void viewHistoryButton_Click(object sender, EventArgs e)
        {
            Employee selectedEmployee = null;

            if (this.employeeGridView.SelectedRows.Count != 0)
            {
                selectedEmployee = (Employee)this.employeeGridView.SelectedRows[0].DataBoundItem;
            }

            if (selectedEmployee != null)
            {
                EmployeeHistoryForm employeeHistoryForm = new EmployeeHistoryForm(selectedEmployee);
                employeeHistoryForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"There was no selected employee to view the history of.");
            }
        }
    }
}