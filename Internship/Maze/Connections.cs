using System;
using System.Collections.Generic;

namespace Maze
{
    public static class Connections
    {
        //    |------------------------|
        //    |  1 |  2    3    4    5 |
        //    |    |----|----|    |    |
        //    |  6    7 |  8 |  9 | 10 |
        //    |----|         |    |----|
        //    | 11 | 12   13 | 14   15 |
        //    |    |    |         |    |
        //    | 16 | 17 | 18   19 | 20 |
        //    |    |----|    |    |----|
        //    | 21 | 22   23 | 24  25  |
        //    |------------------------|

        private static List<Tile> GetAllTiles()
        {
            var tiles = new List<Tile>
            {
                new(1, new List<int> {6}),
                new(2, new List<int>()),
                new(3, new List<int> {2}),
                new(4, new List<int> {3, 5}),
                new(5, new List<int> {10}),
                new(6, new List<int> {7}),
                new(7, new List<int> {12}),
                new(8, new List<int>()),
                new(9, new List<int> {4}),
                new(10, new List<int>()),
                new(11, new List<int> {16}),
                new(12, new List<int> {13, 17}),
                new(13, new List<int> {8, 18}),
                new(14, new List<int> {9, 15}),
                new(15, new List<int> {20}),
                new(16, new List<int> {11, 21}),
                new(17, new List<int>()),
                new(18, new List<int> {19, 23}),
                new(19, new List<int> {14, 24}),
                new(20, new List<int>()),
                new(21, new List<int> {16}),
                new(22, new List<int>()),
                new(23, new List<int> {22}),
                new(24, new List<int> {25}),
                new(25, new List<int>()),
            };

            return tiles;
        }

        public static List<int> GetConnectionsByTile(int number)
        {
            var tile = GetTile(number);
            if (tile != null) return tile.Connections;
            throw new ArgumentException("Invalid tile number");
        }

        public static Tile GetTile(int number)
        {
            return GetAllTiles().Find(t => t.Number.Equals(number));
        }

        private static int GetLastConnection(int number)
        {
            var connections = GetConnectionsByTile(number);
            return connections[^1];
        }
    }
}