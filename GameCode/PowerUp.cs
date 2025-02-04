﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GameCode
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
        public void FogOfWar()
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Base; j++)
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
                        count--;
                    }
                }
            }

        }
    }
}
