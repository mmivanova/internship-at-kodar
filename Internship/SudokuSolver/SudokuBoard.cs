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
                if (GetRow(position.Row).Contains(i) || GetColumn(position.Column).Contains(i)) 
                {
                    continue;
                }

                numbers.Add(i);
            }

            return numbers;
        }
    }
}