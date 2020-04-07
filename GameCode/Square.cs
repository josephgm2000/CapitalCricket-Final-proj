using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCode
{
    class Square
    {
        public List<int> XLocations { get; set; }
        public List<int> YLocations { get; set; }
        public int RowX { get; set; }
        public int ColumnY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsClicked { get; set; }
        private static Random randomLocationX = new Random();
        private static Random randomLocationY = new Random();
        private static Random reshuffle = new Random();
        public Square(int sizeX, int SizeY, int totalMines)
        {
            this.SizeX = sizeX;
            this.SizeY = SizeY;
        }
        public void CreateMines(int mines)
        {

        }
        public void SetLocations()
        {
            int randomX = randomLocationX.Next(1, (SizeX + 1));
            int randomY = randomLocationY.Next(1, (SizeY + 1));
            XLocations.Add(randomX);
            YLocations.Add(randomY);
            RowX = randomX;
            ColumnY = randomY;
            var duplicates = from value in XLocations
                             where XLocations == YLocations
                             select value;
            int countTwins = 0;
            foreach (var value in duplicates)
            {
                for (int i = 0; i < XLocations.Count; i++)
                {
                    if (XLocations[i] == value && YLocations[i] == value)
                    {
                        countTwins++;
                        if(countTwins == 2)
                        {
                            XLocations[i] = reshuffle.Next(1, SizeX + 1);
                            YLocations[i] = reshuffle.Next(1, SizeX + 1);
                            RowX = XLocations[i];
                            ColumnY = YLocations[i];
                            countTwins = 0;
                        }
                    }
                }
            }
        }
        public void OnClick(object sender, EventHandler e)
        {
            
        }
    }
}
