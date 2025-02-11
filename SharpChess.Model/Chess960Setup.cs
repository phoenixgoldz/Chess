using System;
using System.Collections.Generic;
using SharpChess.Model;

namespace SharpChess.Model
{
    public static class Chess960Setup
    {
        private static Random rand = new Random();


        public static char[] GenerateChess960Position()
        {
            char[] board = new char[8];
            List<char> pieces = new List<char> { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' };

            // Place bishops on opposite-colored squares
            int firstBishop = rand.Next(0, 8);
            int secondBishop;
            do
            {
                secondBishop = rand.Next(0, 8);
            } while (firstBishop % 2 == secondBishop % 2);

            board[firstBishop] = 'B';
            board[secondBishop] = 'B';
            pieces.Remove('B');
            pieces.Remove('B');

            // Place the queen
            int queenIndex;
            do
            {
                queenIndex = rand.Next(0, 8);
            } while (board[queenIndex] != '\0');
            board[queenIndex] = 'Q';
            pieces.Remove('Q');

            // Place knights
            for (int i = 0; i < 2; i++)
            {
                int knightIndex;
                do
                {
                    knightIndex = rand.Next(0, 8);
                } while (board[knightIndex] != '\0');
                board[knightIndex] = 'N';
                pieces.Remove('N');
            }

            // Place rooks and king ensuring king is between the rooks
            List<int> emptySlots = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                if (board[i] == '\0') emptySlots.Add(i);
            }
            emptySlots.Sort();
            board[emptySlots[0]] = 'R';
            board[emptySlots[2]] = 'R';
            board[emptySlots[1]] = 'K';

            return board;
        }

    }
}
