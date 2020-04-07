using System;
using System.Collections.Generic;
using System.Text;

namespace GameCode
{
    public enum Difficulty
    {
        Easy, Medium, Hard
    }


    class Board
    {
        private int basE;
        private int height;
        private int totalmines;

        public Square BoardSquares { get; set; }

        public int TotalMines { get; set; }

        public int Base { get; set; }

        public int Height { get; set; }

        public string Difficulty;


        public Board()
        {

        }
           
        public int AdjacentMines() // Method to display the numbers on the squares surrounding mines 
        {
            return 0;
        }




    }
}
