using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace G5_Minesweeper
{
    public class PowerUp : Board // Executes powerups that help the player during the game - Luke Shaffer
    {
        public PowerUp(int rowW, int colH, int totalMines) //constructor - Luke Shaffer
        {
            RWidth = rowW;
            CHeight = colH;
            TotalMines = totalMines;
        }

        public void FogOfWar()// powerup: flags two random unflagged mines on the board - Luke Shaffer 
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
