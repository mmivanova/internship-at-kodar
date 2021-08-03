using System;
using System.Collections.Generic;

namespace Maze
{
    public static class PathFinder
    {
        private static bool _pathExists;
        private static Stack<int> Path { get; } = new();
        private static Tile StartTile => Connections.GetTile(1);
        private static Tile EndTile => Connections.GetTile(25);

        public static IEnumerable<int> FindPath()
        {
            return PathExists(StartTile.Number)
                ? Path
                : throw new Exception("No path is found!");
        }

        private static bool PathExists(int tileNumber)
        {
            var tile = Connections.GetTile(tileNumber);
            var connectionsPerTile = Connections.GetConnectionsByTile(tile.Number).Count;

            _pathExists = IsEndTile(tile.Number);

            for (var connectionIndex = 0; connectionIndex < connectionsPerTile; connectionIndex++)
            {
                if (_pathExists) break;
                if (IsDeadEnd(tile, connectionIndex)) continue;
                PathExists(tile.Connections[connectionIndex]);
            }

            AddTileToPath(tile.Number);

            return _pathExists;
        }

        private static void AddTileToPath(int currentTileNumber)
        {
            if (_pathExists)
            {
                Path.Push(currentTileNumber);
            }
        }

        private static bool IsEndTile(int currentTileNumber)
        {
            return currentTileNumber.Equals(EndTile.Number);
        }

        private static bool IsDeadEnd(Tile currentTile, int index)
        {
            return Connections.GetConnectionsByTile(currentTile.Connections[index]).Count == 0 &&
                   currentTile.Connections[index] != EndTile.Number;
        }
    }
}