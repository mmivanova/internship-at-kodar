using System;

namespace Maze
{
    internal static class Program
    {
        private static void Main()
        {
            var pathFinder = new PathFinder();
            Console.WriteLine(string.Join(", ", pathFinder.FindPath()));
        }
    }
}