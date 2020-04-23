using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace G5_Minesweeper
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Board board = new Board();
            board.AdjacentMines();
            board.DisplayBoard();
        }

        private void Game_Click(object sender, EventArgs e)
        {
            int count = 0;
            count++;
            if (count == 1)
            {
                
            }
        }
    }
}
