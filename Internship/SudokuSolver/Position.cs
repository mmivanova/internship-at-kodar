using System.Reflection.Metadata;

namespace SudokuSolver
{
    public class Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Number { get; set; }

        public static readonly Position StartPosition = new(0, SudokuBoard.Initial.GetRow(0).FindIndex(n => n == 0));
        public static readonly Position LastPosition = new(Constants.Row - 1, SudokuBoard.Initial.GetRow(8).LastIndexOf(0) );

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static Position GetNextAvailablePosition(Position position)
        {
            var initial = SudokuBoard.Initial;

            var next = GetNextPosition(position);
            while (initial.Get(next.Row, next.Column) != 0)
            {
                next = GetNextPosition(next);
            }

            return next;
        }

        private static Position GetNextPosition(Position position)
        {
            var pos = new Position(position.Row, position.Column);
            if (position.Row == LastPosition.Row && position.Column == LastPosition.Column)
            {
                return position;
            }

            switch (pos.Column)
            {
                case < 8:
                    pos.Column++;
                    return pos;
                case 8 when pos.Row < 8:
                    pos.Column = 0;
                    pos.Row++;
                    return pos;
                default:
                    return pos;
            }
        }
    }
}