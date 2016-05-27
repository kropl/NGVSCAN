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
