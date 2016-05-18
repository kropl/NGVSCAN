using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Enums;
using System;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Popups
{
    public partial class AddFloutecLinePopup : Form
    {
        public FloutecMeasureLine FloutecLine { get; set; }

        public bool IsEdit { get; set; }

        public AddFloutecLinePopup()
        {
            InitializeComponent();

            comboSensorTypes.Items.AddRange(Enum.GetNames(typeof(SensorTypeEnum)));
        }

        private void buttonAddFloutec_Click(object sender, EventArgs e)
        {
            labelNameError.Text = "Укажите название вычислителя";
            labelDescriptionError.Text = "Укажите описание вычислителя";
            labelSensorTypeError.Text = "Укажите тип датчика";

            if (string.IsNullOrEmpty(textName.Text))
                labelNameError.Visible = true;
            else
                labelNameError.Visible = false;

            if (string.IsNullOrEmpty(textDescription.Text))
                labelDescriptionError.Visible = true;
            else
                labelDescriptionError.Visible = false;

            if (comboSensorTypes.SelectedIndex < 0)
                labelSensorTypeError.Visible = true;
            else
                labelSensorTypeError.Visible = false;

            if (!labelNameError.Visible && !labelDescriptionError.Visible && !labelSensorTypeError.Visible)
            {
                if (!IsEdit)
                {
                    FloutecLine = new FloutecMeasureLine();
                }

                FloutecLine.Number = (int)numericNumber.Value;
                FloutecLine.Name = textName.Text;
                FloutecLine.Description = textDescription.Text;
                FloutecLine.SensorType = (SensorTypeEnum)Enum.Parse(typeof(SensorTypeEnum), comboSensorTypes.SelectedItem.ToString());

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void buttonCancelAddFloutec_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void AddFloutecLinePopup_Load(object sender, EventArgs e)
        {
            Text = IsEdit ? "Изменение нитки измерения" : "Добавление нитки измерения";

            if (IsEdit)
            {
                numericNumber.Value = FloutecLine.Number;
                textName.Text = FloutecLine.Name;
                textDescription.Text = FloutecLine.Description;
                comboSensorTypes.SelectedItem = Enum.GetName(typeof(SensorTypeEnum), FloutecLine.SensorType);
            }
        }
    }
}
