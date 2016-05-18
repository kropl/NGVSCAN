using NGVSCAN.CORE.Entities;
using System;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Popups
{
    public partial class AddFloutecPopup : Form
    {
        public Floutec Floutec { get; set; }

        public bool IsEdit { get; set; }

        public AddFloutecPopup()
        {
            InitializeComponent();
        }

        private void buttonAddFloutec_Click(object sender, EventArgs e)
        {
            labelNameError.Text = "Укажите название вычислителя";
            labelDescriptionError.Text = "Укажите описание вычислителя";

            if (string.IsNullOrEmpty(textName.Text))
                labelNameError.Visible = true;
            else
                labelNameError.Visible = false;

            if (string.IsNullOrEmpty(textDescription.Text))
                labelDescriptionError.Visible = true;
            else
                labelDescriptionError.Visible = false;

            if (!labelNameError.Visible && !labelDescriptionError.Visible)
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
