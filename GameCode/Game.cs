using System;
using System.Collections.Generic;
using System.Text;

namespace GameCode
{
    class Game
    {
        //private bool IsGameOver = false;
        public Game()
        {

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
