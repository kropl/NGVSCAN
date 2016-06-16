namespace NGVSCAN.EXEC.Popups
{
    partial class AddROC809PointPopup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDescriptionError = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericSegment = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNameError = new System.Windows.Forms.Label();
            this.labelNumberError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericNumber = new System.Windows.Forms.NumericUpDown();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.numericMinuteScanPeriod = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericPeriodicScanPeriod = new System.Windows.Forms.NumericUpDown();
            this.numericDailyScanPeriod = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinuteScanPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPeriodicScanPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDailyScanPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericDailyScanPeriod);
            this.groupBox1.Controls.Add(this.numericPeriodicScanPeriod);
            this.groupBox1.Controls.Add(this.numericMinuteScanPeriod);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelDescriptionError);
            this.groupBox1.Controls.Add(this.textDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericSegment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelNameError);
            this.groupBox1.Controls.Add(this.labelNumberError);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericNumber);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 345);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства";
            // 
            // labelDescriptionError
            // 
            this.labelDescriptionError.AutoSize = true;
            this.labelDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.labelDescriptionError.Location = new System.Drawing.Point(147, 268);
            this.labelDescriptionError.Name = "labelDescriptionError";
            this.labelDescriptionError.Size = new System.Drawing.Size(29, 13);
            this.labelDescriptionError.TabIndex = 19;
            this.labelDescriptionError.Text = "Error";
            this.labelDescriptionError.Visible = false;
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(150, 284);
            this.textDescription.MaxLength = 200;
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(143, 54);
            this.textDescription.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Описание";
            // 
            // numericSegment
            // 
            this.numericSegment.Location = new System.Drawing.Point(150, 118);
            this.numericSegment.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSegment.Name = "numericSegment";
            this.numericSegment.Size = new System.Drawing.Size(143, 20);
            this.numericSegment.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Исторический сегмент";
            // 
            // labelNameError
            // 
            this.labelNameError.AutoSize = true;
            this.labelNameError.ForeColor = System.Drawing.Color.Red;
            this.labelNameError.Location = new System.Drawing.Point(147, 59);
            this.labelNameError.Name = "labelNameError";
            this.labelNameError.Size = new System.Drawing.Size(29, 13);
            this.labelNameError.TabIndex = 10;
            this.labelNameError.Text = "Error";
            this.labelNameError.Visible = false;
            // 
            // labelNumberError
            // 
            this.labelNumberError.AutoSize = true;
            this.labelNumberError.ForeColor = System.Drawing.Color.Red;
            this.labelNumberError.Location = new System.Drawing.Point(147, 16);
            this.labelNumberError.Name = "labelNumberError";
            this.labelNumberError.Size = new System.Drawing.Size(29, 13);
            this.labelNumberError.TabIndex = 14;
            this.labelNumberError.Text = "Error";
            this.labelNumberError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Название";
            // 
            // numericNumber
            // 
            this.numericNumber.Location = new System.Drawing.Point(150, 32);
            this.numericNumber.Maximum = new decimal(new int[] {
            200,
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
            this.numericNumber.TabIndex = 13;
            this.numericNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(150, 75);
            this.textName.MaxLength = 25;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(143, 20);
            this.textName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(237, 366);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(156, 366);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // numericMinuteScanPeriod
            // 
            this.numericMinuteScanPeriod.Location = new System.Drawing.Point(150, 159);
            this.numericMinuteScanPeriod.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericMinuteScanPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMinuteScanPeriod.Name = "numericMinuteScanPeriod";
            this.numericMinuteScanPeriod.Size = new System.Drawing.Size(143, 20);
            this.numericMinuteScanPeriod.TabIndex = 21;
            this.numericMinuteScanPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Период опроса ";
            // 
            // numericPeriodicScanPeriod
            // 
            this.numericPeriodicScanPeriod.Location = new System.Drawing.Point(149, 200);
            this.numericPeriodicScanPeriod.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericPeriodicScanPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPeriodicScanPeriod.Name = "numericPeriodicScanPeriod";
            this.numericPeriodicScanPeriod.Size = new System.Drawing.Size(143, 20);
            this.numericPeriodicScanPeriod.TabIndex = 23;
            this.numericPeriodicScanPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericDailyScanPeriod
            // 
            this.numericDailyScanPeriod.Location = new System.Drawing.Point(149, 241);
            this.numericDailyScanPeriod.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericDailyScanPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDailyScanPeriod.Name = "numericDailyScanPeriod";
            this.numericDailyScanPeriod.Size = new System.Drawing.Size(143, 20);
            this.numericDailyScanPeriod.TabIndex = 25;
            this.numericDailyScanPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "минутных данных, мин.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "период.  данных, мин.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Период опроса ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "суточных  данных, мин.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Период опроса ";
            // 
            // AddROC809PointPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 401);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(340, 440);
            this.MinimumSize = new System.Drawing.Size(340, 440);
            this.Name = "AddROC809PointPopup";
            this.Text = "form";
            this.Load += new System.EventHandler(this.AddROC809PointPopup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinuteScanPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPeriodicScanPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDailyScanPeriod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNumberError;
        private System.Windows.Forms.NumericUpDown numericNumber;
        private System.Windows.Forms.Label labelNameError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.NumericUpDown numericSegment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDescriptionError;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericDailyScanPeriod;
        private System.Windows.Forms.NumericUpDown numericPeriodicScanPeriod;
        private System.Windows.Forms.NumericUpDown numericMinuteScanPeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}