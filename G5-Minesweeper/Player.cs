using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace G5_Minesweeper
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
        
        // string fileName = @"C:Temp/LukeShafferTX.txt";
        // example file name above

        //try
        //{
        //      // checking if file already exists and if yes, deletes it
        //      if  (File.Exists("player.txt"))
        //      {
        //          File.Delete("player.txt");
        //      }

        //      // creates a new file
        //      using (StreamWriter sw = File.CreateText("player.txt"))
        //      {
        //          sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
        //          sw.WriteLine("Author: Luke Shaffer");
        //          sw.WriteLine("You win!");
        //          // sw.WriteLine("{Length of time to win}");
        //      }

        //      // writes file contents on console
        //      using (StreamReader sr = File.OpenText("player.txt"))
        //      {
        //          string f = "";
        //          while ((f = sr.ReadLine()) != null)
        //          {
        //              Console.WriteLine(f);
        //          }
        //      }
        //    Console.WriteLine(f);
        //}

        //catch (Exception Ex)
        //{
        //    // handles exception
        //    Console.WriteLine("No text can be displayed.");
        //}
        
        //Console.ReadKey();


        
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
