namespace NGVSCAN.EXEC
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("1 Газ на собственные нужды");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("2 Газ на сепаратор С-1");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("185 Расход газа", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("1 Конденсат. Налив в авто");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("2 Пластовая вода. Нали в авто");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("186 Расход жидкостей", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("SEM-SRV", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode13});
            this.groupEstimatorsLog = new System.Windows.Forms.GroupBox();
            this.groupEstimatorsProperties = new System.Windows.Forms.GroupBox();
            this.groupEstimators = new System.Windows.Forms.GroupBox();
            this.treeEstimators = new System.Windows.Forms.TreeView();
            this.contextMenuEstimators = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddEstimator = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddMeasureLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupEstimators.SuspendLayout();
            this.contextMenuEstimators.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupEstimatorsLog
            // 
            this.groupEstimatorsLog.Location = new System.Drawing.Point(12, 403);
            this.groupEstimatorsLog.Name = "groupEstimatorsLog";
            this.groupEstimatorsLog.Size = new System.Drawing.Size(860, 133);
            this.groupEstimatorsLog.TabIndex = 2;
            this.groupEstimatorsLog.TabStop = false;
            this.groupEstimatorsLog.Text = "Сообщения";
            // 
            // groupEstimatorsProperties
            // 
            this.groupEstimatorsProperties.Location = new System.Drawing.Point(318, 27);
            this.groupEstimatorsProperties.Name = "groupEstimatorsProperties";
            this.groupEstimatorsProperties.Size = new System.Drawing.Size(554, 370);
            this.groupEstimatorsProperties.TabIndex = 1;
            this.groupEstimatorsProperties.TabStop = false;
            this.groupEstimatorsProperties.Text = "Свойства";
            // 
            // groupEstimators
            // 
            this.groupEstimators.Controls.Add(this.treeEstimators);
            this.groupEstimators.Location = new System.Drawing.Point(12, 27);
            this.groupEstimators.Name = "groupEstimators";
            this.groupEstimators.Size = new System.Drawing.Size(300, 370);
            this.groupEstimators.TabIndex = 0;
            this.groupEstimators.TabStop = false;
            this.groupEstimators.Text = "Вычислители";
            // 
            // treeEstimators
            // 
            this.treeEstimators.BackColor = System.Drawing.SystemColors.Control;
            this.treeEstimators.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeEstimators.ContextMenuStrip = this.contextMenuEstimators;
            this.treeEstimators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeEstimators.Location = new System.Drawing.Point(3, 16);
            this.treeEstimators.Name = "treeEstimators";
            treeNode8.Name = "Node3";
            treeNode8.Text = "1 Газ на собственные нужды";
            treeNode9.Name = "Node4";
            treeNode9.Text = "2 Газ на сепаратор С-1";
            treeNode10.Name = "Node1";
            treeNode10.Text = "185 Расход газа";
            treeNode11.Name = "Node5";
            treeNode11.Text = "1 Конденсат. Налив в авто";
            treeNode12.Name = "Node6";
            treeNode12.Text = "2 Пластовая вода. Нали в авто";
            treeNode13.Name = "Node2";
            treeNode13.Text = "186 Расход жидкостей";
            treeNode14.Name = "Node0";
            treeNode14.Text = "SEM-SRV";
            this.treeEstimators.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.treeEstimators.Size = new System.Drawing.Size(294, 351);
            this.treeEstimators.TabIndex = 0;
            this.treeEstimators.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFloutecs_AfterSelect);
            // 
            // contextMenuEstimators
            // 
            this.contextMenuEstimators.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddEstimator,
            this.menuAddMeasureLine,
            this.toolStripSeparator1,
            this.menuEdit,
            this.toolStripSeparator2,
            this.menuDelete});
            this.contextMenuEstimators.Name = "contextMenuFloutecs";
            this.contextMenuEstimators.Size = new System.Drawing.Size(203, 104);
            this.contextMenuEstimators.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuFloutecs_Opening);
            this.contextMenuEstimators.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuFloutecs_ItemClicked);
            // 
            // menuAddEstimator
            // 
            this.menuAddEstimator.Name = "menuAddEstimator";
            this.menuAddEstimator.Size = new System.Drawing.Size(202, 22);
            this.menuAddEstimator.Text = "Добавить вычислитель";
            // 
            // menuAddMeasureLine
            // 
            this.menuAddMeasureLine.Name = "menuAddMeasureLine";
            this.menuAddMeasureLine.Size = new System.Drawing.Size(202, 22);
            this.menuAddMeasureLine.Text = "Добавить нитку";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(202, 22);
            this.menuEdit.Text = "Изменить";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(202, 22);
            this.menuDelete.Text = "Удалить";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 539);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(884, 22);
            this.status.SizingGrip = false;
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings,
            this.menuAbout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(884, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(79, 20);
            this.menuSettings.Text = "Настройки";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(94, 20);
            this.menuAbout.Text = "О программе";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.groupEstimatorsLog);
            this.Controls.Add(this.groupEstimatorsProperties);
            this.Controls.Add(this.status);
            this.Controls.Add(this.groupEstimators);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "Программа опроса вычислителей ЧАО \"Нефтегаздобыча\"";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupEstimators.ResumeLayout(false);
            this.contextMenuEstimators.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.GroupBox groupEstimatorsProperties;
        private System.Windows.Forms.GroupBox groupEstimators;
        private System.Windows.Forms.TreeView treeEstimators;
        private System.Windows.Forms.ContextMenuStrip contextMenuEstimators;
        private System.Windows.Forms.ToolStripMenuItem menuAddEstimator;
        private System.Windows.Forms.ToolStripMenuItem menuAddMeasureLine;
        private System.Windows.Forms.GroupBox groupEstimatorsLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

