namespace TcpClient.Data
{
    public class User
    {
        public string Username { get; set; }
        public Room Room { get; set; }

        public User(string username, Room room)
        {
            Username = username;
            Room = room;
        }
    }
}