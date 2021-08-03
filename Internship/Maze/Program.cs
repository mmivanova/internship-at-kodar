using System;

namespace Maze
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", PathFinder.FindPath()));
        }
    }
}