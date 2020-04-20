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

        private int totalMines;
        public int TotalMines
        {
            get
            {
                return totalMines;
            }
            set
            {
                totalMines = value;
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
            int count = 0;
            for (int i = 0; i < Base; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    BoardSquares[i, j] = new Square(Base, Height);
                    if (BoardSquares[i,j].IsMine == true)
                    {
                        count++;
                        if (count > TotalMines)
                        {
                            BoardSquares[i, j].IsMine = false;
                        }
                    }
                }

            }

        }

        public void AdjacentMines() // Method to display the numbers on the squares surrounding mines 
        {

            for (int i = 0; i < Base; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (BoardSquares[i, j].IsMine == false)
                    {
                        if (!(i == Base - 1 || j == Height - 1))//top right
                        {
                            if (BoardSquares[i + 1, j + 1].IsMine == true)
                            {
                                BoardSquares[i, j].AdjacentMines++;
                            }
                        }
                        else if (!(j == 0 || i == Base - 1))//bottom right
                        {
                            if (BoardSquares[i + 1, j - 1].IsMine == true)
                            {
                                BoardSquares[i, j].AdjacentMines++;
                            }
                        }
                        else if (!(j == Height - 1))//top
                        {
                            if (BoardSquares[i, j + 1].IsMine == true)
                            {
                                BoardSquares[i, j].AdjacentMines++;
                            }
                        }
                        else if (!(j == 0))//bottom
                        {
                            if (BoardSquares[i, j - 1].IsMine == true)
                            {
                                BoardSquares[i, j].AdjacentMines++;
                            }
                        }
                        else if (!(i == Base - 1))//right
                        {
                            if (BoardSquares[i + 1, j].IsMine == true)
                            {
                                BoardSquares[i, j].AdjacentMines++;
                            }
                        }
                        else if (!(i == 0))//left
                        {
                            if (BoardSquares[i - 1, j].IsMine == true)
                            {
                                BoardSquares[i, j].AdjacentMines++;
                            }
                        }
                        else if (!(i == 0 || j == 0))//bottom left
                        {
                            if (BoardSquares[i - 1, j - 1].IsMine == true)
                            {
                                BoardSquares[i, j].AdjacentMines++;
                            }
                        }
                        else if (!(i == Base - 1 || j == 0))//top left
                        {
                            if (BoardSquares[i + 1, j - 1].IsMine == true)
                            {
                                BoardSquares[i, j].AdjacentMines++;
                            }
                        }
                        BoardSquares[i, j].SquareVal = Convert.ToString(BoardSquares[i, j].AdjacentMines);
                    }
                }

            }


        }
        public void DisplayBoard()
        {
            for (int i = 0; i < Base; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Console.Write($"{BoardSquares[i, j].SquareVal}");
                }
                Console.WriteLine();
            }

        }



    }
}
