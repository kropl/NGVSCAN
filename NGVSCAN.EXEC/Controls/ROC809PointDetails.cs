using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGVSCAN.CORE.Entities.ROC809s;

namespace NGVSCAN.EXEC.Controls
{
    public partial class ROC809PointDetails : UserControl
    {
        public ROC809MeasurePoint ROCPoint { get; set; }

        public ROC809PointDetails()
        {
            InitializeComponent();
        }

        private void ROC809PointDetails_Load(object sender, EventArgs e)
        {
            labelField.Text = ROCPoint.Estimator.Field.Name + " " + ROCPoint.Estimator.Field.Description;
            labelEstimator.Text = ((ROC809)ROCPoint.Estimator).Address + " " + ((ROC809)ROCPoint.Estimator).Name;
            labelName.Text = ROCPoint.Name;
            labelDescription.Text = ROCPoint.Description;
            labelNumber.Text = ROCPoint.Number.ToString();
            labelHistSegment.Text = ROCPoint.HistSegment.ToString();
            labelCreated.Text = ROCPoint.DateCreated.ToString("dd.MM.yyyy HH:mm:ss");
            labelModified.Text = ROCPoint.DateModified.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}
