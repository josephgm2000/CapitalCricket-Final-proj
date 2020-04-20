using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EO.Internal;

namespace GameCode
{
    class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Player(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        //if (Player 1.squareVal > Player2.squareVal)
        //{
        //    string[] lines = {"Player 1 time," "Player 2 time" };
        //    System.IO.File.WriteAllLines("", lines);
        //}
        //FileStream fs;
        //StreamWriter fw;
        
        ////creates file stream object
        //fs = new FileStream("file name", FileMode.CreateNew, FileAccess.Write);
        //// creates writer object
        //fw = new StreamWriter(fs);
        //// writes text to file
        //fw.WriteLine("{Winning Player's Name}");
        //fw.WriteLine("{Length of time to win}");
    }
}
