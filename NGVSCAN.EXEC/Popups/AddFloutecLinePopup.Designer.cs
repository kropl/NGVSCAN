namespace NGVSCAN.EXEC.Popups
{
    partial class AddFloutecLinePopup
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
            this.labelNumberError = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSensorTypeError = new System.Windows.Forms.Label();
            this.comboSensorTypes = new System.Windows.Forms.ComboBox();
            this.labelDescriptionError = new System.Windows.Forms.Label();
            this.labelNameError = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.numericNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.buttonAddFloutec = new System.Windows.Forms.Button();
            this.buttonCancelAddFloutec = new System.Windows.Forms.Button();
            this.groupAddFloutec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // groupAddFloutec
            // 
            this.groupAddFloutec.Controls.Add(this.labelNumberError);
            this.groupAddFloutec.Controls.Add(this.label5);
            this.groupAddFloutec.Controls.Add(this.labelSensorTypeError);
            this.groupAddFloutec.Controls.Add(this.comboSensorTypes);
            this.groupAddFloutec.Controls.Add(this.labelDescriptionError);
            this.groupAddFloutec.Controls.Add(this.labelNameError);
            this.groupAddFloutec.Controls.Add(this.textDescription);
            this.groupAddFloutec.Controls.Add(this.numericNumber);
            this.groupAddFloutec.Controls.Add(this.label3);
            this.groupAddFloutec.Controls.Add(this.label2);
            this.groupAddFloutec.Controls.Add(this.label1);
            this.groupAddFloutec.Controls.Add(this.textName);
            this.groupAddFloutec.Location = new System.Drawing.Point(12, 12);
            this.groupAddFloutec.Name = "groupAddFloutec";
            this.groupAddFloutec.Size = new System.Drawing.Size(260, 226);
            this.groupAddFloutec.TabIndex = 0;
            this.groupAddFloutec.TabStop = false;
            this.groupAddFloutec.Text = "Свойства";
            // 
            // labelNumberError
            // 
            this.labelNumberError.AutoSize = true;
            this.labelNumberError.ForeColor = System.Drawing.Color.Red;
            this.labelNumberError.Location = new System.Drawing.Point(77, 16);
            this.labelNumberError.Name = "labelNumberError";
            this.labelNumberError.Size = new System.Drawing.Size(29, 13);
            this.labelNumberError.TabIndex = 12;
            this.labelNumberError.Text = "Error";
            this.labelNumberError.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Тип датчика";
            // 
            // labelSensorTypeError
            // 
            this.labelSensorTypeError.AutoSize = true;
            this.labelSensorTypeError.ForeColor = System.Drawing.Color.Red;
            this.labelSensorTypeError.Location = new System.Drawing.Point(77, 59);
            this.labelSensorTypeError.Name = "labelSensorTypeError";
            this.labelSensorTypeError.Size = new System.Drawing.Size(29, 13);
            this.labelSensorTypeError.TabIndex = 10;
            this.labelSensorTypeError.Text = "Error";
            this.labelSensorTypeError.Visible = false;
            // 
            // comboSensorTypes
            // 
            this.comboSensorTypes.FormattingEnabled = true;
            this.comboSensorTypes.Location = new System.Drawing.Point(77, 75);
            this.comboSensorTypes.Name = "comboSensorTypes";
            this.comboSensorTypes.Size = new System.Drawing.Size(176, 21);
            this.comboSensorTypes.TabIndex = 9;
            // 
            // labelDescriptionError
            // 
            this.labelDescriptionError.AutoSize = true;
            this.labelDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.labelDescriptionError.Location = new System.Drawing.Point(77, 147);
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
            this.labelNameError.Location = new System.Drawing.Point(77, 104);
            this.labelNameError.Name = "labelNameError";
            this.labelNameError.Size = new System.Drawing.Size(29, 13);
            this.labelNameError.TabIndex = 7;
            this.labelNameError.Text = "Error";
            this.labelNameError.Visible = false;
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(77, 163);
            this.textDescription.MaxLength = 200;
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(176, 54);
            this.textDescription.TabIndex = 5;
            // 
            // numericNumber
            // 
            this.numericNumber.Location = new System.Drawing.Point(77, 32);
            this.numericNumber.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNumber.Name = "numericNumber";
            this.numericNumber.Size = new System.Drawing.Size(113, 20);
            this.numericNumber.TabIndex = 4;
            this.numericNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Описание";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 123);
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
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(77, 120);
            this.textName.MaxLength = 25;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(176, 20);
            this.textName.TabIndex = 0;
            // 
            // buttonAddFloutec
            // 
            this.buttonAddFloutec.Location = new System.Drawing.Point(116, 256);
            this.buttonAddFloutec.Name = "buttonAddFloutec";
            this.buttonAddFloutec.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFloutec.TabIndex = 1;
            this.buttonAddFloutec.Text = "Сохранить";
            this.buttonAddFloutec.UseVisualStyleBackColor = true;
            this.buttonAddFloutec.Click += new System.EventHandler(this.buttonAddFloutec_Click);
            // 
            // buttonCancelAddFloutec
            // 
            this.buttonCancelAddFloutec.Location = new System.Drawing.Point(197, 256);
            this.buttonCancelAddFloutec.Name = "buttonCancelAddFloutec";
            this.buttonCancelAddFloutec.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelAddFloutec.TabIndex = 2;
            this.buttonCancelAddFloutec.Text = "Отмена";
            this.buttonCancelAddFloutec.UseVisualStyleBackColor = true;
            this.buttonCancelAddFloutec.Click += new System.EventHandler(this.buttonCancelAddFloutec_Click);
            // 
            // AddFloutecLinePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 291);
            this.Controls.Add(this.buttonCancelAddFloutec);
            this.Controls.Add(this.buttonAddFloutec);
            this.Controls.Add(this.groupAddFloutec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 330);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 330);
            this.Name = "AddFloutecLinePopup";
            this.Text = "form";
            this.Load += new System.EventHandler(this.AddFloutecLinePopup_Load);
            this.groupAddFloutec.ResumeLayout(false);
            this.groupAddFloutec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAddFloutec;
        private System.Windows.Forms.Button buttonAddFloutec;
        private System.Windows.Forms.Button buttonCancelAddFloutec;
        private System.Windows.Forms.NumericUpDown numericNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelDescriptionError;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label labelNameError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSensorTypeError;
        private System.Windows.Forms.ComboBox comboSensorTypes;
        private System.Windows.Forms.Label labelNumberError;
    }
}