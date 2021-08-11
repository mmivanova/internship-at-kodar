namespace SudokuSolver
{
    public class Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Number { get; set; }

        private Position(int row, int column)
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
            if (pos.Row == GetLastPosition().Row && pos.Column == GetLastPosition().Column)
            {
                return pos;
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

        public static Position GetLastPosition()
        {
            var lastPosition = new Position(8, SudokuBoard.Initial.GetRow(8).LastIndexOf(0));

            return lastPosition;
        }

        public static Position GetFirstPosition()
        {
            var firstPosition = new Position(0, SudokuBoard.Initial.GetRow(0).FindIndex(n => n == 0));

            return firstPosition;
        }
    }
}