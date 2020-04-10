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
                List<Square> mineList = new List<Square>();  
                time = TimeSpan.FromSeconds(45);
                for (int i = 0; i < ; i++)
                {

                }
                while (!(time == TimeSpan.FromSeconds(0)))
                {
                    
                    
                }
            }
        }

        public void FogOfWar()
        {
            if (MinesFlagged == .50)
            {

            }
        
        


        }
           






    }
}
