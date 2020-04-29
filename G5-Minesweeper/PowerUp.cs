using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace G5_Minesweeper
{
    public class PowerUp : Board
    {

        public PowerUp()
        {

        }
        public void GoldenDome(int row, int col)
        {
            BoardSquares[row, col].IsMine = false;
            TotalMines--;
        }
        public void FogOfWar(int x1, int y1, int x2, int y2)
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 0; i < CHeight; i++)
            {
                for (int j = 0; j < RWidth; j++)
                {
                    if (BoardSquares[j, i].IsMine)
                    {
                        rows.Add(j);
                        columns.Add(i);
                    }
                }
            }

            int count = 2;
            foreach (var r in rows)
            {
                foreach (var c in columns)
                {
                    if (count > 0)
                    {
                        BoardSquares[r, c].IsFlagged = true;
                        BoardSquares[r, c].SetImage();
                        count--;
                    }
                }
            }
            

        }
    }
}
