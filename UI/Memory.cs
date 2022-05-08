using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jomba.Control;
using Jomba.UI;

namespace Jomba.UI
{
    public partial class Memory : Form
    {
        MemoryControl memoryControl = new MemoryControl();
        int time;
        public Memory()
        {
            InitializeComponent();
            memoryControl.Table = MemorySet;
            memoryControl.AssignImagetoBox();
            time = 0;
        }

        private void label_click(object sender, EventArgs e)
        {
            memoryControl.LabelClicked(sender);
            if(memoryControl.secondClick!=null) memorizeTimer.Start();
            if (memoryControl.finalScore != 0)
            {  
                DialogResult Di = MessageBox.Show("WIN\nScore : " 
                    + memoryControl.finalScore+"\nTime : "+time+"\nRestrat?",
                    "WINNER",MessageBoxButtons.YesNo);
                if (Di == DialogResult.No)
                {
                    Main f1 = new Main();
                    f1.Show();
                }
            }
        }

        private void tick_event(object sender, EventArgs e)
        {
            memorizeTimer.Stop();
            memoryControl.MemorizeTimeOut();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            memoryControl.Divider++;
            time++;
        }
    }
}
