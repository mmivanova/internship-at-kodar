using System;
using System.Linq;
using static SudokuSolver.Constants;

namespace SudokuSolver
{
    public static class ArrayUtils
    {
        public static SudokuBoard ReadArray()
        {
            var board = new int[Row, Column];

            for (var row = 0; row < Row; row++)
            {
                var input = ReadLineAndConvertToIntArray();
                for (var column = 0; column < Column; column++)
                {
                    board[row, column] = input[column];
                }
            }

            SudokuBoard.Initial = new SudokuBoard(board);
            var sudokuBoard = new SudokuBoard(board);
            
            return sudokuBoard;
        }

        private static int[] ReadLineAndConvertToIntArray()
        {
            return Console.ReadLine()
                ?.Trim()
                .Split(Separator)
                .Select(int.Parse)
                .ToArray();
        }
        
        public static void PrintArray(SudokuBoard board)
        {
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Column; j++)
                {
                    Console.Write($"{board.Get(i, j)} ");
                }
                Console.Write(Environment.NewLine);
            }
        }
        
        public static void PrintArray(int[,] board)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        
    }
}