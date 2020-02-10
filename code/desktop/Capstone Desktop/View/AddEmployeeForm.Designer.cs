namespace Capstone_Desktop.View
{
    partial class AddEmployeeForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.isManagerLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.isManagerCheckBox = new System.Windows.Forms.CheckBox();
            this.idNummericUpDown = new System.Windows.Forms.NumericUpDown();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.isValidLabel = new System.Windows.Forms.Label();
            this.passwordReqHeaderLabel = new System.Windows.Forms.Label();
            this.passwordRequirementsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.idNummericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(760, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "West Georgia Entertainment Library";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(760, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adding An Employee";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idLabel
            // 
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.Location = new System.Drawing.Point(23, 217);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(185, 37);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "Employee Id:";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(19, 254);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(189, 37);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "Employee Password:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // isManagerLabel
            // 
            this.isManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isManagerLabel.Location = new System.Drawing.Point(11, 291);
            this.isManagerLabel.Name = "isManagerLabel";
            this.isManagerLabel.Size = new System.Drawing.Size(197, 37);
            this.isManagerLabel.TabIndex = 0;
            this.isManagerLabel.Text = "Employee Is Manager:";
            this.isManagerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(15, 328);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(193, 37);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Employee Name:";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(255, 259);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(185, 26);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(255, 333);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(185, 26);
            this.nameTextBox.TabIndex = 4;
            // 
            // isManagerCheckBox
            // 
            this.isManagerCheckBox.Location = new System.Drawing.Point(255, 291);
            this.isManagerCheckBox.Name = "isManagerCheckBox";
            this.isManagerCheckBox.Size = new System.Drawing.Size(185, 36);
            this.isManagerCheckBox.TabIndex = 3;
            this.isManagerCheckBox.Text = "Check if True";
            this.isManagerCheckBox.UseVisualStyleBackColor = true;
            // 
            // idNummericUpDown
            // 
            this.idNummericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idNummericUpDown.Location = new System.Drawing.Point(255, 223);
            this.idNummericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.idNummericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.idNummericUpDown.Name = "idNummericUpDown";
            this.idNummericUpDown.Size = new System.Drawing.Size(185, 26);
            this.idNummericUpDown.TabIndex = 1;
            this.idNummericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(325, 405);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(115, 34);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(186, 405);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(115, 34);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // isValidLabel
            // 
            this.isValidLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isValidLabel.Location = new System.Drawing.Point(446, 259);
            this.isValidLabel.Name = "isValidLabel";
            this.isValidLabel.Size = new System.Drawing.Size(105, 26);
            this.isValidLabel.TabIndex = 7;
            this.isValidLabel.Text = "Invalid";
            this.isValidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordReqHeaderLabel
            // 
            this.passwordReqHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordReqHeaderLabel.Location = new System.Drawing.Point(539, 259);
            this.passwordReqHeaderLabel.Name = "passwordReqHeaderLabel";
            this.passwordReqHeaderLabel.Size = new System.Drawing.Size(218, 26);
            this.passwordReqHeaderLabel.TabIndex = 8;
            this.passwordReqHeaderLabel.Text = "Password Requirements:";
            this.passwordReqHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordRequirementsLabel
            // 
            this.passwordRequirementsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordRequirementsLabel.Location = new System.Drawing.Point(543, 291);
            this.passwordRequirementsLabel.Name = "passwordRequirementsLabel";
            this.passwordRequirementsLabel.Size = new System.Drawing.Size(229, 261);
            this.passwordRequirementsLabel.TabIndex = 9;
            // 
            // AddEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.passwordRequirementsLabel);
            this.Controls.Add(this.passwordReqHeaderLabel);
            this.Controls.Add(this.isValidLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.idNummericUpDown);
            this.Controls.Add(this.isManagerCheckBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.isManagerLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AddEmployeeForm";
            this.Text = "Adding An Employee";
            ((System.ComponentModel.ISupportInitialize)(this.idNummericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label isManagerLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox isManagerCheckBox;
        private System.Windows.Forms.NumericUpDown idNummericUpDown;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label isValidLabel;
        private System.Windows.Forms.Label passwordReqHeaderLabel;
        private System.Windows.Forms.Label passwordRequirementsLabel;
    }
}