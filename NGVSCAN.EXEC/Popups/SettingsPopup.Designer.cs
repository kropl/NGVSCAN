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
            this.labelServerNameError = new System.Windows.Forms.Label();
            this.labelSqlServerPathError = new System.Windows.Forms.Label();
            this.labelSqlUserNameError = new System.Windows.Forms.Label();
            this.labelSqlUserPasswordError = new System.Windows.Forms.Label();
            this.labelSqlDatabaseNameError = new System.Windows.Forms.Label();
            this.labelDbfTablesPathError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(317, 286);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(236, 286);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя сервера:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сервер БД SQL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Имя пользователя БД SQL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Пароль пользователя БД SQL:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Название БД SQL:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Путь к таблицам DBF:";
            // 
            // textServerName
            // 
            this.textServerName.Location = new System.Drawing.Point(187, 32);
            this.textServerName.Name = "textServerName";
            this.textServerName.Size = new System.Drawing.Size(205, 20);
            this.textServerName.TabIndex = 0;
            // 
            // textSqlServerPath
            // 
            this.textSqlServerPath.Location = new System.Drawing.Point(187, 75);
            this.textSqlServerPath.Name = "textSqlServerPath";
            this.textSqlServerPath.Size = new System.Drawing.Size(205, 20);
            this.textSqlServerPath.TabIndex = 1;
            // 
            // textSqlUserName
            // 
            this.textSqlUserName.Location = new System.Drawing.Point(187, 118);
            this.textSqlUserName.Name = "textSqlUserName";
            this.textSqlUserName.Size = new System.Drawing.Size(205, 20);
            this.textSqlUserName.TabIndex = 2;
            // 
            // textSqlUserPassword
            // 
            this.textSqlUserPassword.Location = new System.Drawing.Point(187, 161);
            this.textSqlUserPassword.Name = "textSqlUserPassword";
            this.textSqlUserPassword.PasswordChar = '*';
            this.textSqlUserPassword.Size = new System.Drawing.Size(205, 20);
            this.textSqlUserPassword.TabIndex = 3;
            // 
            // textSqlDatabaseName
            // 
            this.textSqlDatabaseName.Location = new System.Drawing.Point(187, 204);
            this.textSqlDatabaseName.Name = "textSqlDatabaseName";
            this.textSqlDatabaseName.Size = new System.Drawing.Size(205, 20);
            this.textSqlDatabaseName.TabIndex = 4;
            // 
            // labelDbfTablesPath
            // 
            this.labelDbfTablesPath.AutoSize = true;
            this.labelDbfTablesPath.Location = new System.Drawing.Point(184, 249);
            this.labelDbfTablesPath.Name = "labelDbfTablesPath";
            this.labelDbfTablesPath.Size = new System.Drawing.Size(35, 13);
            this.labelDbfTablesPath.TabIndex = 13;
            this.labelDbfTablesPath.Text = "label7";
            // 
            // buttonOpenDirDialogue
            // 
            this.buttonOpenDirDialogue.Location = new System.Drawing.Point(367, 244);
            this.buttonOpenDirDialogue.Name = "buttonOpenDirDialogue";
            this.buttonOpenDirDialogue.Size = new System.Drawing.Size(25, 23);
            this.buttonOpenDirDialogue.TabIndex = 5;
            this.buttonOpenDirDialogue.Text = "...";
            this.buttonOpenDirDialogue.UseVisualStyleBackColor = true;
            this.buttonOpenDirDialogue.Click += new System.EventHandler(this.buttonOpenDirDialogue_Click);
            // 
            // labelServerNameError
            // 
            this.labelServerNameError.AutoSize = true;
            this.labelServerNameError.ForeColor = System.Drawing.Color.Red;
            this.labelServerNameError.Location = new System.Drawing.Point(187, 16);
            this.labelServerNameError.Name = "labelServerNameError";
            this.labelServerNameError.Size = new System.Drawing.Size(29, 13);
            this.labelServerNameError.TabIndex = 15;
            this.labelServerNameError.Text = "Error";
            this.labelServerNameError.Visible = false;
            // 
            // labelSqlServerPathError
            // 
            this.labelSqlServerPathError.AutoSize = true;
            this.labelSqlServerPathError.ForeColor = System.Drawing.Color.Red;
            this.labelSqlServerPathError.Location = new System.Drawing.Point(187, 59);
            this.labelSqlServerPathError.Name = "labelSqlServerPathError";
            this.labelSqlServerPathError.Size = new System.Drawing.Size(29, 13);
            this.labelSqlServerPathError.TabIndex = 16;
            this.labelSqlServerPathError.Text = "Error";
            this.labelSqlServerPathError.Visible = false;
            // 
            // labelSqlUserNameError
            // 
            this.labelSqlUserNameError.AutoSize = true;
            this.labelSqlUserNameError.ForeColor = System.Drawing.Color.Red;
            this.labelSqlUserNameError.Location = new System.Drawing.Point(187, 102);
            this.labelSqlUserNameError.Name = "labelSqlUserNameError";
            this.labelSqlUserNameError.Size = new System.Drawing.Size(29, 13);
            this.labelSqlUserNameError.TabIndex = 17;
            this.labelSqlUserNameError.Text = "Error";
            this.labelSqlUserNameError.Visible = false;
            // 
            // labelSqlUserPasswordError
            // 
            this.labelSqlUserPasswordError.AutoSize = true;
            this.labelSqlUserPasswordError.ForeColor = System.Drawing.Color.Red;
            this.labelSqlUserPasswordError.Location = new System.Drawing.Point(187, 145);
            this.labelSqlUserPasswordError.Name = "labelSqlUserPasswordError";
            this.labelSqlUserPasswordError.Size = new System.Drawing.Size(29, 13);
            this.labelSqlUserPasswordError.TabIndex = 18;
            this.labelSqlUserPasswordError.Text = "Error";
            this.labelSqlUserPasswordError.Visible = false;
            // 
            // labelSqlDatabaseNameError
            // 
            this.labelSqlDatabaseNameError.AutoSize = true;
            this.labelSqlDatabaseNameError.ForeColor = System.Drawing.Color.Red;
            this.labelSqlDatabaseNameError.Location = new System.Drawing.Point(187, 188);
            this.labelSqlDatabaseNameError.Name = "labelSqlDatabaseNameError";
            this.labelSqlDatabaseNameError.Size = new System.Drawing.Size(29, 13);
            this.labelSqlDatabaseNameError.TabIndex = 19;
            this.labelSqlDatabaseNameError.Text = "Error";
            this.labelSqlDatabaseNameError.Visible = false;
            // 
            // labelDbfTablesPathError
            // 
            this.labelDbfTablesPathError.AutoSize = true;
            this.labelDbfTablesPathError.ForeColor = System.Drawing.Color.Red;
            this.labelDbfTablesPathError.Location = new System.Drawing.Point(187, 231);
            this.labelDbfTablesPathError.Name = "labelDbfTablesPathError";
            this.labelDbfTablesPathError.Size = new System.Drawing.Size(29, 13);
            this.labelDbfTablesPathError.TabIndex = 20;
            this.labelDbfTablesPathError.Text = "Error";
            this.labelDbfTablesPathError.Visible = false;
            // 
            // SettingsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 321);
            this.Controls.Add(this.labelDbfTablesPathError);
            this.Controls.Add(this.labelSqlDatabaseNameError);
            this.Controls.Add(this.labelSqlUserPasswordError);
            this.Controls.Add(this.labelSqlUserNameError);
            this.Controls.Add(this.labelSqlServerPathError);
            this.Controls.Add(this.labelServerNameError);
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
            this.MaximumSize = new System.Drawing.Size(420, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 360);
            this.Name = "SettingsPopup";
            this.Text = "Настройки";
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
        private System.Windows.Forms.Label labelServerNameError;
        private System.Windows.Forms.Label labelSqlServerPathError;
        private System.Windows.Forms.Label labelSqlUserNameError;
        private System.Windows.Forms.Label labelSqlUserPasswordError;
        private System.Windows.Forms.Label labelSqlDatabaseNameError;
        private System.Windows.Forms.Label labelDbfTablesPathError;
    }
}