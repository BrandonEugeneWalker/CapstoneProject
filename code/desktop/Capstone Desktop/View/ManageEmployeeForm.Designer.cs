namespace Capstone_Desktop.View
{
    partial class ManageEmployeeForm
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
            this.loginLabel = new System.Windows.Forms.Label();
            this.employeeGridView = new System.Windows.Forms.DataGridView();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.viewHistoryButton = new System.Windows.Forms.Button();
            this.manageItemsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeeGridView)).BeginInit();
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
            // loginLabel
            // 
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.Location = new System.Drawing.Point(2, 76);
            this.loginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(1256, 85);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Manage Employees";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // employeeGridView
            // 
            this.employeeGridView.AllowUserToAddRows = false;
            this.employeeGridView.AllowUserToResizeRows = false;
            this.employeeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeGridView.Location = new System.Drawing.Point(12, 164);
            this.employeeGridView.MultiSelect = false;
            this.employeeGridView.Name = "employeeGridView";
            this.employeeGridView.ReadOnly = true;
            this.employeeGridView.RowHeadersWidth = 62;
            this.employeeGridView.RowTemplate.Height = 28;
            this.employeeGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.employeeGridView.Size = new System.Drawing.Size(1234, 391);
            this.employeeGridView.TabIndex = 3;
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(1105, 578);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(141, 46);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(958, 578);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(141, 46);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
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
            // manageItemsButton
            // 
            this.manageItemsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageItemsButton.Location = new System.Drawing.Point(1105, 64);
            this.manageItemsButton.Name = "manageItemsButton";
            this.manageItemsButton.Size = new System.Drawing.Size(141, 46);
            this.manageItemsButton.TabIndex = 7;
            this.manageItemsButton.Text = "Manage Items";
            this.manageItemsButton.UseVisualStyleBackColor = true;
            this.manageItemsButton.Click += new System.EventHandler(this.manageItemsButton_Click);
            // 
            // ManageEmployeeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.manageItemsButton);
            this.Controls.Add(this.viewHistoryButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.employeeGridView);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.companyLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "ManageEmployeeForm";
            this.Text = "Manage Employees";
            this.Load += new System.EventHandler(this.ManageEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.DataGridView employeeGridView;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button viewHistoryButton;
        private System.Windows.Forms.Button manageItemsButton;
    }
}