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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabFloutecs = new System.Windows.Forms.TabPage();
            this.groupFloutecsLog = new System.Windows.Forms.GroupBox();
            this.groupFloutecsProperties = new System.Windows.Forms.GroupBox();
            this.groupFloutecs = new System.Windows.Forms.GroupBox();
            this.treeFloutecs = new System.Windows.Forms.TreeView();
            this.contextMenuFloutecs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddFloutec = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddFloutecLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDeleteFloutec = new System.Windows.Forms.ToolStripMenuItem();
            this.tabROC809s = new System.Windows.Forms.TabPage();
            this.status = new System.Windows.Forms.StatusStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs.SuspendLayout();
            this.tabFloutecs.SuspendLayout();
            this.groupFloutecs.SuspendLayout();
            this.contextMenuFloutecs.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabFloutecs);
            this.tabs.Controls.Add(this.tabROC809s);
            this.tabs.Location = new System.Drawing.Point(12, 27);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(860, 509);
            this.tabs.TabIndex = 0;
            // 
            // tabFloutecs
            // 
            this.tabFloutecs.Controls.Add(this.groupFloutecsLog);
            this.tabFloutecs.Controls.Add(this.groupFloutecsProperties);
            this.tabFloutecs.Controls.Add(this.groupFloutecs);
            this.tabFloutecs.Location = new System.Drawing.Point(4, 22);
            this.tabFloutecs.Name = "tabFloutecs";
            this.tabFloutecs.Padding = new System.Windows.Forms.Padding(3);
            this.tabFloutecs.Size = new System.Drawing.Size(852, 483);
            this.tabFloutecs.TabIndex = 0;
            this.tabFloutecs.Text = "Вычислители ФЛОУТЭК";
            this.tabFloutecs.UseVisualStyleBackColor = true;
            // 
            // groupFloutecsLog
            // 
            this.groupFloutecsLog.Location = new System.Drawing.Point(7, 364);
            this.groupFloutecsLog.Name = "groupFloutecsLog";
            this.groupFloutecsLog.Size = new System.Drawing.Size(839, 113);
            this.groupFloutecsLog.TabIndex = 2;
            this.groupFloutecsLog.TabStop = false;
            this.groupFloutecsLog.Text = "Сообщения";
            // 
            // groupFloutecsProperties
            // 
            this.groupFloutecsProperties.Location = new System.Drawing.Point(313, 7);
            this.groupFloutecsProperties.Name = "groupFloutecsProperties";
            this.groupFloutecsProperties.Size = new System.Drawing.Size(534, 350);
            this.groupFloutecsProperties.TabIndex = 1;
            this.groupFloutecsProperties.TabStop = false;
            this.groupFloutecsProperties.Text = "Свойства";
            // 
            // groupFloutecs
            // 
            this.groupFloutecs.Controls.Add(this.treeFloutecs);
            this.groupFloutecs.Location = new System.Drawing.Point(7, 7);
            this.groupFloutecs.Name = "groupFloutecs";
            this.groupFloutecs.Size = new System.Drawing.Size(300, 350);
            this.groupFloutecs.TabIndex = 0;
            this.groupFloutecs.TabStop = false;
            this.groupFloutecs.Text = "Вычислители";
            // 
            // treeFloutecs
            // 
            this.treeFloutecs.BackColor = System.Drawing.SystemColors.Window;
            this.treeFloutecs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeFloutecs.ContextMenuStrip = this.contextMenuFloutecs;
            this.treeFloutecs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFloutecs.Location = new System.Drawing.Point(3, 16);
            this.treeFloutecs.Name = "treeFloutecs";
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
            this.treeFloutecs.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.treeFloutecs.Size = new System.Drawing.Size(294, 331);
            this.treeFloutecs.TabIndex = 0;
            this.treeFloutecs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFloutecs_AfterSelect);
            // 
            // contextMenuFloutecs
            // 
            this.contextMenuFloutecs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddFloutec,
            this.menuAddFloutecLine,
            this.toolStripSeparator1,
            this.menuDeleteFloutec});
            this.contextMenuFloutecs.Name = "contextMenuFloutecs";
            this.contextMenuFloutecs.Size = new System.Drawing.Size(203, 76);
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
            // menuDeleteFloutec
            // 
            this.menuDeleteFloutec.Name = "menuDeleteFloutec";
            this.menuDeleteFloutec.Size = new System.Drawing.Size(202, 22);
            this.menuDeleteFloutec.Text = "Удалить";
            // 
            // tabROC809s
            // 
            this.tabROC809s.Location = new System.Drawing.Point(4, 22);
            this.tabROC809s.Name = "tabROC809s";
            this.tabROC809s.Padding = new System.Windows.Forms.Padding(3);
            this.tabROC809s.Size = new System.Drawing.Size(852, 483);
            this.tabROC809s.TabIndex = 1;
            this.tabROC809s.Text = "Вычислители ROC809";
            this.tabROC809s.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.tabs);
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "Программа опроса вычислителей ПрАТ \"Нефтегаздобыча\"";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabs.ResumeLayout(false);
            this.tabFloutecs.ResumeLayout(false);
            this.groupFloutecs.ResumeLayout(false);
            this.contextMenuFloutecs.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabFloutecs;
        private System.Windows.Forms.TabPage tabROC809s;
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
    }
}

