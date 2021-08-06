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

        public int Get(Position position)
        {
            return Board[position.Row, position.Column];
        }

        public void Set(int row, int column, int value)
        {
            Board[row, column] = value;
        }

        public void Set(Position position, int value)
        {
            position.Number = value;
            Board[position.Row, position.Column] = position.Number;
        }

        public bool ContainsZero()
        {
            return Board.Cast<int>().Any(cell => cell.Equals(0));
        }

        public IEnumerable<int> GetRow(int rowNumber)
        {
            var row = new List<int> { };

            for (var col = 0; col < Column; col++)
            {
                row.Add(Board[rowNumber, col]);
            }

            return row.ToArray();
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

        public int[,] GetThreeByThreeArea(int row, int column)
        {
            var threeByThreeArea = new int[3, 3];

            var tempr = 0;

            for (var r = row - 3; r < row; r++)
            {
                var tempcol = 0;
                for (var col = column - 3; col < column; col++)
                {
                    threeByThreeArea[tempr, tempcol] = Board[r, col];
                    tempcol++;
                }

                tempr++;
            }

            return threeByThreeArea;
        }

        public int GetNextAvailableNumber(int row, int column)
        {
            var num = 1;

            while (GetRow(row).Contains(num) || GetColumn(column).Contains(num))
            {
                num++;
            }

            return num;
        }
    }
}