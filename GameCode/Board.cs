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

        public int TotalMines
        {
            get
            {
                return 20;
            }
        }

        

        public int Base // set difficulty here 
        {
            get { return 7; }

        }


        

        public int Height // set difficulty here 
        {
            get { return 7; }

        }


        public Board()
        {
            BoardSquares = new Square[Base, Height];
            for (int i = 0; i < Base; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    BoardSquares[i, j] = new Square(Base, Height, TotalMines);
                }
                
            }
            AdjacentMines();

        }

        public void AdjacentMines() // Method to display the numbers on the squares surrounding mines 
        {

            for (int i = 0; i < Base; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (BoardSquares[i, j].IsMine == false)
                    {
                        if (BoardSquares[i + 1, j + 1].IsMine == true)//top right
                        {
                            BoardSquares[i, j].AdjacentMines++;
                        }
                        else if (BoardSquares[i + 1, j - 1].IsMine == true)//bottom right
                        {
                            BoardSquares[i, j].AdjacentMines++;
                        }
                        else if (BoardSquares[i, j + 1].IsMine == true)//top
                        {
                            BoardSquares[i, j].AdjacentMines++;
                        }
                        else if (BoardSquares[i, j - 1].IsMine == true)//bottom
                        {
                            BoardSquares[i, j].AdjacentMines++;
                        }
                        else if (BoardSquares[i + 1, j].IsMine == true)//right
                        {
                            BoardSquares[i, j].AdjacentMines++;
                        }
                        else if (BoardSquares[i - 1, j].IsMine == true)//left
                        {
                            BoardSquares[i, j].AdjacentMines++;
                        }
                        else if (BoardSquares[i - 1, j - 1].IsMine == true)//bottom left
                        {
                            BoardSquares[i, j].AdjacentMines++;
                        }
                        else if (BoardSquares[i + 1, j - 1].IsMine == true)//top left
                        {
                            BoardSquares[i, j].AdjacentMines++;
                        }
                    }
                }
                
            }


        }
        public void DisplayBoard()
        {
            for (int i = 0; i < BoardSquares.GetLength(0); i++)
            {
                for (int j = 0; j < BoardSquares.GetLength(1); j++)
                {
                    Console.WriteLine($"{BoardSquares[i, j].SquareVal}");
                }
            }
            Console.WriteLine();
        }



    }
}
