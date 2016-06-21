using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Controls
{
    public partial class LogListView : System.Windows.Forms.ListView
    {
        public LogListView()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
    }
}
