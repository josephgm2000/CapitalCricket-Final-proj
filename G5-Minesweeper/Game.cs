using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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
        private int ClickX;
        private int ClickY;
        private int WinGame;
        
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
            WinGame = (Board.CHeight * Board.RWidth) - Board.TotalMines;
            var beginGame = MessageBox.Show("Welcome to Minesweeper!", "Click OK to begin playing", MessageBoxButtons.OK);
            var startUp = new SoundPlayer(Properties.Resources.song);
            startUp.Play();
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
            var gameOver = from square in Squares
                           where square.IsClicked && square.IsMine && square.IsRevealed
                           select square;
            var mines = from square in Squares
                        where square.IsMine
                        select square;
            var minesFlagged = from square in Squares
                               where square.IsFlagged == true && square.IsMine == true
                               select square;
            var clickedSquares = from square in Squares
                                 where square.IsClicked
                                 select square;
            clickedSquares.ToList();
            minesFlagged.ToList();
            if(clickedSquares.Count() == WinGame && minesFlagged.Count() == Board.TotalMines)
            {
                var youWon = MessageBox.Show("You Won! :)", "Click OK to exit the game", MessageBoxButtons.OK);
                if(youWon == DialogResult.OK)
                {
                    this.Close();
                }
            }
            foreach (var square in gameOver)
            {
                foreach (var mine in mines)
                {
                    mine.IsRevealed = true;
                    mine.SetImage();
                }
                GameTimer.Interval = 30000;
                var overBox = MessageBox.Show("Game Over :(", "Click OK to exit the game", MessageBoxButtons.OK);
                if(overBox == DialogResult.OK)
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
                                if(Board.BoardSquares[i,j].IsMine == true)
                                {
                                    Board.BoardSquares[i, j].IsMine = false;
                                    Board.TotalMines--;
                                    Board.AdjacentMines();
                                    Board.BoardSquares[i, j].SetImage();
                                }
                                Board.FirstClick(j, i);
                                Board.AdjacentMines();
                                Board.BoardSquares[i, j].Refresh();
                            }
                        }
                    }

                }
            }


        }

        private void Game_Click(object sender, EventArgs e)
        {

        }
    }
}
