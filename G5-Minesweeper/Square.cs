using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G5_Minesweeper
{
    public class Square : PictureBox
    {
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsClicked { get; set; }
        public int AdjacentMines { get; set; }

        public string SquareVal { get; set; }
        private static Random reshuffle = new Random();
        public Square(int param)
        {
            IsMine = false;
            IsClicked = false;
            IsRevealed = false;
            Image = Properties.Resources.square;
            Size = new System.Drawing.Size(20, 20);
            SizeMode = PictureBoxSizeMode.StretchImage; 
        }
        public Square()
        {
            Square square = new Square(5);
            Controls.Add(square);
        }
        public void SetMine()
        {
            double rnd = reshuffle.NextDouble();
            if (rnd <= .30)
            {
                IsMine = true;
                SquareVal = "*";
            }

        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Square
            // 
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Square_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void Square_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(IsMine == true)
                {
                    Image = Properties.Resources.bomb;
                    IsClicked = true;
                    IsRevealed = true;
                }
                else
                {
                    IsRevealed = true;
                    if(AdjacentMines == 1)
                    {
                        Image = Properties.Resources.one;
                    }
                    else if(AdjacentMines == 2)
                    {
                        Image = Properties.Resources.two;
                    }
                    else if(AdjacentMines == 3)
                    {
                        Image = Properties.Resources.three;
                    }
                    else if(AdjacentMines == 4)
                    {
                        Image = Properties.Resources.four;
                    }
                    else if(AdjacentMines == 5)
                    {
                        Image = Properties.Resources._5;
                    }
                    else if (AdjacentMines == 6)
                    {
                        Image = Properties.Resources.six;
                    }
                    else if(AdjacentMines == 7)
                    {
                        Image = Properties.Resources.seven;
                    }
                    else if(AdjacentMines == 8)
                    {
                        Image = Properties.Resources.eight;
                    }
                    else if(AdjacentMines == 0)
                    {
                        Image = Properties.Resources.blank;
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                Image = Properties.Resources.flag;
                IsClicked = true;
                IsFlagged = true;
            }
        }

        

    }
}
