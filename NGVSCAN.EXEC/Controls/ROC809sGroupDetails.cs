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
    public partial class ROC809sGroupDetails : UserControl
    {
        public List<ROC809> ROCs { get; set; }

        public ROC809sGroupDetails()
        {
            InitializeComponent();
        }

        private void ROC809sGroupDetails_Load(object sender, EventArgs e)
        {
            if (ROCs.Any())
            {
                labelRocs.Text = "Вычислители:";

                foreach (ROC809 roc in ROCs)
                {
                    ListViewItem item = new ListViewItem(new[]
                    {
                        roc.Address,
                        roc.Name,
                        roc.Description
                    });
                    listRocs.Items.Add(item);
                }

                listRocs.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                listRocs.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                listRocs.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);

                listRocs.Visible = true;
            }
            else
            {
                labelRocs.Text = "Вычислители отсутствуют";
                listRocs.Visible = false;
            }
        }
    }
}
