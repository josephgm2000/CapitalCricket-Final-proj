using System;
using System.Collections.Generic;
using System.Text;

namespace GameCode
{
    public class PowerUp
    {
        public int MinesFlagged { get; set; }
        public PowerUp(int minesFlagged)
        {

        }
        public void GoldenDome(TimeSpan time)
        {
            if (MinesFlagged == .75)
            {
                time = TimeSpan.FromSeconds(45);
                if (!(time == TimeSpan.FromSeconds(0)))
                {

                }
            }
        }
    }
}
