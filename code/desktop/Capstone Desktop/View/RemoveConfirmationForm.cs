using Capstone_Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Desktop.View
{
    public partial class RemoveConfirmationForm : Form
    {
        public RemoveConfirmationForm(Employee employee)
        {
            InitializeComponent();
            if (employee == null)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            this.employeeNameLabel.Text = employee.name;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
