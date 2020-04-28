using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace G5_Minesweeper
{
    public enum Difficulty
    {
        Easy = 0, Medium = 1, Hard = 2
    }

    public class Board
    {
        public Square[,] BoardSquares { get; set; }

        private int totalMines = 30;
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



        public int RWidth // set difficulty here 
        {
            get { return 10; }

        }




        public int CHeight // set difficulty here 
        {
            get { return 10; }

        }


        public Board()
        {
            BoardSquares = new Square[RWidth, CHeight];

            for (int i = 0; i < RWidth; i++)
            {
                for (int j = 0; j < CHeight; j++)
                {

                    BoardSquares[i, j] = new Square();
                    if (!(j == 0))
                    {
                        BoardSquares[i, j].Left = BoardSquares[i, j - 1].Left + 20;
                    }
                    if(!(i == 0))
                    {
                        BoardSquares[i, j].Top = BoardSquares[i - 1, j].Top + 20;
                    }
                   
                    

                }

            }
            int count = 0;
            for (int i = 0; i < CHeight; i++)
            {
                for (int j = 0; j < RWidth; j++)
                {
                    BoardSquares[i, j].SetMine();
                    if (count < TotalMines)
                    {
                        if (BoardSquares[i, j].IsMine == false)
                        {
                            BoardSquares[i, j].SetMine();
                            if (BoardSquares[i,j].IsMine == true)
                            {
                                count++;
                            }
                           

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
                    if (i >= 0 && j >= 0 && i < CHeight && j < RWidth && !(i == row && j == col))
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
            for (int i = 0; i < CHeight; i++)
            {
                for (int j = 0; j < RWidth; j++)
                {
                    if (BoardSquares[i, j].IsMine == false)
                    {
                        BoardSquares[i, j].AdjacentMines = CalculateAdjacentMines(i, j);  
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
                    if (i >= 0 && j >= 0 && i < CHeight && j < RWidth)
                    {
                        if (BoardSquares[i, j].IsMine)
                        {
                            BoardSquares[i, j].IsMine = false;
                            count++;
                            BoardSquares[i, j].IsRevealed = true;
                            BoardSquares[i, j].SetImage();
                        }
                    }
                }
            }

            for (int i = 0; i < CHeight; i++)
            {
                for (int j = 0; j < RWidth; j++)
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
    }
}















