namespace Capstone_Desktop.View
{
    partial class AddStockForm
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
            this.productIdLabel = new System.Windows.Forms.Label();
            this.itemConditionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.productIdComboBox = new System.Windows.Forms.ComboBox();
            this.itemConditionComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.addStockLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productIdLabel
            // 
            this.productIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productIdLabel.Location = new System.Drawing.Point(148, 163);
            this.productIdLabel.Name = "productIdLabel";
            this.productIdLabel.Size = new System.Drawing.Size(189, 37);
            this.productIdLabel.TabIndex = 1;
            this.productIdLabel.Text = "Product ID:";
            this.productIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // itemConditionLabel
            // 
            this.itemConditionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemConditionLabel.Location = new System.Drawing.Point(148, 217);
            this.itemConditionLabel.Name = "itemConditionLabel";
            this.itemConditionLabel.Size = new System.Drawing.Size(189, 37);
            this.itemConditionLabel.TabIndex = 2;
            this.itemConditionLabel.Text = "Item Condition:";
            this.itemConditionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(760, 45);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "West Georgia Entertainment Library";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productIdComboBox
            // 
            this.productIdComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productIdComboBox.FormattingEnabled = true;
            this.productIdComboBox.Location = new System.Drawing.Point(396, 167);
            this.productIdComboBox.Name = "productIdComboBox";
            this.productIdComboBox.Size = new System.Drawing.Size(179, 33);
            this.productIdComboBox.TabIndex = 4;
            // 
            // itemConditionComboBox
            // 
            this.itemConditionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemConditionComboBox.FormattingEnabled = true;
            this.itemConditionComboBox.Location = new System.Drawing.Point(396, 217);
            this.itemConditionComboBox.Name = "itemConditionComboBox";
            this.itemConditionComboBox.Size = new System.Drawing.Size(179, 33);
            this.itemConditionComboBox.TabIndex = 5;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(322, 309);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(115, 34);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(460, 309);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(115, 34);
            this.submitButton.TabIndex = 7;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // addStockLabel
            // 
            this.addStockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.addStockLabel.Location = new System.Drawing.Point(12, 54);
            this.addStockLabel.Name = "addStockLabel";
            this.addStockLabel.Size = new System.Drawing.Size(760, 45);
            this.addStockLabel.TabIndex = 8;
            this.addStockLabel.Text = "Adding Stock";
            this.addStockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.addStockLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.itemConditionComboBox);
            this.Controls.Add(this.productIdComboBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.itemConditionLabel);
            this.Controls.Add(this.productIdLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AddStockForm";
            this.Text = "Adding Stock";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label productIdLabel;
        private System.Windows.Forms.Label itemConditionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox productIdComboBox;
        private System.Windows.Forms.ComboBox itemConditionComboBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label addStockLabel;
    }
}