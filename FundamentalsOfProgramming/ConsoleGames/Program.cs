using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleGames
{
    class Program
    {
        static Board CurrentBoard = new Board();
        static Robot ai = new Robot();
        static UserInterface input = new UserInterface();

        static void Main()
        {
            NewGame();
        }

        static void NewGame()
        {
            string userInput = input.TakeInput("Do you wish to play against another 'human' or a 'robot'?", x => x == "human" || x == "robot");
            if (userInput == "human") HumanTurn();
            else RobotTurn();
        }

        static void RobotTurn()
        {
            input.TakeUserInput(ref CurrentBoard, 'x');
            if (CurrentBoard.Winner == 'x') VictoryEvent('x');
            RobotTurn();
        }

        static void HumanTurn(char userPiece = 'x')
        {
            input.TakeUserInput(ref CurrentBoard, 'x');
            if (CurrentBoard.Winner == userPiece) VictoryEvent(userPiece);
            HumanTurn(userPiece == 'x'? 'o':'x');
        }

        static void VictoryEvent(char winner)
        {
            Console.Clear();
            Console.WriteLine($"{winner} has won! Press anything to play another game...");
            Console.Read();
            CurrentBoard.SetBoard();
            NewGame();
        }

    }
}
