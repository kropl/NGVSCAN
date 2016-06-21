using NGVSCAN.EXEC.Controls;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupEstimatorsLog = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listLogMessages = new LogListView();
            this.columnLogStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLogType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLogTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLogMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListLog = new System.Windows.Forms.ImageList(this.components);
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.status = new System.Windows.Forms.StatusStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupEstimatorsLog.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupEstimators.SuspendLayout();
            this.contextMenuEstimators.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupEstimatorsLog
            // 
            this.groupEstimatorsLog.Controls.Add(this.tableLayoutPanel1);
            this.groupEstimatorsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEstimatorsLog.Location = new System.Drawing.Point(0, 0);
            this.groupEstimatorsLog.Name = "groupEstimatorsLog";
            this.groupEstimatorsLog.Size = new System.Drawing.Size(884, 182);
            this.groupEstimatorsLog.TabIndex = 2;
            this.groupEstimatorsLog.TabStop = false;
            this.groupEstimatorsLog.Text = "Сообщения";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listLogMessages, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 163);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // listLogMessages
            // 
            this.listLogMessages.BackColor = System.Drawing.SystemColors.Control;
            this.listLogMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listLogMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnLogStatus,
            this.columnLogType,
            this.columnLogTimestamp,
            this.columnLogMessage});
            this.tableLayoutPanel1.SetColumnSpan(this.listLogMessages, 4);
            this.listLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLogMessages.FullRowSelect = true;
            this.listLogMessages.Location = new System.Drawing.Point(3, 33);
            this.listLogMessages.MultiSelect = false;
            this.listLogMessages.Name = "listLogMessages";
            this.listLogMessages.Size = new System.Drawing.Size(872, 127);
            this.listLogMessages.StateImageList = this.imageListLog;
            this.listLogMessages.TabIndex = 0;
            this.listLogMessages.UseCompatibleStateImageBehavior = false;
            this.listLogMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnLogStatus
            // 
            this.columnLogStatus.Text = "Статус";
            // 
            // columnLogType
            // 
            this.columnLogType.Text = "Тип";
            // 
            // columnLogTimestamp
            // 
            this.columnLogTimestamp.Text = "Дата и время";
            // 
            // columnLogMessage
            // 
            this.columnLogMessage.Text = "Сообщение";
            // 
            // imageListLog
            // 
            this.imageListLog.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLog.ImageStream")));
            this.imageListLog.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLog.Images.SetKeyName(0, "Info-48.png");
            this.imageListLog.Images.SetKeyName(1, "Ok-48.png");
            this.imageListLog.Images.SetKeyName(2, "Attention-48.png");
            this.imageListLog.Images.SetKeyName(3, "High Priority-48.png");
            // 
            // groupEstimatorsProperties
            // 
            this.groupEstimatorsProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEstimatorsProperties.Location = new System.Drawing.Point(0, 0);
            this.groupEstimatorsProperties.Name = "groupEstimatorsProperties";
            this.groupEstimatorsProperties.Size = new System.Drawing.Size(634, 329);
            this.groupEstimatorsProperties.TabIndex = 1;
            this.groupEstimatorsProperties.TabStop = false;
            this.groupEstimatorsProperties.Text = "Свойства";
            // 
            // groupEstimators
            // 
            this.groupEstimators.Controls.Add(this.treeEstimators);
            this.groupEstimators.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEstimators.Location = new System.Drawing.Point(0, 0);
            this.groupEstimators.Name = "groupEstimators";
            this.groupEstimators.Size = new System.Drawing.Size(246, 329);
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
            this.treeEstimators.ImageIndex = 0;
            this.treeEstimators.ImageList = this.imageList;
            this.treeEstimators.Location = new System.Drawing.Point(3, 16);
            this.treeEstimators.Name = "treeEstimators";
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
            this.treeEstimators.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeEstimators.SelectedImageIndex = 0;
            this.treeEstimators.Size = new System.Drawing.Size(240, 310);
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
            this.menuDelete,
            this.toolStripSeparator3,
            this.menuRestore});
            this.contextMenuEstimators.Name = "contextMenuFloutecs";
            this.contextMenuEstimators.Size = new System.Drawing.Size(203, 132);
            this.contextMenuEstimators.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuFloutecs_Opening);
            this.contextMenuEstimators.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuFloutecs_ItemClicked);
            // 
            // menuAddEstimator
            // 
            this.menuAddEstimator.Image = ((System.Drawing.Image)(resources.GetObject("menuAddEstimator.Image")));
            this.menuAddEstimator.Name = "menuAddEstimator";
            this.menuAddEstimator.Size = new System.Drawing.Size(202, 22);
            this.menuAddEstimator.Text = "Добавить вычислитель";
            // 
            // menuAddMeasureLine
            // 
            this.menuAddMeasureLine.Image = ((System.Drawing.Image)(resources.GetObject("menuAddMeasureLine.Image")));
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
            this.menuEdit.Image = ((System.Drawing.Image)(resources.GetObject("menuEdit.Image")));
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
            this.menuDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuDelete.Image")));
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(202, 22);
            this.menuDelete.Text = "Удалить";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // menuRestore
            // 
            this.menuRestore.Image = ((System.Drawing.Image)(resources.GetObject("menuRestore.Image")));
            this.menuRestore.Name = "menuRestore";
            this.menuRestore.Size = new System.Drawing.Size(202, 22);
            this.menuRestore.Text = "Восстановить";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Factory-48.png");
            this.imageList.Images.SetKeyName(1, "Module-48.png");
            this.imageList.Images.SetKeyName(2, "DB 2-48.png");
            this.imageList.Images.SetKeyName(3, "Ethernet Off-48.png");
            this.imageList.Images.SetKeyName(4, "Electrical Threshold-48.png");
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
            this.menuRun,
            this.menuStop,
            this.menuSettings,
            this.menuAbout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(884, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // menuRun
            // 
            this.menuRun.Image = ((System.Drawing.Image)(resources.GetObject("menuRun.Image")));
            this.menuRun.Name = "menuRun";
            this.menuRun.Size = new System.Drawing.Size(73, 20);
            this.menuRun.Text = "Запуск";
            this.menuRun.Click += new System.EventHandler(this.menuRun_Click);
            // 
            // menuStop
            // 
            this.menuStop.Image = ((System.Drawing.Image)(resources.GetObject("menuStop.Image")));
            this.menuStop.Name = "menuStop";
            this.menuStop.Size = new System.Drawing.Size(81, 20);
            this.menuStop.Text = "Останов";
            this.menuStop.Visible = false;
            this.menuStop.Click += new System.EventHandler(this.menuStop_Click);
            // 
            // menuSettings
            // 
            this.menuSettings.Image = ((System.Drawing.Image)(resources.GetObject("menuSettings.Image")));
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(95, 20);
            this.menuSettings.Text = "Настройки";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Image = ((System.Drawing.Image)(resources.GetObject("menuAbout.Image")));
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(110, 20);
            this.menuAbout.Text = "О программе";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupEstimatorsLog);
            this.splitContainer1.Size = new System.Drawing.Size(884, 515);
            this.splitContainer1.SplitterDistance = 329;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupEstimators);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupEstimatorsProperties);
            this.splitContainer2.Size = new System.Drawing.Size(884, 329);
            this.splitContainer2.SplitterDistance = 246;
            this.splitContainer2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(33, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(63, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "MainForm";
            this.Text = "mainform";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupEstimatorsLog.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupEstimators.ResumeLayout(false);
            this.contextMenuEstimators.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuRestore;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ImageList imageListLog;
        private System.Windows.Forms.ToolStripMenuItem menuRun;
        private System.Windows.Forms.ToolStripMenuItem menuStop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private LogListView listLogMessages;
        private System.Windows.Forms.ColumnHeader columnLogStatus;
        private System.Windows.Forms.ColumnHeader columnLogType;
        private System.Windows.Forms.ColumnHeader columnLogTimestamp;
        private System.Windows.Forms.ColumnHeader columnLogMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

