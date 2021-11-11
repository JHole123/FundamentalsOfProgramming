using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

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

        /*public int minimax(int depth, int alpha, int beta, out List<char> board)
        {

        }*/


        /*public float minimax_(List<char> board, bool isTurn)
        {
            var pseudoBoard = new List<char>(board);

            if (CheckVictory(pseudoBoard) == 'x') return 10f;
            else if (CheckVictory(pseudoBoard) == 'o') return -10f;
            else if (IsFull(pseudoBoard)) return 0f;

            List<float> scores = new List<float>();

            for (int i = 0; i < 9; i++)
            {
                if (pseudoBoard[i] == -1)
                {
                    pseudoBoard[i] = isTurn ? 'o' : 'x';
                    float score = minimax_(pseudoBoard, !isTurn);
                    pseudoBoard[i] = -1f;
                    scores.Add(score);
                }
            }

            if (isTurn)
                return scores.Max();

            return scores.Min();

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
        }*/

        static char CheckVictory(List<char> board)
        {
            // Rows
            for (int i = 0; i < 7; i += 3)
            {
                Debug.WriteLine($"ROW Checking {i}");
                if (board[i] == board[i + 1] && board[i + 1] == board[i + 2] && board[i + 1] != ' ')
                {
                    Debug.WriteLine($"Has found {i} {i + 1} {i + 2} to be equal");
                    if (board[i] == 'x') return 'x';
                    else if (board[i] == 'o') return 'o';
                }
            }

            // Columns
            for (int i = 0; i < 3; i++)
            {
                Debug.WriteLine($"COLUMN Checking {i}");
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6] && board[i + 3] != ' ')
                {
                    Debug.WriteLine($"Has found {i} {i + 3} {i + 6} to be equal");
                    if (board[i] == 'x') return 'x';
                    else if (board[i] == 'o') return 'o';
                }
            }

            // Left to right diagonal
            Debug.WriteLine($"Checking LTR DIAGONAL");
            if (board[0] == board[4] && board[4] == board[8] && board[4] != ' ')
            {
                Debug.WriteLine($"Has found {0} {4} {8} to be equal");
                if (board[0] == 'x') return 'x';
                else if (board[0] == 'o') return 'o';
            }

            // Right to left diagonal
            Debug.WriteLine($"Checking RTL DIAGONAL");
            if (board[2] == board[4] && board[4] == board[6] && board[2] != ' ')
            {
                Debug.WriteLine($"Has found {2} {4} {6} to be equal");
                if (board[0] == 'x') return 'x';
                else if (board[0] == 'o') return 'o';
            }


            return ' ';

        }

        bool IsFull(List<char> board)
        {
            foreach (char c in board)
            {
                if (c != 'x' && c != 'o') return false;
            }
            return true;
        }

    }
}
