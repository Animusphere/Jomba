using Jomba.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jomba.UI
{
    public partial class TestForm : Form
    {
        MemoryControl control = new MemoryControl();
        public TestForm()
        {
            InitializeComponent();
            control.Table = tableLayoutPanel1;
            control.AssignImagetoBox();
        }

        private void button_Click(object sender, EventArgs e)
        {
            control.LabelClicked(sender);
            if (control.secondClick != null) GameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            GameTimer.Stop();
            control.MemorizeTimeOut();
        }
    }
}
