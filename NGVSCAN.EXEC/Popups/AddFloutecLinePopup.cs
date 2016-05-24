using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Popups
{
    public partial class AddFloutecLinePopup : Form
    {
        public FloutecMeasureLine FloutecLine { get; set; }

        public List<FloutecMeasureLine> FloutecLines { get; set; }

        public bool IsEdit { get; set; }

        public AddFloutecLinePopup()
        {
            InitializeComponent();

            comboSensorTypes.Items.AddRange(Enum.GetNames(typeof(SensorTypeEnum)));
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

            if (comboSensorTypes.SelectedIndex < 0)
            {
                labelSensorTypeError.Text = "Укажите тип датчика";
                labelSensorTypeError.Visible = true;
            }
            else
            {
                labelSensorTypeError.Visible = false;
            }

            FloutecMeasureLine existingLine;
            if (!IsEdit)
            {
                existingLine = FloutecLines.FirstOrDefault(l => l.Number == (int)numericNumber.Value);
            }
            else
            {
                existingLine = FloutecLines.FirstOrDefault(l => l.Number == (int)numericNumber.Value && l.Number != FloutecLine.Number);
            }

            if (existingLine != null)
            {
                labelNumberError.Text = "Нитка уже существует";
                labelNumberError.Visible = true;
            }
            else
            {
                labelNumberError.Visible = false;
            }

            if (!labelNameError.Visible && !labelDescriptionError.Visible && !labelSensorTypeError.Visible && !labelNumberError.Visible)
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
