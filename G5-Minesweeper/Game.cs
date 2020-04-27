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
        private bool MessageBoxShow;
        public Game()
        {
            InitializeComponent();

        }

        private void Game_Load(object sender, EventArgs e)
        {
            FirstClick = false;
            MessageBoxShow = false;
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
            int count = 0;
            foreach (var square in firstClick)
            {
                count++;
                if (count == 1)
                {
                    FirstClick = true;
                }
            }
            firstClick.ToList();
            for (int i = 0; i < Squares.Count; i++)
            {
                if (Squares[i].IsClicked == true && Squares[i].IsMine == true)
                {
                    var gameOver = MessageBox.Show("Game over :(", "Click OK to Exit", MessageBoxButtons.OK);
                    MessageBoxShow = false;
                    if (gameOver == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBoxShow = false;
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
                            }
                        }
                    }

                }
            }


        }


    }
}
