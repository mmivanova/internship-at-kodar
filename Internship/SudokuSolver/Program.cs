namespace SudokuSolver
{
    internal static class Program
    {
        private static readonly SolvingAlgorithm SolvingAlgorithm = new SolvingAlgorithm();

        private static void Main()
        {
            var sudoku = ArrayUtils.ReadArray();
            var solvedSudoku = SolvingAlgorithm.SolveSudoku(sudoku);
            ArrayUtils.PrintArray(solvedSudoku);
        }
    }
}