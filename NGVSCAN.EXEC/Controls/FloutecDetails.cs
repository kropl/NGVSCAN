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
    public partial class FloutecDetails : UserControl
    {
        public Floutec Floutec { get; set; }

        public FloutecDetails()
        {
            InitializeComponent();
        }

        private void FloutecDetails_Load(object sender, EventArgs e)
        {
            labelAddress.Text = Floutec.Address.ToString();
            labelName.Text = Floutec.Name;
            labelDescription.Text = Floutec.Description;
        }
    }
}
