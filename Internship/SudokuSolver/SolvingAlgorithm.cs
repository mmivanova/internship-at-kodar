using System;

namespace SudokuSolver
{
    public class SolvingAlgorithm
    {
        private bool _isSolved;
        private static readonly Position StartPosition = Position.StartPosition;
        private static readonly Position LastPosition = Position.LastPosition;

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

                if (IsNotValidNumber(board, position, nextAvailablePosition, number)) continue;
                board.Set(position, number);

                IsSolvable(board, nextAvailablePosition);
                SetCurrentPositionToZero(board, position);
            }

            return _isSolved;
        }

        private void SetCurrentPositionToZero(SudokuBoard board, Position position)
        {
            if (!_isSolved)
            {
                board.Set(position, 0);
            }
        }

        private static bool IsNotValidNumber(SudokuBoard board, Position position, Position nextPosition, int number)
        {
            return NextCellCanHoldOnlyCurrentNumber(board, nextPosition, number)
                   && !IsFinalPosition(position)
                   && IsOnTheSameRow(position, nextPosition);
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
            return position.Column == LastPosition.Column && position.Row == LastPosition.Row;
        }
    }
}