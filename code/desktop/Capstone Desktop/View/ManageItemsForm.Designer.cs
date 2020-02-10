namespace Capstone_Desktop.View
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
            this.components = new System.ComponentModel.Container();
            this.logoutButton = new System.Windows.Forms.Button();
            this.companyLabel = new System.Windows.Forms.Label();
            this.manageItemsLabel = new System.Windows.Forms.Label();
            this.itemsGridView = new System.Windows.Forms.DataGridView();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Capstone_DatabaseDataSet = new Capstone_Desktop._Capstone_DatabaseDataSet();
            this.markReturnedButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.submitChangesButton = new System.Windows.Forms.Button();
            this.employeeTableAdapter = new Capstone_Desktop._Capstone_DatabaseDataSetTableAdapters.EmployeeTableAdapter();
            this.markShippedButton = new System.Windows.Forms.Button();
            this.managerButton = new System.Windows.Forms.Button();
            this.employeeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isManagerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Capstone_DatabaseDataSet)).BeginInit();
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
            this.manageItemsLabel.Text = "Manage Items";
            this.manageItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemsGridView
            // 
            this.itemsGridView.AllowUserToResizeRows = false;
            this.itemsGridView.AutoGenerateColumns = false;
            this.itemsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIdDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.isManagerDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.itemsGridView.DataSource = this.itemsBindingSource;
            this.itemsGridView.Location = new System.Drawing.Point(12, 164);
            this.itemsGridView.Name = "itemsGridView";
            this.itemsGridView.RowHeadersWidth = 62;
            this.itemsGridView.RowTemplate.Height = 28;
            this.itemsGridView.Size = new System.Drawing.Size(1234, 391);
            this.itemsGridView.TabIndex = 3;
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Employee";
            this.itemsBindingSource.DataSource = this._Capstone_DatabaseDataSet;
            // 
            // _Capstone_DatabaseDataSet
            // 
            this._Capstone_DatabaseDataSet.DataSetName = "_Capstone_DatabaseDataSet";
            this._Capstone_DatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // markReturnedButton
            // 
            this.markReturnedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.markReturnedButton.Location = new System.Drawing.Point(1105, 578);
            this.markReturnedButton.Name = "markReturnedButton";
            this.markReturnedButton.Size = new System.Drawing.Size(141, 46);
            this.markReturnedButton.TabIndex = 4;
            this.markReturnedButton.Text = "Mark Returned";
            this.markReturnedButton.UseVisualStyleBackColor = true;
            this.markReturnedButton.Click += new System.EventHandler(this.markReturnedButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(811, 578);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(141, 46);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add Item";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // submitChangesButton
            // 
            this.submitChangesButton.Enabled = false;
            this.submitChangesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitChangesButton.Location = new System.Drawing.Point(12, 578);
            this.submitChangesButton.Name = "submitChangesButton";
            this.submitChangesButton.Size = new System.Drawing.Size(141, 46);
            this.submitChangesButton.TabIndex = 6;
            this.submitChangesButton.Text = "Submit Changes";
            this.submitChangesButton.UseVisualStyleBackColor = true;
            this.submitChangesButton.Click += new System.EventHandler(this.SubmitChangesButton_Click);
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // markShippedButton
            // 
            this.markShippedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.markShippedButton.Location = new System.Drawing.Point(958, 578);
            this.markShippedButton.Name = "markShippedButton";
            this.markShippedButton.Size = new System.Drawing.Size(141, 46);
            this.markShippedButton.TabIndex = 7;
            this.markShippedButton.Text = "Mark Shipped";
            this.markShippedButton.UseVisualStyleBackColor = true;
            this.markShippedButton.Click += new System.EventHandler(this.markShippedButton_Click);
            // 
            // managerButton
            // 
            this.managerButton.Enabled = false;
            this.managerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerButton.Location = new System.Drawing.Point(1105, 64);
            this.managerButton.Name = "managerButton";
            this.managerButton.Size = new System.Drawing.Size(141, 46);
            this.managerButton.TabIndex = 8;
            this.managerButton.Text = "Manager Portal";
            this.managerButton.UseVisualStyleBackColor = true;
            this.managerButton.Click += new System.EventHandler(this.managerButton_Click);
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            this.employeeIdDataGridViewTextBoxColumn.DataPropertyName = "employeeId";
            this.employeeIdDataGridViewTextBoxColumn.HeaderText = "employeeId";
            this.employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            this.employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            // 
            // isManagerDataGridViewTextBoxColumn
            // 
            this.isManagerDataGridViewTextBoxColumn.DataPropertyName = "isManager";
            this.isManagerDataGridViewTextBoxColumn.HeaderText = "isManager";
            this.isManagerDataGridViewTextBoxColumn.Name = "isManagerDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // ManageItemsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.managerButton);
            this.Controls.Add(this.markShippedButton);
            this.Controls.Add(this.submitChangesButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.markReturnedButton);
            this.Controls.Add(this.itemsGridView);
            this.Controls.Add(this.manageItemsLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.companyLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "ManageItemsForm";
            this.Text = "Manage Employees";
            this.Load += new System.EventHandler(this.ManageEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Capstone_DatabaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label manageItemsLabel;
        private System.Windows.Forms.DataGridView itemsGridView;
        private System.Windows.Forms.Button markReturnedButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button submitChangesButton;
        private _Capstone_DatabaseDataSet _Capstone_DatabaseDataSet;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private _Capstone_DatabaseDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.Button markShippedButton;
        private System.Windows.Forms.Button managerButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isManagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}