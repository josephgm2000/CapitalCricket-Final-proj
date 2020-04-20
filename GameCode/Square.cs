using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCode
{
    public class Square
    {
        //public List<int> XLocations { get; set; }
        //public List<int> YLocations { get; set; }
        public int RowX { get; set; }
        public int ColumnY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsClicked { get; set; }
        public int AdjacentMines { get; set; }

        public string SquareVal { get; set; }
        private static Random reshuffle = new Random();
        public Square(int sizeX, int SizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = SizeY;
            IsMine = true;
            
            

        }
        public void CreateMines()
        {
            if (IsMine == true)
            {
                SquareVal = "*";
            }
        }
        public void SetLocations()
        {
            //int randomX = randomLocationX.Next(1, (SizeX + 1));
            //int randomY = randomLocationY.Next(1, (SizeY + 1));
            //XLocations.Add(randomX);
            //YLocations.Add(randomY);
            //RowX = randomX;
            //ColumnY = randomY;
            //var duplicates = from value in XLocations
            //                 select value;
            //int countTwins = 0;
            //foreach (var value in duplicates)
            //{
            //    for (int i = 0; i < XLocations.Count; i++)
            //    {
            //        if (XLocations[i] == value && YLocations[i] == value)
            //        {
            //            countTwins++;
            //            if(countTwins == 2)
            //            {
            //                XLocations[i] = reshuffle.Next(1, SizeX + 1);
            //                YLocations[i] = reshuffle.Next(1, SizeX + 1);
            //                RowX = XLocations[i];
            //                ColumnY = YLocations[i];
            //                countTwins = 0;
            //            }
            //        }
            //    }
            //}
            int countPlacesX = 0;
            int countPlacesY = 0;
            if (countPlacesX < SizeX && countPlacesY < SizeY)
            {
                RowX = countPlacesX;
                countPlacesX++;
                ColumnY = countPlacesY;
                countPlacesY++;
            }

        }

    }
}
