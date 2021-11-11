using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGames
{
    public class Board
    {
        public List<char> Content { get; set; }
        public int FreeSpaces;
        public char Winner;
        public Board()
        {
            SetBoard();
        }

        public void SetBoard()
        {
            Content = new List<char>();
            for (sbyte i = 0; i < 9; i++)
            {
                Content.Add(' ');
            }
            FreeSpaces = 9;
            Winner = ' ';
        }

        public void EditBoard(int pos, char piece)
        {
            Content[pos - 1] = piece;
            Winner = CheckVictory(Content);
        }

        private char CheckVictory(List<char> board)
        {
            // Rows
            for (int i = 0; i < 7; i += 3)
            {
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2] && board[i + 1] != ' ')
                {
                    if (board[i] == 'x') return 'x';
                    else if (board[i] == 'o') return 'o';
                }
            }

            // Columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6] && board[i + 3] != ' ')
                {
                    if (board[i] == 'x') return 'x';
                    else if (board[i] == 'o') return 'o';
                }
            }

            // Left to right diagonal
            if (board[0] == board[4] && board[4] == board[8] && board[4] != ' ')
            {
                if (board[0] == 'x') return 'x';
                else if (board[0] == 'o') return 'o';
            }

            // Right to left diagonal
            if (board[2] == board[4] && board[4] == board[6] && board[2] != ' ')
            {
                if (board[0] == 'x') return 'x';
                else if (board[0] == 'o') return 'o';
            }

            return ' ';

        }
    }
}
