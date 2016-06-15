using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NGVSCAN.CORE.Entities.ROC809s;

namespace NGVSCAN.EXEC.Controls
{
    public partial class ROC809Details : UserControl
    {
        public ROC809 ROC { get; set; }

        public ROC809Details()
        {
            InitializeComponent();
        }

        private void ROC809Details_Load(object sender, EventArgs e)
        {
            labelField.Text = ROC.Field.Name + " " + ROC.Field.Description;
            labelName.Text = ROC.Name;
            labelDescription.Text = ROC.Description;
            labelAddress.Text = ROC.Address;
            labelPort.Text = ROC.Port.ToString();
            labelROCGroup.Text = ROC.ROCGroup.ToString();
            labelROCUnit.Text = ROC.ROCUnit.ToString();
            labelHostGroup.Text = ROC.HostGroup.ToString();
            labelHostUnit.Text = ROC.HostUnit.ToString();
            labelCreated.Text = ROC.DateCreated.ToString("dd.MM.yyyy HH:mm:ss");
            labelModified.Text = ROC.DateModified.ToString("dd.MM.yyyy HH:mm:ss");
            labelPoints.Text = "";

            if (ROC.MeasureLines.Any())
            {
                labelPoints.Text = "Точки:";

                foreach (var segment in ROC.MeasureLines.Select(p => p as ROC809MeasurePoint).OrderBy(o => o.HistSegment).Select(s => s.HistSegment).Distinct())
                {
                    ListViewGroup group = listPoints.Groups.Add(segment.ToString(), "Исторический сегмент №" + segment);

                    foreach (ROC809MeasurePoint point in ROC.MeasureLines.Select(p => p as ROC809MeasurePoint).Where(p => p.HistSegment == segment).OrderBy(o => o.Number))
                    {
                        ListViewItem item = new ListViewItem(new[]
                        {
                            point.Number.ToString(),
                            point.Name,
                            point.Description
                        }, group);
                        
                        item.Font = point.IsDeleted ? new Font(new FontFamily("Microsoft Sans Serif"), 8, FontStyle.Strikeout) : null;

                        listPoints.Items.Add(item);
                    }

                }

                listPoints.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                listPoints.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                listPoints.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);

                listPoints.Visible = true;
            }
            else
            {
                labelPoints.Text = "Точки отсутствуют";
                listPoints.Visible = false;
            }
        }
    }
}
