namespace NGVSCAN.EXEC.Popups
{
    partial class SettingsPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPopup));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textServerName = new System.Windows.Forms.TextBox();
            this.textSqlServerPath = new System.Windows.Forms.TextBox();
            this.textSqlUserName = new System.Windows.Forms.TextBox();
            this.textSqlUserPassword = new System.Windows.Forms.TextBox();
            this.textSqlDatabaseName = new System.Windows.Forms.TextBox();
            this.labelDbfTablesPath = new System.Windows.Forms.Label();
            this.buttonOpenDirDialogue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(297, 225);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(216, 225);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя сервера:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сервер БД SQL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Имя пользователя БД SQL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Пароль пользователя БД SQL:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Название БД SQL:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Путь к таблицам DBF:";
            // 
            // textServerName
            // 
            this.textServerName.Location = new System.Drawing.Point(187, 10);
            this.textServerName.Name = "textServerName";
            this.textServerName.Size = new System.Drawing.Size(185, 20);
            this.textServerName.TabIndex = 8;
            // 
            // textSqlServerPath
            // 
            this.textSqlServerPath.Location = new System.Drawing.Point(187, 37);
            this.textSqlServerPath.Name = "textSqlServerPath";
            this.textSqlServerPath.Size = new System.Drawing.Size(185, 20);
            this.textSqlServerPath.TabIndex = 9;
            // 
            // textSqlUserName
            // 
            this.textSqlUserName.Location = new System.Drawing.Point(187, 64);
            this.textSqlUserName.Name = "textSqlUserName";
            this.textSqlUserName.Size = new System.Drawing.Size(185, 20);
            this.textSqlUserName.TabIndex = 10;
            // 
            // textSqlUserPassword
            // 
            this.textSqlUserPassword.Location = new System.Drawing.Point(187, 91);
            this.textSqlUserPassword.Name = "textSqlUserPassword";
            this.textSqlUserPassword.PasswordChar = '*';
            this.textSqlUserPassword.Size = new System.Drawing.Size(185, 20);
            this.textSqlUserPassword.TabIndex = 11;
            // 
            // textSqlDatabaseName
            // 
            this.textSqlDatabaseName.Location = new System.Drawing.Point(187, 118);
            this.textSqlDatabaseName.Name = "textSqlDatabaseName";
            this.textSqlDatabaseName.Size = new System.Drawing.Size(185, 20);
            this.textSqlDatabaseName.TabIndex = 12;
            // 
            // labelDbfTablesPath
            // 
            this.labelDbfTablesPath.AutoSize = true;
            this.labelDbfTablesPath.Location = new System.Drawing.Point(184, 150);
            this.labelDbfTablesPath.Name = "labelDbfTablesPath";
            this.labelDbfTablesPath.Size = new System.Drawing.Size(35, 13);
            this.labelDbfTablesPath.TabIndex = 13;
            this.labelDbfTablesPath.Text = "label7";
            // 
            // buttonOpenDirDialogue
            // 
            this.buttonOpenDirDialogue.Location = new System.Drawing.Point(347, 145);
            this.buttonOpenDirDialogue.Name = "buttonOpenDirDialogue";
            this.buttonOpenDirDialogue.Size = new System.Drawing.Size(25, 23);
            this.buttonOpenDirDialogue.TabIndex = 14;
            this.buttonOpenDirDialogue.Text = "...";
            this.buttonOpenDirDialogue.UseVisualStyleBackColor = true;
            this.buttonOpenDirDialogue.Click += new System.EventHandler(this.buttonOpenDirDialogue_Click);
            // 
            // SettingsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.buttonOpenDirDialogue);
            this.Controls.Add(this.labelDbfTablesPath);
            this.Controls.Add(this.textSqlDatabaseName);
            this.Controls.Add(this.textSqlUserPassword);
            this.Controls.Add(this.textSqlUserName);
            this.Controls.Add(this.textSqlServerPath);
            this.Controls.Add(this.textServerName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "SettingsPopup";
            this.Text = "SettingsPopup";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textServerName;
        private System.Windows.Forms.TextBox textSqlServerPath;
        private System.Windows.Forms.TextBox textSqlUserName;
        private System.Windows.Forms.TextBox textSqlUserPassword;
        private System.Windows.Forms.TextBox textSqlDatabaseName;
        private System.Windows.Forms.Label labelDbfTablesPath;
        private System.Windows.Forms.Button buttonOpenDirDialogue;
    }
}