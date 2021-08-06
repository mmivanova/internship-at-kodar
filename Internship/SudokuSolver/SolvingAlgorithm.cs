using System;
using static SudokuSolver.Constants;

namespace SudokuSolver
{
    public static class SolvingAlgorithm
    {
        private static readonly Position StartPosition = new(0, 0);
        private static readonly Position FinalPosition = new(8, 8);
        private static bool _isSolved;

        public static SudokuBoard SolveSudoku(SudokuBoard board)
        {
            return (Solver(board, StartPosition))
                ? board
                : throw new Exception("This sudoku board cannot be solved");
        }

        private static bool Solver(SudokuBoard board, Position position, int number = 1)
        {
            if (!board.ContainsZero())
            {
                _isSolved = true;
            }

            for (var row = 0; row < Row; row++)
            {
                if (_isSolved)
                {
                    break;
                }

                for (var col = 0; col < Column; col++)
                {
                    if (IsFinalPosition(position))
                    {
                        _isSolved = true;
                        break;
                    }

                    position.Number = board.Get(row, col);
                    if (position.Number == SudokuBoard.Initial.Get(row, col) && position.Number is not 0) continue;
                    number = board.GetNextAvailableNumber(row, col);

                    if (IsValidNumber(number))
                    {
                        board.Set(row, col, number);
                        Solver(board, Position.MoveNextPosition(position), number);
                    }

                    Solver(board, Position.MoveToPreviousPosition(position), number);
                }
            }

            return _isSolved;
        }

        private static bool IsFinalPosition(Position position)
        {
            return position.Column == FinalPosition.Column && position.Row == FinalPosition.Row;
        }

        private static bool IsValidNumber(int number)
        {
            return number is >= 1 and <= 9;
        }
    }
}