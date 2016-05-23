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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1 Газ на собственные нужды");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2 Газ на сепаратор С-1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("185 Расход газа", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("1 Конденсат. Налив в авто");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("2 Пластовая вода. Нали в авто");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("186 Расход жидкостей", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("SEM-SRV", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.groupFloutecsLog = new System.Windows.Forms.GroupBox();
            this.groupFloutecsProperties = new System.Windows.Forms.GroupBox();
            this.groupFloutecs = new System.Windows.Forms.GroupBox();
            this.treeFloutecs = new System.Windows.Forms.TreeView();
            this.contextMenuFloutecs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddFloutec = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddFloutecLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEditFloutec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDeleteFloutec = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupFloutecs.SuspendLayout();
            this.contextMenuFloutecs.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFloutecsLog
            // 
            this.groupFloutecsLog.Location = new System.Drawing.Point(12, 403);
            this.groupFloutecsLog.Name = "groupFloutecsLog";
            this.groupFloutecsLog.Size = new System.Drawing.Size(860, 133);
            this.groupFloutecsLog.TabIndex = 2;
            this.groupFloutecsLog.TabStop = false;
            this.groupFloutecsLog.Text = "Сообщения";
            // 
            // groupFloutecsProperties
            // 
            this.groupFloutecsProperties.Location = new System.Drawing.Point(318, 27);
            this.groupFloutecsProperties.Name = "groupFloutecsProperties";
            this.groupFloutecsProperties.Size = new System.Drawing.Size(554, 370);
            this.groupFloutecsProperties.TabIndex = 1;
            this.groupFloutecsProperties.TabStop = false;
            this.groupFloutecsProperties.Text = "Свойства";
            // 
            // groupFloutecs
            // 
            this.groupFloutecs.Controls.Add(this.treeFloutecs);
            this.groupFloutecs.Location = new System.Drawing.Point(12, 27);
            this.groupFloutecs.Name = "groupFloutecs";
            this.groupFloutecs.Size = new System.Drawing.Size(300, 370);
            this.groupFloutecs.TabIndex = 0;
            this.groupFloutecs.TabStop = false;
            this.groupFloutecs.Text = "Вычислители";
            // 
            // treeFloutecs
            // 
            this.treeFloutecs.BackColor = System.Drawing.SystemColors.Control;
            this.treeFloutecs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeFloutecs.ContextMenuStrip = this.contextMenuFloutecs;
            this.treeFloutecs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFloutecs.Location = new System.Drawing.Point(3, 16);
            this.treeFloutecs.Name = "treeFloutecs";
            treeNode1.Name = "Node3";
            treeNode1.Text = "1 Газ на собственные нужды";
            treeNode2.Name = "Node4";
            treeNode2.Text = "2 Газ на сепаратор С-1";
            treeNode3.Name = "Node1";
            treeNode3.Text = "185 Расход газа";
            treeNode4.Name = "Node5";
            treeNode4.Text = "1 Конденсат. Налив в авто";
            treeNode5.Name = "Node6";
            treeNode5.Text = "2 Пластовая вода. Нали в авто";
            treeNode6.Name = "Node2";
            treeNode6.Text = "186 Расход жидкостей";
            treeNode7.Name = "Node0";
            treeNode7.Text = "SEM-SRV";
            this.treeFloutecs.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeFloutecs.Size = new System.Drawing.Size(294, 351);
            this.treeFloutecs.TabIndex = 0;
            this.treeFloutecs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFloutecs_AfterSelect);
            // 
            // contextMenuFloutecs
            // 
            this.contextMenuFloutecs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddFloutec,
            this.menuAddFloutecLine,
            this.toolStripSeparator1,
            this.menuEditFloutec,
            this.toolStripSeparator2,
            this.menuDeleteFloutec});
            this.contextMenuFloutecs.Name = "contextMenuFloutecs";
            this.contextMenuFloutecs.Size = new System.Drawing.Size(203, 104);
            this.contextMenuFloutecs.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuFloutecs_Opening);
            this.contextMenuFloutecs.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuFloutecs_ItemClicked);
            // 
            // menuAddFloutec
            // 
            this.menuAddFloutec.Name = "menuAddFloutec";
            this.menuAddFloutec.Size = new System.Drawing.Size(202, 22);
            this.menuAddFloutec.Text = "Добавить вычислитель";
            // 
            // menuAddFloutecLine
            // 
            this.menuAddFloutecLine.Name = "menuAddFloutecLine";
            this.menuAddFloutecLine.Size = new System.Drawing.Size(202, 22);
            this.menuAddFloutecLine.Text = "Добавить нитку";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // menuEditFloutec
            // 
            this.menuEditFloutec.Name = "menuEditFloutec";
            this.menuEditFloutec.Size = new System.Drawing.Size(202, 22);
            this.menuEditFloutec.Text = "Изменить";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // menuDeleteFloutec
            // 
            this.menuDeleteFloutec.Name = "menuDeleteFloutec";
            this.menuDeleteFloutec.Size = new System.Drawing.Size(202, 22);
            this.menuDeleteFloutec.Text = "Удалить";
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
            this.Controls.Add(this.groupFloutecsLog);
            this.Controls.Add(this.groupFloutecsProperties);
            this.Controls.Add(this.status);
            this.Controls.Add(this.groupFloutecs);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "Программа опроса вычислителей ПрАТ \"Нефтегаздобыча\"";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupFloutecs.ResumeLayout(false);
            this.contextMenuFloutecs.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupFloutecsProperties;
        private System.Windows.Forms.GroupBox groupFloutecs;
        private System.Windows.Forms.TreeView treeFloutecs;
        private System.Windows.Forms.ContextMenuStrip contextMenuFloutecs;
        private System.Windows.Forms.ToolStripMenuItem menuAddFloutec;
        private System.Windows.Forms.ToolStripMenuItem menuAddFloutecLine;
        private System.Windows.Forms.GroupBox groupFloutecsLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteFloutec;
        private System.Windows.Forms.ToolStripMenuItem menuEditFloutec;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

