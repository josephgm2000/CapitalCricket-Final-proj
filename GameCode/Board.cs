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
            AdjacentMines();

        }

        public void AdjacentMines() // Method to display the numbers on the squares surrounding mines 
        {

            for (int i = 0; i < BoardSquares.Length; i++)
            {

                if (BoardSquares[i, i].IsMine == false)
                {
                    if (BoardSquares[i + 1, i + 1].IsMine == true)//top right
                    {
                        BoardSquares[i, i].AdjacentMines++;
                    }
                    else if (BoardSquares[i + 1, i - 1].IsMine == true)//bottom right
                    {
                        BoardSquares[i, i].AdjacentMines++;
                    }
                    else if (BoardSquares[i, i + 1].IsMine == true)//top
                    {
                        BoardSquares[i, i].AdjacentMines++;
                    }
                    else if (BoardSquares[i, i - 1].IsMine == true)//bottom
                    {
                        BoardSquares[i, i].AdjacentMines++;
                    }
                    else if (BoardSquares[i + 1, i].IsMine == true)//right
                    {
                        BoardSquares[i, i].AdjacentMines++;
                    }
                    else if (BoardSquares[i - 1, i].IsMine == true)//left
                    {
                        BoardSquares[i, i].AdjacentMines++;
                    }
                    else if (BoardSquares[i - 1, i - 1].IsMine == true)//bottom left
                    {
                        BoardSquares[i, i].AdjacentMines++;
                    }
                    else if (BoardSquares[i + 1, i - 1].IsMine == true)//top left
                    {
                        BoardSquares[i, i].AdjacentMines++;
                    }
                }
            }


        }




    }
}
