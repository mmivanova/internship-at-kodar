using System;
using System.Collections.Generic;

namespace Maze
{
    public class Tile
    {
        public int Number { get; }
        public List<int> Connections { get; }

        public Tile(int number, List<int> connections)
        {
            Number = number;
            Connections = ValidateConnections(connections);
        }

        public Tile(int number)
        {
            Number = number;
            Connections = Maze.Connections.GetConnectionsByTile(Number);
        }

        private static List<int> ValidateConnections(List<int> connections)
        {
            if (connections.Count > 4)
            {
                throw new Exception("One tile can have a maximum of four connections.");
            }

            return connections;
        }

        public override string ToString()
        {
            return $"Tile: {Number} | Connections: {string.Join(", ", Connections)}";
        }
    }
}