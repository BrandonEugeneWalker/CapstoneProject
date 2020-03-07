﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone_Database.Model;

namespace Capstone_Desktop.View
{
    /// <summary>
    ///   <para>This form is responsible for showing the user the history of an item.</para>
    ///   <para>This form can be opened by the ManageItemsForm.</para>
    ///   <para>This form closes down to the ManageItemsForm.</para>
    ///   <para>This form is opened as a dialog, with the parent form remaining visible.</para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ItemHistoryForm : Form
    {

        private OnlineEntities capstoneDbContext;

        private Stock CurrentStock { get; set; }

        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="ItemHistoryForm"/> class.
        /// </para>
        ///   <para>If the stock is null a message box is shown and the form is closed back down to the parent form.</para>
        /// </summary>
        /// <param name="stock">The stock to show the history of.</param>
        public ItemHistoryForm(Stock stock)
        {
            if (stock == null)
            {
                MessageBox.Show(@"There was no item to show the history of given!");
                Close();
            }
            InitializeComponent();
            this.CurrentStock = stock;
            this.capstoneDbContext = new OnlineEntities();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
