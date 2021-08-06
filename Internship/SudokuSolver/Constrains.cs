using System.Linq;

namespace SudokuSolver
{
    public class Constrains
    {
        private static bool IsPresentInTheRow(int number, int row, SudokuBoard board) =>
            board.GetRow(row).Contains(number);

        private static bool IsPresentInTheColumn(int number, int column, SudokuBoard board) =>
            board.GetColumn(column).Contains(number);

        
        public static bool IsAlreadyPresentNumber(int number, int row, int column, SudokuBoard board)
        {
            return IsPresentInTheRow(number, row, board)
                   || IsPresentInTheColumn(number, column, board);
        }

        public static bool IsAlreadyPresentInRow(int number, int row, SudokuBoard board)
        {
            return IsPresentInTheRow(number, row, board);
        }

        public static bool IsAlreadyPresentInColumn(int number, int column, SudokuBoard board)
        {
            return IsPresentInTheColumn(number, column, board);
        }
    }
}