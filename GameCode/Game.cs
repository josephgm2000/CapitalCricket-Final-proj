using System;
using System.Collections.Generic;
using System.Text;

namespace GameCode
{
    class Game
    {
        private bool IsGameOver = false;
        public double MinesFlagged { get; set; }
        public Game()
        {
            //if is mine is equal to true and minesflagged == .75 on next left click execute GoldenDome();
        }

        public void Run()
        {
            InitializeGame();
        }



        private void InitializeGame()
        {
            Board board = new Board();
            board.AdjacentMines();
            board.DisplayBoard();
 
        }
    }
}
