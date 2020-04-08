namespace Capstone_Desktop.View
{
    partial class ManageRentalsForm
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
            this.returnButton = new System.Windows.Forms.Button();
            this.managerButton = new System.Windows.Forms.Button();
            this.rentalGridView = new System.Windows.Forms.DataGridView();
            this.manageItemsButton = new System.Windows.Forms.Button();
            this.rentedButton = new System.Windows.Forms.Button();
            this.rentalStatusComboBox = new System.Windows.Forms.ComboBox();
            this.rentalStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rentalGridView)).BeginInit();
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
            this.manageItemsLabel.Text = "View and Manage Rentals";
            this.manageItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // returnButton
            // 
            this.returnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnButton.Location = new System.Drawing.Point(1063, 615);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(183, 46);
            this.returnButton.TabIndex = 5;
            this.returnButton.Text = "Mark Returned";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // managerButton
            // 
            this.managerButton.Enabled = false;
            this.managerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerButton.Location = new System.Drawing.Point(958, 64);
            this.managerButton.Name = "managerButton";
            this.managerButton.Size = new System.Drawing.Size(141, 46);
            this.managerButton.TabIndex = 8;
            this.managerButton.Text = "Manager Portal";
            this.managerButton.UseVisualStyleBackColor = true;
            this.managerButton.Click += new System.EventHandler(this.managerButton_Click);
            // 
            // rentalGridView
            // 
            this.rentalGridView.AllowUserToAddRows = false;
            this.rentalGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rentalGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentalGridView.Location = new System.Drawing.Point(12, 164);
            this.rentalGridView.Name = "rentalGridView";
            this.rentalGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rentalGridView.Size = new System.Drawing.Size(1240, 384);
            this.rentalGridView.TabIndex = 9;
            // 
            // manageItemsButton
            // 
            this.manageItemsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageItemsButton.Location = new System.Drawing.Point(1105, 64);
            this.manageItemsButton.Name = "manageItemsButton";
            this.manageItemsButton.Size = new System.Drawing.Size(141, 46);
            this.manageItemsButton.TabIndex = 10;
            this.manageItemsButton.Text = "Manage Items";
            this.manageItemsButton.UseVisualStyleBackColor = true;
            this.manageItemsButton.Click += new System.EventHandler(this.manageItemsButton_Click);
            // 
            // rentedButton
            // 
            this.rentedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rentedButton.Location = new System.Drawing.Point(1063, 563);
            this.rentedButton.Name = "rentedButton";
            this.rentedButton.Size = new System.Drawing.Size(183, 46);
            this.rentedButton.TabIndex = 11;
            this.rentedButton.Text = "Mark WaitingReturn";
            this.rentedButton.UseVisualStyleBackColor = true;
            this.rentedButton.Click += new System.EventHandler(this.rentedButton_Click);
            // 
            // rentalStatusComboBox
            // 
            this.rentalStatusComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rentalStatusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rentalStatusComboBox.FormattingEnabled = true;
            this.rentalStatusComboBox.Items.AddRange(new object[] {
            "All",
            "WaitingShipment",
            "WaitingReturn"});
            this.rentalStatusComboBox.Location = new System.Drawing.Point(125, 560);
            this.rentalStatusComboBox.Name = "rentalStatusComboBox";
            this.rentalStatusComboBox.Size = new System.Drawing.Size(141, 28);
            this.rentalStatusComboBox.TabIndex = 12;
            this.rentalStatusComboBox.SelectedIndexChanged += new System.EventHandler(this.rentalStatusComboBox_SelectedIndexChanged);
            // 
            // rentalStatusLabel
            // 
            this.rentalStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rentalStatusLabel.Location = new System.Drawing.Point(8, 563);
            this.rentalStatusLabel.Name = "rentalStatusLabel";
            this.rentalStatusLabel.Size = new System.Drawing.Size(111, 27);
            this.rentalStatusLabel.TabIndex = 13;
            this.rentalStatusLabel.Text = "Rental Status:";
            // 
            // ManageRentalsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.rentalStatusLabel);
            this.Controls.Add(this.rentalStatusComboBox);
            this.Controls.Add(this.rentedButton);
            this.Controls.Add(this.manageItemsButton);
            this.Controls.Add(this.rentalGridView);
            this.Controls.Add(this.managerButton);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.manageItemsLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.companyLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "ManageRentalsForm";
            this.Text = "Rentals";
            this.Load += new System.EventHandler(this.ManageRentalsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rentalGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label manageItemsLabel;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button managerButton;
        private System.Windows.Forms.DataGridView rentalGridView;
        private System.Windows.Forms.Button manageItemsButton;
        private System.Windows.Forms.Button rentedButton;
        private System.Windows.Forms.ComboBox rentalStatusComboBox;
        private System.Windows.Forms.Label rentalStatusLabel;
    }
}