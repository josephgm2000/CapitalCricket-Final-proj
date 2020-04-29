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
    public partial class Game : Form //Minesweeper game form - Joseph Mattackal
    {
        private List<Square> Squares = new List<Square>();
        private PowerUp PowerUps;
        private Board Board;
        private bool FirstClick = false;
        private int score;
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
            for (int i = 0; i < Board.CHeight; i++) // creates the values in the board - Joseph Mattackal
            {
                for (int j = 0; j < Board.RWidth; j++)
                {
                    Controls.Add(Board.BoardSquares[i, j]);
                    Squares.Add(Board.BoardSquares[i, j]);
                }
            }
            PowerUps = new PowerUp(Board.RWidth, Board.CHeight, Board.TotalMines)
            {
                BoardSquares = new Square[Board.RWidth, Board.CHeight]
            };
            for (int i = 0; i < Board.CHeight; i++) // copys the board values and puts them in the powerups board array - Joseph Mattackal
            {
                for (int j = 0; j < Board.RWidth; j++)
                {
                    PowerUps.BoardSquares[i, j] = Board.BoardSquares[i, j];
                }
            }
            var rules = MessageBox.Show("1.The first set of squares that you click may lie to you about bombs in their area, click on them to reveal thier true nature. 2.Your mission is to flag every mine on the board, do this by right clicking. 3.After you flag a certain amount of mines your powerUp will activate. Have fun! ", "Before you begin here is some info for you", MessageBoxButtons.OK);
            var beginGame = MessageBox.Show("Welcome to Minesweeper!", "Click OK to begin playing", MessageBoxButtons.OK);
            var startUp = new SoundPlayer(Properties.Resources.smb3_enter_level); // plays sound on startup
            startUp.Play();
            if (beginGame == DialogResult.OK)
            {
                GameTimer.Enabled = true;
                RealTime.Text = Convert.ToString(Board.TimeLeft);
                PlayTimer.Enabled = true;
            }
        }



        private void GameTimer_Tick(object sender, EventArgs e) // Game : Game Timer - Wilson Daghfal 
        {
            var firstClick = from square in Squares
                             where square.IsClicked == true
                             select square;
            var gameOver = from square in Squares // finds out if a bomb has been clicked - Joseph Mattackal
                           where square.IsClicked && square.IsMine && square.IsRevealed
                           select square;
            var mines = from square in Squares //finds all the bombs in the bord - Joseph Mattackal
                        where square.IsMine
                        select square;
            var minesFlagged = from square in Squares // finds all the flagged mines in the board - Wilson Daghfal
                               where square.IsFlagged == true && square.IsMine == true
                               select square;

            var clickedSquares = from square in Squares // finds all the clicked squares in the board - Wilson Daghfal 
                                 where square.IsRevealed == true
                                 select square;

            RenderOutput();
            clickedSquares.ToList();
            minesFlagged.ToList();
            score = minesFlagged.Count();
            mines.ToList();
            WinGame = (Board.CHeight * Board.RWidth) - mines.Count();
            if (score == 8 && Board.RWidth == 7 || score == 18 && Board.RWidth == 9 || score == 35 && Board.RWidth == 11) // gives conditions for the execution of the power up -  Joseph Mattackal
            {
                GameTimer.Interval = 15000;
                var mushroom = new SoundPlayer(Properties.Resources.nsmb_power_up);//plays sound when a powerup is executed
                mushroom.Play();
                var fogOfWar = MessageBox.Show("Press OK to Activate your Power Up", "You have gained the Fog Of War Power Up", MessageBoxButtons.OK);
                if (fogOfWar == DialogResult.OK)
                {
                    GameTimer.Interval = 10;
                    PowerUps.FogOfWar();
                }
            }

            if (score == mines.Count()) // gives condition for execution of the power up - Wilson Daghfal 
            {
                var happyNoises = new SoundPlayer(Properties.Resources.smb3_airship_clear);
                happyNoises.Play();
                GameTimer.Interval = 30000;
                var youWon = MessageBox.Show("You Won! :)", "Click OK to exit the game", MessageBoxButtons.OK);
                if (youWon == DialogResult.OK)
                {
                    this.Close();
                }
            }
            foreach (var square in gameOver)//executes if the player clicks a mine
            {
                foreach (var mine in mines)
                {
                    mine.IsRevealed = true;
                    mine.SetImage();
                }
                var loseSound = new SoundPlayer(Properties.Resources.nsmb_death);
                loseSound.Play();
                GameTimer.Interval = 30000;
                var overBox = MessageBox.Show("Game Over :(", "Click OK to exit the game", MessageBoxButtons.OK);

                if (overBox == DialogResult.OK)
                {

                    this.Close();
                }
            }


            int clickCount = 0;
            foreach (var square in firstClick) // finds out when the player first clicks on the board - Wilson Daghfal 
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


            for (int i = 0; i < Board.CHeight; i++) // nested loop to find the coordinates of the players first click - Wilson Daghfal 
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


        private void RenderOutput() // displays the players current score - Joseph Mattackal
        {
            ScoreLabel.Text = Convert.ToString(score);
        }

        private void PlayTimer_Tick(object sender, EventArgs e) // visible game that counts down every second
        {
            if (Board.TimeLeft > 0)
            {
                Board.TimeLeft -= 1;
                RealTime.Text = Convert.ToString(Board.TimeLeft);
            }
            else
            {
                PlayTimer.Interval = 30000;
                var timesOut = MessageBox.Show("Press OK to exit the game", "Game Over! You ran out of time :(");
                if (timesOut == DialogResult.OK)
                {
                    this.Close();
                }
            }
            if (Board.TimeLeft == 60)
            {
                var hurryUp = MessageBox.Show("Press OK to continue playing", "Hurry Up!, 60 Seconds left!", MessageBoxButtons.OK);
                var hurrySound = new SoundPlayer(Properties.Resources.smb3_hurry_up);
                hurrySound.Play();
            }
            if (GameTimer.Enabled == false)
            {
                PlayTimer.Enabled = false;
            }
            if (GameTimer.Interval == 30000)
            {
                PlayTimer.Enabled = false;
            }

        }

    }
}


