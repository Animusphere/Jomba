using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Jomba.Control
{
    class MemoryControl
    {
        Random random = new Random();
        List<string> image = new List<string>()
        {
            "a","a","b","b",
            "x","x","d","d"
            ,"e","e","f","f"
            ,"g","g","h","h"
        };
        
        public Label firstClick, secondClick;

        public float finalScore = 0;

        int count = 0;

        int divider = 1;
        int MaxScore = 1000;
        
        TableLayoutPanel table;
        public MemoryControl() { }
        public TableLayoutPanel Table { get => table; set => table = value; }
        public int Divider { get => divider; set => divider = value; }

        
        public void AssignImagetoBox()
        {
            Label label;
            int randomNumber;
            for(int i = 0; i < Table.Controls.Count; i++)
            {
                if (Table.Controls[i] is Label)
                    label = (Label)Table.Controls[i];
                else
                    continue;
                randomNumber = random.Next(0, image.Count);
                label.Text = image[randomNumber];
                image.RemoveAt(randomNumber);
            }
        }
        public void LabelClicked(object obj)
        {
            Label clickedLabel = obj as Label;
            
            if (clickedLabel == null) return;
            
            if (clickedLabel.ForeColor == Color.Black) return;
            
            if (firstClick != null && secondClick != null) return;

            if (firstClick == null)
            {
                firstClick = clickedLabel;
                firstClick.ForeColor = Color.Black;
                return;
            }
            secondClick = clickedLabel;
            secondClick.ForeColor = Color.Black;
            if (firstClick.Text == secondClick.Text)
            {
                firstClick = null;
                secondClick = null;
                count++;
            }
            if (count == Table.Controls.Count / 2) CheckFinalScore();
        }
        public void MemorizeTimeOut()
        {
            firstClick.ForeColor = firstClick.BackColor;
            secondClick.ForeColor = secondClick.BackColor;
            firstClick = secondClick = null;
        }
        public void CheckFinalScore()
        {
            finalScore = MaxScore * 10 / divider;
        }
    }
}
