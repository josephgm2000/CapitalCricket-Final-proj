using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace G5_Minesweeper
{
    public partial class Game : Form
    {
        private List<Square> Squares = new List<Square>();
        private PowerUp PowerUps = new PowerUp();
        private Board Board;
        private bool FirstClick = false;
        
        public Game()
        {
            InitializeComponent();

        }

        private void Game_Load(object sender, EventArgs e)
        {
            FirstClick = false;
            Board = new Board();
            Board.AdjacentMines();
            for (int i = 0; i < Board.CHeight; i++)
            {
                for (int j = 0; j < Board.RWidth; j++)
                {
                    Controls.Add(Board.BoardSquares[i, j]);
                    Squares.Add(Board.BoardSquares[i, j]);
                }
            }
            var beginGame = MessageBox.Show("Welcome to Minesweeper!", "Click OK to begin playing", MessageBoxButtons.OK);
            if (beginGame == DialogResult.OK)
            {
                GameTimer.Enabled = true;
            }
        }



        private void GameTimer_Tick(object sender, EventArgs e)
        {
            var firstClick = from square in Squares
                             where square.IsClicked == true
                             select square;
            var winGame = from square in Squares
                          where square.IsRevealed == true
                          select square;
            var minesFlagged = from square in Squares
                               where square.IsFlagged == true && square.IsMine == true
                               select square;
            minesFlagged.ToList();
            winGame.ToList();
            if (winGame.Count() == ((Board.CHeight * Board.RWidth) - Board.TotalMines) && minesFlagged.Count() == Board.TotalMines)
            {
                GameTimer.Enabled = false;
                var gameWon = MessageBox.Show("You Won! :)", "Press OK to Exit", MessageBoxButtons.OK);
                if (gameWon == DialogResult.OK)
                {
                    this.Close();
                }
            }
            int clickCount = 0;
            foreach (var square in firstClick)
            {
                clickCount++;
                if (clickCount == 1)
                {
                    FirstClick = true;
                }
                else
                {
                    FirstClick = false;
                }
            }


            for (int i = 0; i < Board.CHeight; i++)
            {
                for (int j = 0; j < Board.RWidth; j++)
                {
                    if (FirstClick)
                    {
                        foreach (var square in firstClick)
                        {
                            if (Board.BoardSquares[i, j].Top == square.Top && Board.BoardSquares[i, j].Left == square.Left)
                            {
                                Board.FirstClick(j, i);
                                Board.AdjacentMines();
                                Board.BoardSquares[i, j].Refresh();
                            }
                        }
                    }

                }
            }


        }


    }
}
