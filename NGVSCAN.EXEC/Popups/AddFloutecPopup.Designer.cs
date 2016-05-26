namespace NGVSCAN.EXEC.Popups
{
    partial class AddFloutecPopup
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
            this.groupAddFloutec = new System.Windows.Forms.GroupBox();
            this.labelAddressError = new System.Windows.Forms.Label();
            this.labelDescriptionError = new System.Windows.Forms.Label();
            this.labelNameError = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.numericAddress = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.buttonAddFloutec = new System.Windows.Forms.Button();
            this.buttonCancelAddFloutec = new System.Windows.Forms.Button();
            this.groupAddFloutec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // groupAddFloutec
            // 
            this.groupAddFloutec.Controls.Add(this.labelAddressError);
            this.groupAddFloutec.Controls.Add(this.labelDescriptionError);
            this.groupAddFloutec.Controls.Add(this.labelNameError);
            this.groupAddFloutec.Controls.Add(this.textDescription);
            this.groupAddFloutec.Controls.Add(this.numericAddress);
            this.groupAddFloutec.Controls.Add(this.label3);
            this.groupAddFloutec.Controls.Add(this.label2);
            this.groupAddFloutec.Controls.Add(this.label1);
            this.groupAddFloutec.Controls.Add(this.textName);
            this.groupAddFloutec.Location = new System.Drawing.Point(12, 12);
            this.groupAddFloutec.Name = "groupAddFloutec";
            this.groupAddFloutec.Size = new System.Drawing.Size(260, 180);
            this.groupAddFloutec.TabIndex = 0;
            this.groupAddFloutec.TabStop = false;
            this.groupAddFloutec.Text = "Свойства";
            // 
            // labelAddressError
            // 
            this.labelAddressError.AutoSize = true;
            this.labelAddressError.ForeColor = System.Drawing.Color.Red;
            this.labelAddressError.Location = new System.Drawing.Point(77, 16);
            this.labelAddressError.Name = "labelAddressError";
            this.labelAddressError.Size = new System.Drawing.Size(29, 13);
            this.labelAddressError.TabIndex = 9;
            this.labelAddressError.Text = "Error";
            this.labelAddressError.Visible = false;
            // 
            // labelDescriptionError
            // 
            this.labelDescriptionError.AutoSize = true;
            this.labelDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.labelDescriptionError.Location = new System.Drawing.Point(77, 102);
            this.labelDescriptionError.Name = "labelDescriptionError";
            this.labelDescriptionError.Size = new System.Drawing.Size(29, 13);
            this.labelDescriptionError.TabIndex = 8;
            this.labelDescriptionError.Text = "Error";
            this.labelDescriptionError.Visible = false;
            // 
            // labelNameError
            // 
            this.labelNameError.AutoSize = true;
            this.labelNameError.ForeColor = System.Drawing.Color.Red;
            this.labelNameError.Location = new System.Drawing.Point(77, 59);
            this.labelNameError.Name = "labelNameError";
            this.labelNameError.Size = new System.Drawing.Size(29, 13);
            this.labelNameError.TabIndex = 7;
            this.labelNameError.Text = "Error";
            this.labelNameError.Visible = false;
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(77, 118);
            this.textDescription.MaxLength = 200;
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(176, 54);
            this.textDescription.TabIndex = 5;
            // 
            // numericAddress
            // 
            this.numericAddress.Location = new System.Drawing.Point(77, 32);
            this.numericAddress.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericAddress.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAddress.Name = "numericAddress";
            this.numericAddress.Size = new System.Drawing.Size(113, 20);
            this.numericAddress.TabIndex = 4;
            this.numericAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Описание";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Адрес";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(77, 75);
            this.textName.MaxLength = 25;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(176, 20);
            this.textName.TabIndex = 0;
            // 
            // buttonAddFloutec
            // 
            this.buttonAddFloutec.Location = new System.Drawing.Point(116, 206);
            this.buttonAddFloutec.Name = "buttonAddFloutec";
            this.buttonAddFloutec.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFloutec.TabIndex = 1;
            this.buttonAddFloutec.Text = "Сохранить";
            this.buttonAddFloutec.UseVisualStyleBackColor = true;
            this.buttonAddFloutec.Click += new System.EventHandler(this.buttonAddFloutec_Click);
            // 
            // buttonCancelAddFloutec
            // 
            this.buttonCancelAddFloutec.Location = new System.Drawing.Point(197, 206);
            this.buttonCancelAddFloutec.Name = "buttonCancelAddFloutec";
            this.buttonCancelAddFloutec.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelAddFloutec.TabIndex = 2;
            this.buttonCancelAddFloutec.Text = "Отмена";
            this.buttonCancelAddFloutec.UseVisualStyleBackColor = true;
            this.buttonCancelAddFloutec.Click += new System.EventHandler(this.buttonCancelAddFloutec_Click);
            // 
            // AddFloutecPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 241);
            this.Controls.Add(this.buttonCancelAddFloutec);
            this.Controls.Add(this.buttonAddFloutec);
            this.Controls.Add(this.groupAddFloutec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 280);
            this.Name = "AddFloutecPopup";
            this.Text = "form";
            this.Load += new System.EventHandler(this.AddFloutecPopup_Load);
            this.groupAddFloutec.ResumeLayout(false);
            this.groupAddFloutec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAddress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAddFloutec;
        private System.Windows.Forms.Button buttonAddFloutec;
        private System.Windows.Forms.Button buttonCancelAddFloutec;
        private System.Windows.Forms.NumericUpDown numericAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelDescriptionError;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label labelNameError;
        private System.Windows.Forms.Label labelAddressError;
    }
}