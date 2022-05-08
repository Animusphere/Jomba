using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jomba.Control
{
    class FlappyControl
    {
        public int PipeSpeed = 8;
        public int Gravity = 10;
        public int Score = 0;

        public FlappyControl() { }
        public void FlappyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Gravity = 10;
            }
        }
        public void FlappyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Gravity = -10;
            }
        }
        public void ResetPipePos(PictureBox Pipe)
        {
            if (Pipe.Left<-55)
            {
                Pipe.Left = 379;
                Score++;
            }
        }
        public void EndGame(Label label, Timer timer)
        {
            timer.Stop();
            label.Visible = true;
        }
    }
}
