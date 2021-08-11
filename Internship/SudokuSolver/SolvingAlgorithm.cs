using System;

namespace SudokuSolver
{
    public class SolvingAlgorithm
    {
        private bool _isSolved;
        private static readonly Position StartPosition = Position.GetFirstPosition();
        private static readonly Position FinalPosition = Position.GetLastPosition();

        public SudokuBoard SolveSudoku(SudokuBoard board)
        {
            return (IsSolvable(board, StartPosition))
                ? board
                : throw new Exception("This sudoku board cannot be solved");
        }

        private bool IsSolvable(SudokuBoard board, Position position)
        {
            var availableNumbers = board.GetAllAvailableNumbersForCell(position);
            _isSolved = !board.ContainsZero() && IsFinalPosition(position);

            var nextAvailablePosition = Position.GetNextAvailablePosition(position);

            for (var num = 0; num < availableNumbers.Count; num++)
            {
                if (_isSolved) break;
                var number = availableNumbers[num];

                if (NextCellCanHoldOnlyCurrentNumber(board, nextAvailablePosition, number)
                    && !IsFinalPosition(position)
                    && IsOnTheSameRow(position, nextAvailablePosition)) continue;
                board.Set(position, number);

                IsSolvable(board, nextAvailablePosition);
                if (!_isSolved)
                {
                    board.Set(position, 0);
                }
            }

            return _isSolved;
        }

        private static bool NextCellCanHoldOnlyCurrentNumber(SudokuBoard board, Position nextAvailablePosition, int num)
        {
            return board.GetAllAvailableNumbersForCell(nextAvailablePosition).Count == 1
                   && board.GetAllAvailableNumbersForCell(nextAvailablePosition)[0] == num;
        }

        private static bool IsOnTheSameRow(Position position, Position nextPosition)
        {
            return position.Row == nextPosition.Row;
        }

        private static bool IsFinalPosition(Position position)
        {
            return position.Column == FinalPosition.Column && position.Row == FinalPosition.Row;
        }
    }
}