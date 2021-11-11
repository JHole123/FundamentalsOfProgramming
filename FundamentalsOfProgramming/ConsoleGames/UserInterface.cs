using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGames
{
    public class UserInterface
    {
        public string TakeInput(string question, Func<string, bool> conditions)
        {
            string userInput;
            do
            {
                Console.Write($"{question}\n> ");
                userInput = Console.ReadLine().ToLower().Trim();
            } while (!conditions(userInput));
            return userInput;
        }
        public int TakeIntInput(string question, Func<int, bool> conditions)
        {
            int userInput;
            do
            {
                Console.Write($"{question}\n> ");
                int.TryParse(Console.ReadLine().ToLower().Trim(), out userInput);
            } while (!conditions(userInput));
            return userInput;
        }
        private void OutputBoard(Board Board)
        {
            Console.Clear();
            var board = Board.Content;
            string arg = $"{board[0]}|{board[1]}|{board[2]}\n-----\n{board[3]}|{board[4]}|{board[5]}\n-----\n{board[6]}|{board[7]}|{board[8]}\n";
            Console.Write(arg);
        }
        public void TakeUserInput(Board board, char UserPiece)
        {
            OutputBoard(board);
            int input = TakeIntInput($"Please enter where you wish to put your {UserPiece}?", x => x > 0 && x < 10);
            board.EditBoard(input, UserPiece);
        }
    }
}
