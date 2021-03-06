﻿namespace Capstone_Desktop.View
{
    partial class ManageItemsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logoutButton = new System.Windows.Forms.Button();
            this.companyLabel = new System.Windows.Forms.Label();
            this.manageItemsLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.viewHistoryButton = new System.Windows.Forms.Button();
            this.managerButton = new System.Windows.Forms.Button();
            this.itemsGridView = new System.Windows.Forms.DataGridView();
            this.manageRentalsButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.manageProductButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(1105, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(141, 46);
            this.logoutButton.TabIndex = 0;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // companyLabel
            // 
            this.companyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyLabel.Location = new System.Drawing.Point(1, 9);
            this.companyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(1257, 85);
            this.companyLabel.TabIndex = 1;
            this.companyLabel.Text = "West Georgia Entertainment Library";
            this.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // manageItemsLabel
            // 
            this.manageItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageItemsLabel.Location = new System.Drawing.Point(2, 76);
            this.manageItemsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.manageItemsLabel.Name = "manageItemsLabel";
            this.manageItemsLabel.Size = new System.Drawing.Size(1256, 85);
            this.manageItemsLabel.TabIndex = 2;
            this.manageItemsLabel.Text = "View and Manage Stock";
            this.manageItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(1105, 578);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(141, 46);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add Item";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // viewHistoryButton
            // 
            this.viewHistoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewHistoryButton.Location = new System.Drawing.Point(12, 578);
            this.viewHistoryButton.Name = "viewHistoryButton";
            this.viewHistoryButton.Size = new System.Drawing.Size(141, 46);
            this.viewHistoryButton.TabIndex = 6;
            this.viewHistoryButton.Text = "View History";
            this.viewHistoryButton.UseVisualStyleBackColor = true;
            this.viewHistoryButton.Click += new System.EventHandler(this.viewHistoryButton_Click);
            // 
            // managerButton
            // 
            this.managerButton.Enabled = false;
            this.managerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerButton.Location = new System.Drawing.Point(958, 12);
            this.managerButton.Name = "managerButton";
            this.managerButton.Size = new System.Drawing.Size(141, 46);
            this.managerButton.TabIndex = 8;
            this.managerButton.Text = "Manager Portal";
            this.managerButton.UseVisualStyleBackColor = true;
            this.managerButton.Click += new System.EventHandler(this.managerButton_Click);
            // 
            // itemsGridView
            // 
            this.itemsGridView.AllowUserToAddRows = false;
            this.itemsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGridView.Location = new System.Drawing.Point(12, 164);
            this.itemsGridView.Name = "itemsGridView";
            this.itemsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemsGridView.Size = new System.Drawing.Size(1240, 384);
            this.itemsGridView.TabIndex = 9;
            // 
            // manageRentalsButton
            // 
            this.manageRentalsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageRentalsButton.Location = new System.Drawing.Point(1105, 64);
            this.manageRentalsButton.Name = "manageRentalsButton";
            this.manageRentalsButton.Size = new System.Drawing.Size(141, 46);
            this.manageRentalsButton.TabIndex = 10;
            this.manageRentalsButton.Text = "Manage Rentals";
            this.manageRentalsButton.UseVisualStyleBackColor = true;
            this.manageRentalsButton.Click += new System.EventHandler(this.manageRentalsButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(958, 578);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(141, 46);
            this.removeButton.TabIndex = 11;
            this.removeButton.Text = "Remove Item";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // manageProductButton
            // 
            this.manageProductButton.Enabled = false;
            this.manageProductButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageProductButton.Location = new System.Drawing.Point(958, 64);
            this.manageProductButton.Name = "manageProductButton";
            this.manageProductButton.Size = new System.Drawing.Size(141, 46);
            this.manageProductButton.TabIndex = 12;
            this.manageProductButton.Text = "Manage Product";
            this.manageProductButton.UseVisualStyleBackColor = true;
            this.manageProductButton.Click += new System.EventHandler(this.manageProductButton_Click);
            // 
            // ManageItemsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.manageProductButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.manageRentalsButton);
            this.Controls.Add(this.itemsGridView);
            this.Controls.Add(this.managerButton);
            this.Controls.Add(this.viewHistoryButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.manageItemsLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.companyLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "ManageItemsForm";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.ManageItemsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label manageItemsLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button viewHistoryButton;
        private System.Windows.Forms.Button managerButton;
        private System.Windows.Forms.DataGridView itemsGridView;
        private System.Windows.Forms.Button manageRentalsButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button manageProductButton;
    }
}