using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGVSCAN.CORE.Entities;

namespace NGVSCAN.EXEC.Controls
{
    public partial class FloutecsGroupDetails : UserControl
    {
        public List<Floutec> Floutecs { get; set; }

        public FloutecsGroupDetails()
        {
            InitializeComponent();
        }

        private void FloutecsGroupDetails_Load(object sender, EventArgs e)
        {
            if (Floutecs.Any())
            {
                labelFloutecs.Text = "Вычислители:";

                foreach (Floutec floutec in Floutecs)
                {
                    ListViewItem item = new ListViewItem(new[] 
                    {
                        floutec.Address.ToString(),
                        floutec.Name,
                        floutec.Description
                    });
                    listFloutecs.Items.Add(item);
                }

                listFloutecs.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                listFloutecs.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                listFloutecs.Columns[2].Width = listFloutecs.Parent.Parent.Width - listFloutecs.Columns[0].Width - listFloutecs.Columns[1].Width;

                listFloutecs.Width = listFloutecs.Parent.Parent.Width;
                listFloutecs.Height = listFloutecs.Parent.Parent.Height - 20;
                listFloutecs.Location = new Point(0, 20);

                listFloutecs.Visible = true;
            }
            else
            {
                labelFloutecs.Text = "Вычислители отсутствуют";
                listFloutecs.Visible = false;
            }
        }
    }
}
