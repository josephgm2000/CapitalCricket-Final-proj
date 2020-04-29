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
        //string fileName = @"file name";

        //try
        //{
        //    // checking if file already exists and if yes, deletes it
        //    if  (File.Exists(fileName))
        //    {
        //        File.Delete(fileName);
        //    }

        //    // creates a new file
        //    using (StreamWriter sw = File.CreateText(fileName))
        //    {
        //        sw.WriteLine("You win!");
        //        sw.WriteLine("");


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
        //fw.Console.WriteLine("You win!");
        //fw.Console.WriteLine("{Length of time to win}");
    }
}
