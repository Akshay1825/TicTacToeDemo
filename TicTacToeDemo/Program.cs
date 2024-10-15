using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeDemo
{
    internal class Program
    {
        //We have created 2D Array for the game
        //First Player is X
        //Second Player is O

        static char[ , ] board =
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        static char currentPlayer = 'X';
        static void Main(string[] args)
        {
            int Count = 0;
            bool gameEnded = false;

            while (!gameEnded && Count < 9)
            {
                PrintBoard();
                PlayerMove();
                gameEnded = CheckWin();

                if (!gameEnded)
                {
                    Count++;
                    SwitchPlayer();
                }
            }

            PrintBoard();

            Console.WriteLine(gameEnded ? $"Player {currentPlayer} wins" : "It's a draw");

        }
        static void PrintBoard()
        {
            Console.Clear(); 
            Console.WriteLine(" {0} | {1} | {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[2, 0], board[2, 1], board[2, 2]);
        }

        static void PlayerMove()
        {
            int choice;
            bool validMove = false;

            while (!validMove)
            {
                Console.WriteLine($"Player {currentPlayer}, choose your position (1-9): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9)
                {
                    int row = (choice - 1) / 3;
                    int col = (choice - 1) % 3;

                    if (board[row, col] != 'X' && board[row, col] != 'O')
                    {
                        board[row, col] = currentPlayer;
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("That position is already taken");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        static void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }

        static bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                {
                    return true;
                }
            }

            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                return true;
            }

            return false;
        }
    }
}


    

