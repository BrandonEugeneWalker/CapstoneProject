namespace Capstone_Desktop.View
{
    partial class ItemHistoryForm
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
            this.companyLabel = new System.Windows.Forms.Label();
            this.stockLabel = new System.Windows.Forms.Label();
            this.historyGridView = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.historyGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // companyLabel
            // 
            this.companyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyLabel.Location = new System.Drawing.Point(-7, -9);
            this.companyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(1280, 85);
            this.companyLabel.TabIndex = 2;
            this.companyLabel.Text = "Item History";
            this.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stockLabel
            // 
            this.stockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockLabel.Location = new System.Drawing.Point(-7, 76);
            this.stockLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockLabel.Name = "stockLabel";
            this.stockLabel.Size = new System.Drawing.Size(1280, 40);
            this.stockLabel.TabIndex = 3;
            this.stockLabel.Text = "History for:";
            this.stockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // historyGridView
            // 
            this.historyGridView.AllowUserToAddRows = false;
            this.historyGridView.AllowUserToDeleteRows = false;
            this.historyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyGridView.Location = new System.Drawing.Point(12, 119);
            this.historyGridView.MultiSelect = false;
            this.historyGridView.Name = "historyGridView";
            this.historyGridView.ReadOnly = true;
            this.historyGridView.Size = new System.Drawing.Size(1240, 496);
            this.historyGridView.TabIndex = 4;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(1111, 623);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(141, 46);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ItemHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.historyGridView);
            this.Controls.Add(this.stockLabel);
            this.Controls.Add(this.companyLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemHistoryForm";
            this.Text = "Item History";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.historyGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label stockLabel;
        private System.Windows.Forms.DataGridView historyGridView;
        private System.Windows.Forms.Button backButton;
    }
}