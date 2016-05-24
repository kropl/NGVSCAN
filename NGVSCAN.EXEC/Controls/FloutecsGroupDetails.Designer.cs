namespace NGVSCAN.EXEC.Controls
{
    partial class FloutecsGroupDetails
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
            this.labelFloutecs = new System.Windows.Forms.Label();
            this.listFloutecs = new System.Windows.Forms.ListView();
            this.columnAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // labelFloutecs
            // 
            this.labelFloutecs.AutoSize = true;
            this.labelFloutecs.Location = new System.Drawing.Point(4, 4);
            this.labelFloutecs.Name = "labelFloutecs";
            this.labelFloutecs.Size = new System.Drawing.Size(77, 13);
            this.labelFloutecs.TabIndex = 0;
            this.labelFloutecs.Text = "Вычислители:";
            // 
            // listFloutecs
            // 
            this.listFloutecs.BackColor = System.Drawing.SystemColors.Control;
            this.listFloutecs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listFloutecs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAddress,
            this.columnName,
            this.columnDescription});
            this.listFloutecs.Enabled = false;
            this.listFloutecs.Location = new System.Drawing.Point(7, 20);
            this.listFloutecs.MultiSelect = false;
            this.listFloutecs.Name = "listFloutecs";
            this.listFloutecs.Scrollable = false;
            this.listFloutecs.Size = new System.Drawing.Size(337, 195);
            this.listFloutecs.TabIndex = 1;
            this.listFloutecs.UseCompatibleStateImageBehavior = false;
            this.listFloutecs.View = System.Windows.Forms.View.Details;
            // 
            // columnAddress
            // 
            this.columnAddress.Text = "Адрес";
            // 
            // columnName
            // 
            this.columnName.Text = "Название";
            this.columnName.Width = 150;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Описание";
            this.columnDescription.Width = 300;
            // 
            // FloutecsGroupDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.listFloutecs);
            this.Controls.Add(this.labelFloutecs);
            this.Name = "FloutecsGroupDetails";
            this.Size = new System.Drawing.Size(350, 218);
            this.Load += new System.EventHandler(this.FloutecsGroupDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFloutecs;
        private System.Windows.Forms.ListView listFloutecs;
        private System.Windows.Forms.ColumnHeader columnAddress;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnDescription;
    }
}
