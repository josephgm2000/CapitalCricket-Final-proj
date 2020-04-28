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
        private static Random reshuffle = new Random();
        public Square()
        {
            IsMine = false;
            IsClicked = false;
            IsRevealed = false;
            IsFlagged = false;
            Top = 0;
            Left = 0;
            Image = Properties.Resources.square;
            Size = new System.Drawing.Size(20, 20);
            SizeMode = PictureBoxSizeMode.StretchImage;
            InitializeComponent();
        }

        public void SetMine()
        {
            double rnd = reshuffle.NextDouble();
            if (rnd <= .30)
            {
                IsMine = true;

            }

        }
        public void SetImage()
        {
            if (IsRevealed == true)
            {
                if (IsMine == true)
                {

                    Image = Properties.Resources.bomb;

                }
                else if (IsMine == false)
                {

                    if (AdjacentMines == 1)
                    {
                        Image = Properties.Resources.one;
                        this.Refresh();
                    }
                    else if (AdjacentMines == 2)
                    {
                        Image = Properties.Resources.two;
                        this.Refresh();
                    }
                    else if (AdjacentMines == 3)
                    {
                        Image = Properties.Resources.three;
                        this.Refresh();
                    }
                    else if (AdjacentMines == 4)
                    {
                        Image = Properties.Resources.four;
                        this.Refresh();
                    }
                    else if (AdjacentMines == 5)
                    {
                        Image = Properties.Resources._5;
                        this.Refresh();
                    }
                    else if (AdjacentMines == 6)
                    {
                        Image = Properties.Resources.six;
                        this.Refresh();
                    }
                    else if (AdjacentMines == 7)
                    {
                        Image = Properties.Resources.seven;
                        this.Refresh();
                    }
                    else if (AdjacentMines == 8)
                    {
                        Image = Properties.Resources.eight;
                        this.Refresh();
                    }
                    else if (AdjacentMines == 0)
                    {
                        Image = Properties.Resources.blank;
                        this.Refresh();
                    }
                }
            }

            if (IsFlagged)
            {
                Image = Properties.Resources.flag;
                this.Refresh();
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
                IsClicked = true;
                IsRevealed = true;
                SetImage();
            }
            if (e.Button == MouseButtons.Right)
            {
                if (IsFlagged == false)
                {
                    IsFlagged = true;
                    IsClicked = true;
                    IsRevealed = false;
                    Image = Properties.Resources.flag;
                    this.Refresh();
                }
                else
                {
                    IsFlagged = false;
                    IsClicked = false;
                    IsRevealed = false;
                    Image = Properties.Resources.square;
                    this.Refresh();
                }

            }

        }
    }
}
