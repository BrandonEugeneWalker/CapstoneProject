using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.View
{
    public partial class ManageEmployeeForm : Form
    {
        public Employee CurrentEmployee { get; set; }

        public ManageEmployeeForm(Employee loggedInEmployee)
        {
            InitializeComponent();
            this.CurrentEmployee = loggedInEmployee;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Capstone_DatabaseDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this._Capstone_DatabaseDataSet.Employee);

        }
    }
}
