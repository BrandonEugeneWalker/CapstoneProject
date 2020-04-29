using System;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;

namespace Capstone_Desktop.View
{
    /// <summary>The add product from handles view logic handling adding new product items.</summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AddProductForm : Form
    {
        #region Data members

        private readonly AddProductController addProductController;

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="AddProductForm" /> class.
        ///     </para>
        ///     <para>Handles view matters about adding product.</para>
        /// </summary>
        /// <Precondition> None </Precondition>
        public AddProductForm()
        {
            this.InitializeComponent();
            this.addProductController = new AddProductController();
            this.submitButton.Enabled = false;
        }

        #endregion

        #region Methods

        private void submitButton_Click(object sender, EventArgs e)
        {
            var productName = this.nameTextBox.Text;
            var productDescription = this.descriptionTextBox.Text;
            var productType = this.typeTextBox.Text;
            var productCategory = this.categoryTextBox.Text;
            var productToAdd = new Product {
                name = productName,
                description = productDescription,
                type = productType,
                category = productCategory
            };
            this.addProductController.AddProduct(productToAdd);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void onTextBoxUpdate(object sender, EventArgs e)
        {
            var isNameNotEmpty = !string.IsNullOrEmpty(this.nameTextBox.Text);
            var isDescriptionNotEmpty = !string.IsNullOrEmpty(this.descriptionTextBox.Text);
            var isTypeNotEmpty = !string.IsNullOrEmpty(this.typeTextBox.Text);
            var isCategoryNotEmpty = !string.IsNullOrEmpty(this.categoryTextBox.Text);

            if (isNameNotEmpty && isDescriptionNotEmpty && isTypeNotEmpty && isCategoryNotEmpty)
            {
                this.submitButton.Enabled = true;
            }
            else
            {
                this.submitButton.Enabled = false;
            }
        }

        #endregion
    }
}