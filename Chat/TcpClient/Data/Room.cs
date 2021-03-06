using System.Collections.Generic;

namespace TcpClient.Data
{
    public class Room
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public Room(string name, List<User> users)
        {
            Name = name;
            Users = users;
        }
    }
}