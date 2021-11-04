using System;

namespace ConsoleGames
{
    class Program
    {
        static char[] CurrentBoard = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};

        static void Main()
        {
            char[] arg = new char[] { 'x', 'x', 'o', 'x', 'x', 'o', 'o', 'o', 'o' };
            OutputBoard(arg);
            TakeUserInput('x');
            Console.Read();

        }

        static void OutputBoard(char[] board)
        {
            string arg = $"{board[0]}|{board[1]}|{board[2]}\n-----\n{board[3]}|{board[4]}|{board[5]}\n-----\n{board[6]}|{board[7]}|{board[8]}\n";
            Console.Write(arg);
        }

        static int TakeUserInput(char UserPiece)
        {
            Console.Clear();
            OutputBoard(CurrentBoard);
            Console.Write($"Please enter where you wish to put your piece?\n> ");
            int arg;
            int.TryParse(Console.ReadLine(), out arg);
            return arg;
        }

        static char CheckVictory(char[] board)
        {
            // Rows
            for (int i = 0; i < 7; i+=3)
            {
                if (board[i] == board[i+1] && board[i+1] == board[i+2])
                {
                    if (board[i] == 'x') return 'x';
                    else if (board[i] == 'o') return 'o';
                }
            }
            // Columns
            for (int i = 0; i < 3; i ++)
            {
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                {
                    if (board[i] == 'x') return 'x';
                    else if (board[i] == 'o') return 'o';
                }
            }

            // Left to right diagonal
            if (board[0] == board[4] && board[4] == board[8])
            {
                if (board[0] == 'x') return 'x';
                else if (board[0] == 'o') return 'o';
            }

            // Right to left diagonal
            if (board[2] == board[4] && board[4] == board[6])
            {
                if (board[0] == 'x') return 'x';
                else if (board[0] == 'o') return 'o';
            }

            return ' ';

        }

    }
}
