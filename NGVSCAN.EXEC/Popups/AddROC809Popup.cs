using NGVSCAN.CORE.Entities.ROC809s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Popups
{
    public partial class AddROC809Popup : Form
    {
        public ROC809 ROC809 { get; set; }

        public List<ROC809> ROC809s { get; set; }

        public bool IsEdit { get; set; }

        public AddROC809Popup()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textName.Text))
            {
                labelNameError.Text = "Укажите название вычислителя";
                labelNameError.Visible = true;
            }
            else
            {
                labelNameError.Visible = false;
            }

            if (string.IsNullOrEmpty(textDescription.Text))
            {
                labelDescriptionError.Text = "Укажите описание вычислителя";
                labelDescriptionError.Visible = true;
            }
            else
            {
                labelDescriptionError.Visible = false;
            }

            ROC809 existingROC;
            string ip = GetIpFromParts((int)numericIP1.Value, (int)numericIP2.Value, (int)numericIP3.Value, (int)numericIP4.Value);
            if (!IsEdit)
            {
                existingROC = ROC809s.FirstOrDefault(r => r.Address.Equals(ip));
            }
            else
            {
                existingROC = ROC809s.FirstOrDefault(r => r.Address.Equals(ip) && !r.Address.Equals(ROC809.Address));
            }

            if (existingROC != null)
            {
                labelIPError.Text = "Вычислитель уже существует";
                labelIPError.Visible = true;
            }
            else
            {
                labelIPError.Visible = false;
            }

            if (!labelNameError.Visible && !labelDescriptionError.Visible && !labelIPError.Visible)
            {
                if (!IsEdit)
                {
                    ROC809 = new ROC809();
                }

                ROC809.Address = ip;
                ROC809.Name = textName.Text;
                ROC809.Description = textDescription.Text;
                ROC809.ROCUnit = (int)numericROCUnit.Value;
                ROC809.ROCGroup = (int)numericROCGroup.Value;
                ROC809.HostUnit = (int)numericHOSTUnit.Value;
                ROC809.HostGroup = (int)numericHOSTGroup.Value;
                ROC809.Port = (int)numericPort.Value;

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private string GetIpFromParts(int part1, int part2, int part3, int part4)
        {
            return string.Format("{0}.{1}.{2}.{3}", part1, part2, part3, part4);
        }

        private int[] GetPartsFromIp(string ip)
        {
            string[] parts = ip.Split('.');

            return Array.ConvertAll(parts, p => int.Parse(p));
        }

        private void AddROC809Popup_Load(object sender, EventArgs e)
        {
            Text = IsEdit ? "Изменение вычислителя ROC809" : "Добавление вычислителя ROC809";

            if (IsEdit)
            {
                int[] ipParts = GetPartsFromIp(ROC809.Address);

                numericIP1.Value = ipParts[0];
                numericIP2.Value = ipParts[1];
                numericIP3.Value = ipParts[2];
                numericIP4.Value = ipParts[3];
                textName.Text = ROC809.Name;
                textDescription.Text = ROC809.Description;
                numericPort.Value = ROC809.Port;
                numericROCGroup.Value = ROC809.ROCGroup;
                numericROCUnit.Value = ROC809.ROCUnit;
                numericHOSTGroup.Value = ROC809.HostGroup;
                numericHOSTUnit.Value = ROC809.HostUnit;
            }
        }
    }
}
