using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace G5_Minesweeper
{
    public enum Difficulty
    {
        Easy = 0, Medium = 1, Hard = 2
    }

    public class Board 
    {
        public Square[,] BoardSquares { get; set; }

        private int totalMines = 20;
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
            for (int i = 0; i < Base; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    BoardSquares[i, j] = new Square
                    {
                        Top = i,
                        Left = j
                    };
                    
                }

            }
            int count = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Base; j++)
                {
                    BoardSquares[i, j].SetMine();
                    if (count < TotalMines)
                    {
                        if (BoardSquares[i, j].IsMine == true)
                        {
                            count++;

                        }
                    }
                }
            }

        }


        private int CalculateAdjacentMines(int row, int col)
        {
            int mines = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < Height && j < Base && !(i == row && j == col))
                    {
                        if (BoardSquares[i, j].IsMine)
                        {
                            mines++;
                        }
                    }
                }
            }
            return mines;
        }

        public void AdjacentMines() // Method to display the numbers on the squares surrounding mines 
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Base; j++)
                {
                    if (BoardSquares[i, j].IsMine == false)
                    {
                        BoardSquares[i, j].AdjacentMines = CalculateAdjacentMines(i, j);

                        BoardSquares[i, j].SquareVal = Convert.ToString(BoardSquares[i, j].AdjacentMines);
                    }
                }
            }
        }

        public void FirstClick(int row, int col)
        {
            int count = 0;
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < Height && j < Base)
                    {
                        if (BoardSquares[i, j].IsMine)
                        {
                            BoardSquares[i, j].IsMine = false;
                            count++;
                        }
                    }
                }
            }

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Base; j++)
                {
                    if (BoardSquares[i, j].IsMine == false)
                    {
                        rows.Add(j);
                        columns.Add(i);
                    }
                }
            }
            foreach (var r in rows)
            {
                foreach (var c in columns)
                {
                    if (count > 0)
                    {
                        BoardSquares[r, c].IsMine = true;
                        count--;
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
                    BoardSquares[i, j].Show();
                }
            }
        }

    }
}















