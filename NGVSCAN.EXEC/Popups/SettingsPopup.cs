using NGVSCAN.EXEC.Common;
using System;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Popups
{
    public partial class SettingsPopup : Form
    {
        public SettingsPopup()
        {
            InitializeComponent();

            labelDbfTablesPath.Text = Settings.DbfTablesPath;
            textServerName.Text = Settings.ServerName;
            textSqlDatabaseName.Text = Settings.SqlDatabaseName;
            textSqlServerPath.Text = Settings.SqlServerPath;
            textSqlUserName.Text = Settings.SqlUserName;
            textSqlUserPassword.Text = Settings.SqlUserPassword;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textServerName.Text))
            {
                labelServerNameError.Text = "Укажите имя текущего сервера";
                labelServerNameError.Visible = true;
            }
            else
            {
                labelServerNameError.Visible = false;
            }

            if (string.IsNullOrEmpty(textSqlServerPath.Text))
            {
                labelSqlServerPathError.Text = "Укажите имя сервера БД SQL";
                labelSqlServerPathError.Visible = true;
            }
            else
            {
                labelSqlServerPathError.Visible = false;
            }

            if (string.IsNullOrEmpty(textSqlDatabaseName.Text))
            {
                labelSqlDatabaseNameError.Text = "Укажите название БД SQL";
                labelSqlDatabaseNameError.Visible = true;
            }
            else
            {
                labelSqlDatabaseNameError.Visible = false;
            }

            if (string.IsNullOrEmpty(labelDbfTablesPath.Text))
            {
                labelDbfTablesPathError.Text = "Укажите путь к таблицам DBF";
                labelDbfTablesPathError.Visible = true;
            }
            else
            {
                labelDbfTablesPathError.Visible = false;
            }

            if (string.IsNullOrEmpty(textSqlUserName.Text) & !string.IsNullOrEmpty(textSqlUserPassword.Text))
            {
                labelSqlUserNameError.Text = "Укажите имя пользователя БД SQL";
                labelSqlUserNameError.Visible = true;
            }
            else
            {
                labelSqlUserNameError.Visible = false;
            }

            if (string.IsNullOrEmpty(textSqlUserPassword.Text) & !string.IsNullOrEmpty(textSqlUserName.Text))
            {
                labelSqlUserPasswordError.Text = "Укажите пароль пользователя БД SQL";
                labelSqlUserPasswordError.Visible = true;
            }
            else
            {
                labelSqlUserPasswordError.Visible = false;
            }

            if (!labelServerNameError.Visible && !labelSqlServerPathError.Visible &&
                !labelSqlDatabaseNameError.Visible && !labelDbfTablesPathError.Visible &&
                !labelSqlUserNameError.Visible && !labelSqlUserPasswordError.Visible)
            {
                DialogResult = DialogResult.OK;

                Settings.DbfTablesPath = labelDbfTablesPath.Text;
                Settings.ServerName = textServerName.Text;
                Settings.SqlDatabaseName = textSqlDatabaseName.Text;
                Settings.SqlServerPath = textSqlServerPath.Text;
                Settings.SqlUserName = textSqlUserName.Text;
                Settings.SqlUserPassword = textSqlUserPassword.Text;

                Settings.Save();

                Close();
            }
        }

        private void buttonOpenDirDialogue_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                labelDbfTablesPath.Text = dialog.SelectedPath ?? "";
            }
        }
    }
}
