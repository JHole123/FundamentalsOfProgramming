using System;
using System.Collections.Generic;

namespace ConsoleGames
{
    class Program
    {
        static List<char> CurrentBoard = new List<char>(new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '});

        static void Main()
        {
            NewTurn();
        }

        static void NewTurn()
        {
            TakeUserInput('x');
            if (CheckVictory(CurrentBoard) == 'x') VictoryEvent('x');
            TakeUserInput('o');
            if (CheckVictory(CurrentBoard) == 'o') VictoryEvent('o');
            NewTurn();
        }

        static void VictoryEvent(char winner)
        {
            Console.Clear();
            Console.WriteLine($"{winner} has won! Press anything to play another game...");
            Console.Read();
            CurrentBoard.Clear();
            CurrentBoard = new List<char>(new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' });
            NewTurn();
        }

        static void OutputBoard(List<char> board)
        {
            string arg = $"{board[0]}|{board[1]}|{board[2]}\n-----\n{board[3]}|{board[4]}|{board[5]}\n-----\n{board[6]}|{board[7]}|{board[8]}\n";
            Console.Write(arg);
        }

        static void TakeUserInput(char UserPiece)
        {
            int arg;
            do
            {
                Console.Clear();
                OutputBoard(CurrentBoard);
                Console.Write($"Please enter where you wish to put your {UserPiece}?\n> ");
                int.TryParse(Console.ReadLine(), out arg);
            } 
            while (arg < 1 || arg > 9);
            CurrentBoard[arg - 1] = UserPiece;
        }

        static char CheckVictory(List<char> board)
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
