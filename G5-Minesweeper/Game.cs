using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if(beginGame == DialogResult.OK)
            {
                GameTimer.Enabled = true;
            }



        }

        private void Game_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (e.Equals(MouseButtons.Left))
            {
                count++;
                if (count == 1)
                {
                    FirstClick = true;
                }
            }   
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            var firstClick = from square in Squares
                             where square.IsClicked == true
                             select square;
            firstClick.ToList();
            
            for (int i = 0; i < Board.CHeight; i++)
            {
                for (int j = 0; j < Board.RWidth; j++)
                {
                    if (FirstClick)
                    {
                        foreach (var square in firstClick)
                        {
                            if(Board.BoardSquares[i,j].Top == square.Top && Board.BoardSquares[i,j].Left == square.Left)
                            {
                                Board.FirstClick(j, i);
                            }
                        }
                    }

                }
            }
            foreach(var square in Squares)
            {
                if (square.IsClicked == true && square.IsMine == true)
                {
                    var gameOver = MessageBox.Show("Game over :(", "To Play Again click Yes, To close the game click No", MessageBoxButtons.YesNo);
                    if(gameOver == DialogResult.Yes)
                    {
                        for (int i = 0; i < Board.CHeight; i++)
                        {
                            for (int j = 0; j < Board.RWidth; j++)
                            {
                                Controls.Remove(Board.BoardSquares[i, j]);
                                Squares.Remove(Board.BoardSquares[i, j]);

                            }
                        } 
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
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }

        }
    }
}
