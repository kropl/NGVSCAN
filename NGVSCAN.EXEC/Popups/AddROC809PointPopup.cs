using NGVSCAN.CORE.Entities.ROC809s;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Popups
{
    public partial class AddROC809PointPopup : Form
    {
        public ROC809MeasurePoint ROCPoint { get; set; }

        public List<ROC809MeasurePoint> ROCPoints { get; set; }

        public bool IsEdit { get; set; }

        public AddROC809PointPopup()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textName.Text))
            {
                labelNameError.Text = "Укажите название точки";
                labelNameError.Visible = true;
            }
            else
            {
                labelNameError.Visible = false;
            }

            if (string.IsNullOrEmpty(textDescription.Text))
            {
                labelDescriptionError.Text = "Укажите описание точки";
                labelDescriptionError.Visible = true;
            }
            else
            {
                labelDescriptionError.Visible = false;
            }

            ROC809MeasurePoint existingPoint;
            if (!IsEdit)
            {
                existingPoint = ROCPoints.FirstOrDefault(p => p.Number == (int)numericNumber.Value && p.HistSegment == (int)numericSegment.Value);
            }
            else
            {
                existingPoint = ROCPoints.FirstOrDefault(p => (p.Number == (int)numericNumber.Value & p.HistSegment == (int)numericSegment.Value) && (p.Number != ROCPoint.Number & p.HistSegment != ROCPoint.HistSegment));
            }

            if (existingPoint != null)
            {
                labelNumberError.Text = "Точка уже существует";
                labelNumberError.Visible = true;
            }
            else
            {
                labelNumberError.Visible = false;
            }

            if (!labelNameError.Visible && !labelDescriptionError.Visible && !labelNumberError.Visible)
            {
                if (!IsEdit)
                {
                    ROCPoint = new ROC809MeasurePoint();
                }

                ROCPoint.Number = (int)numericNumber.Value;
                ROCPoint.Name = textName.Text;
                ROCPoint.Description = textDescription.Text;
                ROCPoint.HistSegment = (int)numericSegment.Value;

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void AddROC809PointPopup_Load(object sender, EventArgs e)
        {
            Text = IsEdit ? "Изменение точки измерения" : "Добавление точки измерения";

            if (IsEdit)
            {
                numericNumber.Value = ROCPoint.Number;
                numericSegment.Value = ROCPoint.HistSegment;
                textName.Text = ROCPoint.Name;
                textDescription.Text = ROCPoint.Description;
            }
        }
    }
}
