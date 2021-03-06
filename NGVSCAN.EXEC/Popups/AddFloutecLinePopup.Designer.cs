﻿namespace NGVSCAN.EXEC.Popups
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
            this.numericInstantPeriod = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericHourlyPeriod = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericInstantPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHourlyPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // groupAddFloutec
            // 
            this.groupAddFloutec.Controls.Add(this.numericInstantPeriod);
            this.groupAddFloutec.Controls.Add(this.label8);
            this.groupAddFloutec.Controls.Add(this.label6);
            this.groupAddFloutec.Controls.Add(this.label7);
            this.groupAddFloutec.Controls.Add(this.numericHourlyPeriod);
            this.groupAddFloutec.Controls.Add(this.label4);
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
            this.groupAddFloutec.Size = new System.Drawing.Size(300, 318);
            this.groupAddFloutec.TabIndex = 0;
            this.groupAddFloutec.TabStop = false;
            this.groupAddFloutec.Text = "Свойства";
            // 
            // numericInstantPeriod
            // 
            this.numericInstantPeriod.Location = new System.Drawing.Point(151, 208);
            this.numericInstantPeriod.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericInstantPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericInstantPeriod.Name = "numericInstantPeriod";
            this.numericInstantPeriod.Size = new System.Drawing.Size(143, 20);
            this.numericInstantPeriod.TabIndex = 4;
            this.numericInstantPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "мгновенных данных, мин.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Период опроса";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "часовых данных, мин.";
            // 
            // numericHourlyPeriod
            // 
            this.numericHourlyPeriod.Location = new System.Drawing.Point(151, 162);
            this.numericHourlyPeriod.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericHourlyPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHourlyPeriod.Name = "numericHourlyPeriod";
            this.numericHourlyPeriod.Size = new System.Drawing.Size(143, 20);
            this.numericHourlyPeriod.TabIndex = 3;
            this.numericHourlyPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Период опроса";
            // 
            // labelNumberError
            // 
            this.labelNumberError.AutoSize = true;
            this.labelNumberError.ForeColor = System.Drawing.Color.Red;
            this.labelNumberError.Location = new System.Drawing.Point(148, 16);
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
            this.labelSensorTypeError.Location = new System.Drawing.Point(148, 59);
            this.labelSensorTypeError.Name = "labelSensorTypeError";
            this.labelSensorTypeError.Size = new System.Drawing.Size(29, 13);
            this.labelSensorTypeError.TabIndex = 10;
            this.labelSensorTypeError.Text = "Error";
            this.labelSensorTypeError.Visible = false;
            // 
            // comboSensorTypes
            // 
            this.comboSensorTypes.FormattingEnabled = true;
            this.comboSensorTypes.Location = new System.Drawing.Point(151, 75);
            this.comboSensorTypes.Name = "comboSensorTypes";
            this.comboSensorTypes.Size = new System.Drawing.Size(143, 21);
            this.comboSensorTypes.TabIndex = 1;
            // 
            // labelDescriptionError
            // 
            this.labelDescriptionError.AutoSize = true;
            this.labelDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.labelDescriptionError.Location = new System.Drawing.Point(148, 240);
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
            this.labelNameError.Location = new System.Drawing.Point(148, 104);
            this.labelNameError.Name = "labelNameError";
            this.labelNameError.Size = new System.Drawing.Size(29, 13);
            this.labelNameError.TabIndex = 7;
            this.labelNameError.Text = "Error";
            this.labelNameError.Visible = false;
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(151, 256);
            this.textDescription.MaxLength = 200;
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(143, 54);
            this.textDescription.TabIndex = 5;
            // 
            // numericNumber
            // 
            this.numericNumber.Location = new System.Drawing.Point(151, 32);
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
            this.numericNumber.Size = new System.Drawing.Size(143, 20);
            this.numericNumber.TabIndex = 0;
            this.numericNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 256);
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
            this.textName.Location = new System.Drawing.Point(151, 120);
            this.textName.MaxLength = 25;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(143, 20);
            this.textName.TabIndex = 2;
            // 
            // buttonAddFloutec
            // 
            this.buttonAddFloutec.Location = new System.Drawing.Point(156, 336);
            this.buttonAddFloutec.Name = "buttonAddFloutec";
            this.buttonAddFloutec.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFloutec.TabIndex = 6;
            this.buttonAddFloutec.Text = "Сохранить";
            this.buttonAddFloutec.UseVisualStyleBackColor = true;
            this.buttonAddFloutec.Click += new System.EventHandler(this.buttonAddFloutec_Click);
            // 
            // buttonCancelAddFloutec
            // 
            this.buttonCancelAddFloutec.Location = new System.Drawing.Point(237, 336);
            this.buttonCancelAddFloutec.Name = "buttonCancelAddFloutec";
            this.buttonCancelAddFloutec.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelAddFloutec.TabIndex = 7;
            this.buttonCancelAddFloutec.Text = "Отмена";
            this.buttonCancelAddFloutec.UseVisualStyleBackColor = true;
            this.buttonCancelAddFloutec.Click += new System.EventHandler(this.buttonCancelAddFloutec_Click);
            // 
            // AddFloutecLinePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 371);
            this.Controls.Add(this.buttonCancelAddFloutec);
            this.Controls.Add(this.buttonAddFloutec);
            this.Controls.Add(this.groupAddFloutec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 410);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 410);
            this.Name = "AddFloutecLinePopup";
            this.Text = "Добавление нитки для вычислителя ФЛОУТЭК";
            this.Load += new System.EventHandler(this.AddFloutecLinePopup_Load);
            this.groupAddFloutec.ResumeLayout(false);
            this.groupAddFloutec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInstantPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHourlyPeriod)).EndInit();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericHourlyPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericInstantPeriod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}