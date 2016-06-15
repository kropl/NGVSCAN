namespace NGVSCAN.EXEC.Popups
{
    partial class AddROC809Popup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNameError = new System.Windows.Forms.Label();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericROCUnit = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.labelDescriptionError = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericROCGroup = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericHOSTGroup = new System.Windows.Forms.NumericUpDown();
            this.numericHOSTUnit = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.numericIP1 = new System.Windows.Forms.NumericUpDown();
            this.numericIP2 = new System.Windows.Forms.NumericUpDown();
            this.numericIP3 = new System.Windows.Forms.NumericUpDown();
            this.numericIP4 = new System.Windows.Forms.NumericUpDown();
            this.labelIPError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericROCUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericROCGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHOSTGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHOSTUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIP4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelIPError);
            this.groupBox1.Controls.Add(this.numericIP4);
            this.groupBox1.Controls.Add(this.numericIP3);
            this.groupBox1.Controls.Add(this.numericIP2);
            this.groupBox1.Controls.Add(this.numericIP1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numericHOSTGroup);
            this.groupBox1.Controls.Add(this.numericHOSTUnit);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericROCGroup);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.labelDescriptionError);
            this.groupBox1.Controls.Add(this.textDescription);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.numericROCUnit);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericPort);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelNameError);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP-адрес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Название";
            // 
            // labelNameError
            // 
            this.labelNameError.AutoSize = true;
            this.labelNameError.ForeColor = System.Drawing.Color.Red;
            this.labelNameError.Location = new System.Drawing.Point(80, 58);
            this.labelNameError.Name = "labelNameError";
            this.labelNameError.Size = new System.Drawing.Size(29, 13);
            this.labelNameError.TabIndex = 4;
            this.labelNameError.Text = "Error";
            this.labelNameError.Visible = false;
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(83, 117);
            this.numericPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(170, 20);
            this.numericPort.TabIndex = 5;
            this.numericPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Порт";
            // 
            // numericROCUnit
            // 
            this.numericROCUnit.Location = new System.Drawing.Point(83, 161);
            this.numericROCUnit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericROCUnit.Name = "numericROCUnit";
            this.numericROCUnit.Size = new System.Drawing.Size(82, 20);
            this.numericROCUnit.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Unit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "ROC-адрес";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "HOST-адрес";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(197, 336);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(113, 336);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(83, 74);
            this.textName.MaxLength = 25;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(170, 20);
            this.textName.TabIndex = 4;
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(83, 247);
            this.textDescription.MaxLength = 200;
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(170, 54);
            this.textDescription.TabIndex = 10;
            // 
            // labelDescriptionError
            // 
            this.labelDescriptionError.AutoSize = true;
            this.labelDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.labelDescriptionError.Location = new System.Drawing.Point(80, 231);
            this.labelDescriptionError.Name = "labelDescriptionError";
            this.labelDescriptionError.Size = new System.Drawing.Size(29, 13);
            this.labelDescriptionError.TabIndex = 20;
            this.labelDescriptionError.Text = "Error";
            this.labelDescriptionError.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 252);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Описание";
            // 
            // numericROCGroup
            // 
            this.numericROCGroup.Location = new System.Drawing.Point(171, 161);
            this.numericROCGroup.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericROCGroup.Name = "numericROCGroup";
            this.numericROCGroup.Size = new System.Drawing.Size(82, 20);
            this.numericROCGroup.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Group";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Group";
            // 
            // numericHOSTGroup
            // 
            this.numericHOSTGroup.Location = new System.Drawing.Point(171, 204);
            this.numericHOSTGroup.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericHOSTGroup.Name = "numericHOSTGroup";
            this.numericHOSTGroup.Size = new System.Drawing.Size(82, 20);
            this.numericHOSTGroup.TabIndex = 9;
            // 
            // numericHOSTUnit
            // 
            this.numericHOSTUnit.Location = new System.Drawing.Point(83, 204);
            this.numericHOSTUnit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericHOSTUnit.Name = "numericHOSTUnit";
            this.numericHOSTUnit.Size = new System.Drawing.Size(82, 20);
            this.numericHOSTUnit.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(80, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(119, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = ".";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(163, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(12, 18);
            this.label15.TabIndex = 32;
            this.label15.Text = ".";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(207, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 18);
            this.label16.TabIndex = 33;
            this.label16.Text = ".";
            // 
            // numericIP1
            // 
            this.numericIP1.Location = new System.Drawing.Point(83, 32);
            this.numericIP1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericIP1.Name = "numericIP1";
            this.numericIP1.Size = new System.Drawing.Size(38, 20);
            this.numericIP1.TabIndex = 0;
            // 
            // numericIP2
            // 
            this.numericIP2.Location = new System.Drawing.Point(127, 32);
            this.numericIP2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericIP2.Name = "numericIP2";
            this.numericIP2.Size = new System.Drawing.Size(38, 20);
            this.numericIP2.TabIndex = 1;
            // 
            // numericIP3
            // 
            this.numericIP3.Location = new System.Drawing.Point(171, 32);
            this.numericIP3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericIP3.Name = "numericIP3";
            this.numericIP3.Size = new System.Drawing.Size(38, 20);
            this.numericIP3.TabIndex = 2;
            // 
            // numericIP4
            // 
            this.numericIP4.Location = new System.Drawing.Point(215, 32);
            this.numericIP4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericIP4.Name = "numericIP4";
            this.numericIP4.Size = new System.Drawing.Size(38, 20);
            this.numericIP4.TabIndex = 3;
            // 
            // labelIPError
            // 
            this.labelIPError.AutoSize = true;
            this.labelIPError.ForeColor = System.Drawing.Color.Red;
            this.labelIPError.Location = new System.Drawing.Point(80, 16);
            this.labelIPError.Name = "labelIPError";
            this.labelIPError.Size = new System.Drawing.Size(29, 13);
            this.labelIPError.TabIndex = 38;
            this.labelIPError.Text = "Error";
            this.labelIPError.Visible = false;
            // 
            // AddROC809Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 371);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 410);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 410);
            this.Name = "AddROC809Popup";
            this.Text = "form";
            this.Load += new System.EventHandler(this.AddROC809Popup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericROCUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericROCGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHOSTGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHOSTUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIP4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNameError;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericROCUnit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelDescriptionError;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericHOSTGroup;
        private System.Windows.Forms.NumericUpDown numericHOSTUnit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericROCGroup;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericIP4;
        private System.Windows.Forms.NumericUpDown numericIP3;
        private System.Windows.Forms.NumericUpDown numericIP2;
        private System.Windows.Forms.NumericUpDown numericIP1;
        private System.Windows.Forms.Label labelIPError;
    }
}