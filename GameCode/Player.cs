using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
