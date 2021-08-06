namespace SudokuSolver
{
    public class Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Number { get; set; }
        
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public static Position MoveNextPosition(Position position)
        {
            switch (position.Column)
            {
                case < 8:
                    position.Column++;
                    return position;
                case 8 when position.Row < 8:
                    position.Column = 0;
                    position.Row++;
                    return position;
                default:
                    return position;
            }
        }
        
        public static Position MoveToPreviousPosition(Position position)
        {
            switch (position.Column)
            {
                case > 0:
                    position.Column--;
                    return position;
                case 0 when position.Row > 0:
                    position.Column = 8;
                    position.Row--;
                    return position;
                default:
                    return position;
            }
        }
    }
}