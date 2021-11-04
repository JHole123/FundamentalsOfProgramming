using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGames
{
    public class Robot
    {
        private char RobotPiece, HumanPiece;
        public int move = -1;

        public Robot(char robotPiece = 'o')
        {
            RobotPiece = robotPiece;
            HumanPiece = (robotPiece == 'x') ? 'o' : 'x';
        }

        public int minimax(List<char> board, char userPiece = 'o')
        {
            if (CheckVictory(board) == userPiece) return (userPiece == RobotPiece) ? 1 : -1;
            int score = -2;

            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    var pseudoBoard = board;
                    pseudoBoard[i] = userPiece;
                    int scoreForMove = -minimax(pseudoBoard, (userPiece == HumanPiece) ? RobotPiece : HumanPiece);
                    if (scoreForMove > score)
                    {
                        score = scoreForMove;
                        move = i;
                    }
                }
            }

            if (move == -1) return 0;

            return score;
        }

        char CheckVictory(List<char> board)
        {
            // Rows
            for (int i = 0; i < 7; i += 3)
            {
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2])
                {
                    if (board[i] == 'x') return 'x';
                    else if (board[i] == 'o') return 'o';
                }
            }
            // Columns
            for (int i = 0; i < 3; i++)
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

        /*public bool Backtrack(out int gridPosition, int currentCheck = 0)
        {
            if (CheckVictory(PlaceholderBoard) == HumanPiece) {
                gridPosition = currentCheck;
                return false;
            }

            else if (CheckVictory(PlaceholderBoard) == RobotPiece)
            {
                gridPosition = currentCheck;
                return true;
            }

            if (PlaceholderBoard.SequenceEqual(new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' })) { 
                gridPosition = 8;
                return true;
            }

            for (int i = 0; i < 9; i++)
            {
                if (PlaceholderBoard[i] == ' ') { 
                    PlaceholderBoard[i] = RobotPiece;
                    if (Backtrack(out gridPosition, i)) return true;
                }
            }

            gridPosition = currentCheck;
            return false;

        }*/



    }
}
