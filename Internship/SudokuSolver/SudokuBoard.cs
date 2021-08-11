using System.Collections.Generic;
using System.Linq;
using static SudokuSolver.Constants;

namespace SudokuSolver
{
    public class SudokuBoard
    {
        public static SudokuBoard Initial { get; set; }
        private int[,] Board { get; }

        public SudokuBoard(int[,] board)
        {
            Board = new int[Row, Column];
            Board = board.Clone() as int[,];
        }

        public int Get(int row, int cell)
        {
            return Board[row, cell];
        }

        public void Set(Position position, int value)
        {
            position.Number = value;
            Board[position.Row, position.Column] = position.Number;
        }

        public bool ContainsZero()
        {
            for (var r = 0; r < Row; r++)
            {
                for (var c = 0; c < Column; c++)
                {
                    if (Board[r, c] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<int> GetRow(int rowNumber)
        {
            var row = new List<int> { };

            for (var col = 0; col < Column; col++)
            {
                row.Add(Board[rowNumber, col]);
            }

            return row;
        }

        public IEnumerable<int> GetColumn(int columnNumber)
        {
            var col = new List<int> { };

            for (var row = 0; row < Row; row++)
            {
                col.Add(Board[row, columnNumber]);
            }

            return col.ToArray();
        }

        public List<int> GetAllAvailableNumbersForCell(Position position)
        {
            var numbers = new List<int>();
            for (var i = 1; i <= 9; i++)
            {
                if (IsUnavailableNumber(position, i)) continue;

                numbers.Add(i);
            }

            return numbers;
        }

        private bool IsUnavailableNumber(Position position, int i)
        {
            return GetRow(position.Row).Contains(i)
                   || GetColumn(position.Column).Contains(i)
                   || IsPresentInSmallSquare(position, i);
        }

        private static int GetIndexOfSquareRow(int row)
        {
            var squareRow = row switch
            {
                >= 3 and <= 5 => 3,
                >= 6 and <= 8 => 6,
                _ => 0
            };

            return squareRow;
        }

        private static int GetIndexOfSquareColumn(int column)
        {
            var squareColumn = column switch
            {
                >= 3 and <= 5 => 3,
                >= 6 and <= 8 => 6,
                _ => 0
            };

            return squareColumn;
        }

        private static bool IsPresentInSmallSquare(Position position, int number)
        {
            var numbers = GetSquareNumbers(position);

            return numbers.Contains(number);
        }

        private static List<int> GetSquareNumbers(Position position)
        {
            var numbers = new List<int>();
            for (var row = GetIndexOfSquareRow(position.Row); row < 3; row++)
            {
                for (var col = GetIndexOfSquareColumn(position.Column); col < 3; col++)
                {
                    if (Initial.Get(row, col) != 0)
                    {
                        numbers.Add(Initial.Get(row, col));
                    }
                }
            }

            return numbers;
        }
    }
}