using System;
using System.Windows.Forms;
using NGVSCAN.CORE.Entities.Floutecs;

namespace NGVSCAN.EXEC.Controls
{
    public partial class FloutecLineDetails : UserControl
    {
        public FloutecMeasureLine FloutecLine { get; set; }

        public FloutecLineDetails()
        {
            InitializeComponent();
        }

        private void FloutecLineDetails_Load(object sender, EventArgs e)
        {
            labelField.Text = FloutecLine.Estimator.Field.Name + " " + FloutecLine.Estimator.Field.Description;

            labelEstimator.Text = ((Floutec)FloutecLine.Estimator).Address + " " + ((Floutec)FloutecLine.Estimator).Name;

            labelNumber.Text = FloutecLine.Number.ToString();

            labelName.Text = FloutecLine.Name;

            labelDescription.Text = FloutecLine.Description;

            labelCreated.Text = FloutecLine.DateCreated.ToString("dd.MM.yyyy HH:mm:ss");

            labelModified.Text = FloutecLine.DateModified.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}
