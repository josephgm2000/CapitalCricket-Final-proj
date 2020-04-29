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

        string textFile = @"c:\temp\MyTextFile.txt";

        try
        {
            // checking if file exists and if file does exist, deletes it
            // checking if file exists and if file does exist, deletes it
            // checking if file exists and if file does exist, deletes it
            if (File.Exists(textFile))
            {

            // creates text file and sets parameters                File.Delete(textFile);

            // creates text file and sets parameters                File.Delete(textFile);

            // creates text file and sets parameters                File.Delete(textFile);

            // creates tex tfile                 File.Delete(textFile);

                           //// creates tex t                File.Delete(textFile);

reads text file and wrties tites to consoler                           //// creates tex t                File.Delete(textFile);

                           //// creates tex t                File.Delete(textFile);


        //// creates tex t                File.Delete(textFile);



    }
}
}                          //// creates tex t                File.Delete(textFile);
            }

            using (StreamWriter sw = File.CreateText(textFile))
              {
                  if (var gameOver = true && WinGame = true)
                  {
                      sw.WriteLine({GameTimer.Interval});
                  }
              }

            
            using (StreamReader sr = File.OpenText(textFile)
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
