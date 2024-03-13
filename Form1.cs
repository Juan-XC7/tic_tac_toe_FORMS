using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tic_tac_toe_GUI
{
    public partial class Form1 : Form
    {
        static string turn = "player1";
        private int[,] board = new int[3, 3]; // 3x3 matrix representing the Tic Tac Toe board

        public Form1()
        {
            InitializeComponent();
        }

        public static string SwitchTurn()
        {
            turn = turn == "player1" ? "player2" : "player1";
            return turn;
        }

        public static string getPlayerTurn()
        {
            return turn;
        }

        private int CheckForWinner()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] != 0 && board[row, 0] == board[row, 1] && board[row, 0] == board[row, 2])
                {
                    return board[row, 0];
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] != 0 && board[0, col] == board[1, col] && board[0, col] == board[2, col])
                {
                    return board[0, col];
                }
            }

            // Check diagonals
            if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
            {
                return board[0, 0];
            }
            if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
            {
                return board[0, 2];
            }

            // No winner found
            return 0;   
        }

        private string GetWinner()
        {
            int winnerSymbol = CheckForWinner();

            if (winnerSymbol == 1)
            {
                return "Player 1";
            }
            else if (winnerSymbol == 2)
            {
                return "Player 2";
            }
            else
            {
                return "No winner"; // No winner found
            }
        }


        private void StorePlay(PictureBox pictureBox, int coordinate1, int coordinate2)
        {
            if (board[coordinate1 - 1, coordinate2 - 1] != 0)
            {
                return;
            }

            int playerMove = (turn == "player1") ? 1 : 2;
            board[coordinate1-1, coordinate2-1] = playerMove; // Fill with player number

            // Update the picture
            pictureBox.Image = (turn == "player1") ? Properties.Resources.plant : Properties.Resources.zombie;

            string winner = GetWinner();

            if (winner != "No winner")
            {
                MessageBox.Show("Winner: " + winner);
                return;
            }

            SwitchTurn();
        }

        private void coordinate1_1_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 1, 1);
        }

        private void coordinate1_2_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 1, 2);
        }

        private void coordinate1_3_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 1, 3);
        }

        private void coordinate2_1_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 2, 1);
        }

        private void coordinate2_2_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 2, 2);
        }

        private void coordinate2_3_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 2, 3);
        }

        private void coordinate3_1_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 3, 1);
        }

        private void coordinate3_2_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 3, 2);
        }

        private void coordinate3_3_Click(object sender, EventArgs e)
        {
            StorePlay((PictureBox)sender, 3, 3);
        }
    }
}
