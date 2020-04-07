using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///   <para>This form is used for viewing the action history of an Employee.</para>
    ///   <para>The ManageEmployeeForm can open this form.</para>
    ///   <para>Closes to the ManageEmployeeForm.</para>
    ///   <para>Is opened as a dialog, with the parent form remaining visible.</para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class EmployeeHistoryForm : Form
    {

        private OnlineEntities capstoneDbContext;

        private EmployeeHistoryController employeeHistoryController;

        private Employee CurrentEmployee { get; set; }

        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="EmployeeHistoryForm"/> class.
        /// </para>
        ///   <para>If the given employee is null a message box shows an error and the form closes down to the parent form.</para>
        /// </summary>
        /// <param name="employee">The employee to show the history for.</param>
        public EmployeeHistoryForm(Employee employee)
        {
            if (employee == null)
            {
                MessageBox.Show(@"No employee was provided to view the history of!");
                Close();
            }
            InitializeComponent();
            this.CurrentEmployee = employee;
            this.capstoneDbContext = new OnlineEntities();
            this.employeeHistoryController = new EmployeeHistoryController();
            this.setEmployeeLabel();
            this.populateHistoryView();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void populateHistoryView()
        {
            var employeeHistory =
                this.employeeHistoryController.GetEmployeeHistory(this.CurrentEmployee);

            this.historyGridView.DataSource = employeeHistory;

            this.refreshTable();
        }

        private void refreshTable()
        {
            this.historyGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void setEmployeeLabel()
        {
            string employeeDescription = this.employeeHistoryController.BuildEmployeeDescription(this.CurrentEmployee);
            string baseString = this.employeeLabel.Text;
            string updatedLabelValue = baseString + employeeDescription;
            this.employeeLabel.Text = updatedLabelValue;
        }
    }
}
