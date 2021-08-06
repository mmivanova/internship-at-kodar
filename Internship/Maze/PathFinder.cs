using System;
using System.Collections.Generic;

namespace Maze
{
    public class PathFinder
    {
        private const int StartTileNumber = 1;
        private const int EndTileNumber = 25;
        
        private bool _pathExists;
        private readonly Connection _connection = new();
        private Stack<int> Path { get; } = new();
        private Tile StartTile => _connection.GetTile(StartTileNumber);
        private Tile EndTile => _connection.GetTile(EndTileNumber);


        public IEnumerable<int> FindPath()
        {
            return PathExists(StartTile.Number)
                ? Path
                : throw new Exception("No path is found!");
        }

        private bool PathExists(int tileNumber)
        {
            var tile = _connection.GetTile(tileNumber);
            var connectionsPerTile = _connection.GetConnectionsByTile(tile.Number).Count;

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

        private void AddTileToPath(int currentTileNumber)
        {
            if (_pathExists)
            {
                Path.Push(currentTileNumber);
            }
        }

        private bool IsEndTile(int currentTileNumber)
        {
            return currentTileNumber.Equals(EndTile.Number);
        }

        private bool IsDeadEnd(Tile currentTile, int index)
        {
            return _connection.GetConnectionsByTile(currentTile.Connections[index]).Count == 0 &&
                   currentTile.Connections[index] != EndTile.Number;
        }
    }
}