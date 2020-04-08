using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;

namespace Capstone_Desktop.View
{
    /// <summary>The add stock from handles view logic handling adding new stock items.</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AddStockForm : Form
    {
        private List<string> itemConditions = new List<string> {
            "Excellent",
            "Good",
            "Fair",
            "Unusable"
        };

        private AddStockFormController addStockFormController;

        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="AddStockForm"/> class.
        /// </para>
        ///   <para>Handles view matters about adding stock.</para>
        /// </summary>
        /// <Precondition> None </Precondition>
        public AddStockForm()
        {
            InitializeComponent();
            this.addStockFormController = new AddStockFormController();
            this.populateComboBoxes();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            var selectedProduct = (Product) this.productIdComboBox.SelectedItem;
            var productId = selectedProduct.productId;
            var itemCondition = (string) this.itemConditionComboBox.SelectedItem;
            this.addStockFormController.AddStockToDatabase(productId, itemCondition);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void populateComboBoxes()
        {
            this.populateItemConditionComboBox();
            this.populateProductIdComboBox();
        }

        private void populateProductIdComboBox()
        {
            this.productIdComboBox.DataSource = this.addStockFormController.GetAllProducts();
            this.productIdComboBox.DisplayMember = "name";

        }

        private void populateItemConditionComboBox()
        {
            this.itemConditionComboBox.DataSource = this.itemConditions;
        }
    }
}
