namespace NGVSCAN.EXEC.Controls
{
    partial class ROC809sGroupDetails
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelRocs = new System.Windows.Forms.Label();
            this.listRocs = new System.Windows.Forms.ListView();
            this.columnAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelRocs, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listRocs, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 223);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelRocs
            // 
            this.labelRocs.AutoSize = true;
            this.labelRocs.Location = new System.Drawing.Point(3, 0);
            this.labelRocs.Name = "labelRocs";
            this.labelRocs.Size = new System.Drawing.Size(77, 13);
            this.labelRocs.TabIndex = 1;
            this.labelRocs.Text = "Вычислители:";
            // 
            // listRocs
            // 
            this.listRocs.BackColor = System.Drawing.SystemColors.Control;
            this.listRocs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listRocs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAddress,
            this.ColumnName,
            this.ColumnDescription});
            this.listRocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRocs.Location = new System.Drawing.Point(3, 23);
            this.listRocs.Name = "listRocs";
            this.listRocs.Size = new System.Drawing.Size(358, 197);
            this.listRocs.TabIndex = 2;
            this.listRocs.UseCompatibleStateImageBehavior = false;
            this.listRocs.View = System.Windows.Forms.View.Details;
            // 
            // columnAddress
            // 
            this.columnAddress.Text = "Адрес";
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Название";
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.Text = "Описание";
            // 
            // ROC809sGroupDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ROC809sGroupDetails";
            this.Size = new System.Drawing.Size(364, 223);
            this.Load += new System.EventHandler(this.ROC809sGroupDetails_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelRocs;
        private System.Windows.Forms.ListView listRocs;
        private System.Windows.Forms.ColumnHeader columnAddress;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnDescription;
    }
}
