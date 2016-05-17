using NGVSCAN.CORE.Entities;
using System;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Popups
{
    public partial class AddFloutecPopup : Form
    {
        public Floutec Floutec { get; set; }

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
                Floutec = new Floutec();

                Floutec.Address = (int)numericAddress.Value;
                Floutec.Name = textName.Text;
                Floutec.Description = textDescription.Text;

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void buttonCancelAddFloutec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
