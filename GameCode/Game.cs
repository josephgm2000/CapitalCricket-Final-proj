using System;
using System.Collections.Generic;
using System.Text;

namespace GameCode
{
    class Game
    {
        private bool IsGameOver = false;
        public Game()
        {

        }

        public void Run()
        {
            InitilizeGame();
            do
            {        
                ProcessInput();
                UpdateGame();
                RenderOutput();
            } while (IsGameOver == false);
        }

        private void RenderOutput()
        {
            throw new NotImplementedException();
        }

        private void UpdateGame()
        {
            throw new NotImplementedException();
        }

        private void ProcessInput()
        {
            throw new NotImplementedException();
        }

        private void InitilizeGame()
        {
            Board board = new Board();

            //switch (onclick)
            //{
            //    case IsMine == true;
            //       IsMine = false;
            //        if(X+2.ISMINE == false && Y + 2)
            //        {
            //            ISMINE = true;
            //        }
            //        else if()
            //        {

            //        }
            //}
                    
               
        }
    }
}
