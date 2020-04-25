using System;
using System.ComponentModel;
using System.Windows.Forms;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///     <para>This form is responsible for showing the user the history of an item.</para>
    ///     <para>This form can be opened by the ManageItemsForm.</para>
    ///     <para>This form closes down to the ManageItemsForm.</para>
    ///     <para>This form is opened as a dialog, with the parent form remaining visible.</para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ItemHistoryForm : Form
    {
        #region Data members

        private readonly ItemHistoryController itemHistoryController;

        #endregion

        #region Properties

        private Stock CurrentStock { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="ItemHistoryForm" /> class.
        ///     </para>
        ///     <para>If the stock is null a message box is shown and the form is closed back down to the parent form.</para>
        /// </summary>
        /// <param name="stock">The stock to show the history of.</param>
        /// <Precondition> Stock cannot be null! </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public ItemHistoryForm(Stock stock)
        {
            if (stock == null)
            {
                MessageBox.Show(@"There was no item to show the history of given!");
                Close();
            }

            this.InitializeComponent();
            this.CurrentStock = stock;
            this.itemHistoryController = new ItemHistoryController();
            this.setStockDescription();
            this.getData();
        }

        #endregion

        #region Methods

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void getData()
        {
            this.historyGridView.DataSource =
                this.itemHistoryController.GetStockHistory(this.CurrentStock);
        }

        private void setStockDescription()
        {
            this.stockLabel.Text =
                this.stockLabel.Text + this.itemHistoryController.BuildStockDescription(this.CurrentStock);
        }

        #endregion
    }
}