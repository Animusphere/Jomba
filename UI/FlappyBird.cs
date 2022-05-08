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
    public partial class FlappyBird : Form 
    {
        FlappyControl flappyControl = new FlappyControl();
        public FlappyBird()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            Player.Top += flappyControl.Gravity;
            PipeTop.Left -= flappyControl.PipeSpeed;
            PipeBottom.Left -= flappyControl.PipeSpeed;
            flappyControl.ResetPipePos(PipeBottom);
            flappyControl.ResetPipePos(PipeTop);
            ScoreLabel.Text = "Score : "+ flappyControl.Score;
            if (Player.Bounds.IntersectsWith(PipeTop.Bounds)||
                Player.Bounds.IntersectsWith(PipeBottom.Bounds)
                ||Player.Bounds.IntersectsWith(Ground.Bounds))
            {
                flappyControl.EndGame(GameOverLabel, GameTimer);
            }
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            flappyControl.FlappyDown(e);
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            flappyControl.FlappyUp(e);
        }
    }
}
