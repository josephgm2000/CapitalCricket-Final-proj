using System;
using System.Collections.Generic;
using System.Text;

namespace GameCode
{
    public enum Difficulty
    {
        Easy = 0, Medium = 1, Hard = 2
    }


    class Board
    {
        

        public Square[,] BoardSquares { get; set; }

        public int TotalMines { get; set; }

        private int baSe;

        public int Base // set difficulty here 
        {
            get { return baSe; }
            set { baSe = value; }
        }


        private int height;

        public int Height // set difficulty here 
        {
            get { return height; }
            set { height = value; }
        }


        public Board()
        {
            BoardSquares = new Square[Base, Height];
            
        }
           
        public int AdjacentMines() // Method to display the numbers on the squares surrounding mines 
        {
            return 0;
        }




    }
}
