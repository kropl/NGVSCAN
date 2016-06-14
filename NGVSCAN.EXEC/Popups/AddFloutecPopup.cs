using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Entities.Floutecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Popups
{
    public partial class AddFloutecPopup : Form
    {
        public Floutec Floutec { get; set; }

        public List<Floutec> Floutecs { get; set; }

        public bool IsEdit { get; set; }

        public AddFloutecPopup()
        {
            InitializeComponent();
        }

        private void buttonAddFloutec_Click(object sender, EventArgs e)
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

            Floutec existingFloutec;
            if (!IsEdit)
            {
                existingFloutec = Floutecs.FirstOrDefault(f => f.Address == (int)numericAddress.Value);
            }
            else
            {
                existingFloutec = Floutecs.FirstOrDefault(f => f.Address == (int)numericAddress.Value && f.Address != Floutec.Address);
            }           

            if (existingFloutec != null)
            {
                labelAddressError.Text = "Вычислитель уже существует";
                labelAddressError.Visible = true;
            }
            else
            {
                labelAddressError.Visible = false;
            }

            if (!labelNameError.Visible && !labelDescriptionError.Visible && !labelAddressError.Visible)
            {
                if (!IsEdit)
                {
                    Floutec = new Floutec();
                }

                Floutec.Address = (int)numericAddress.Value;
                Floutec.Name = textName.Text;
                Floutec.Description = textDescription.Text;

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void buttonCancelAddFloutec_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void AddFloutecPopup_Load(object sender, EventArgs e)
        {
            Text = IsEdit ? "Изменение вычислителя ФЛОУТЭК" : "Добавление вычислителя ФЛОУТЭК";

            if (IsEdit)
            {
                numericAddress.Value = Floutec.Address;
                textName.Text = Floutec.Name;
                textDescription.Text = Floutec.Description;
            }
        }
    }
}
