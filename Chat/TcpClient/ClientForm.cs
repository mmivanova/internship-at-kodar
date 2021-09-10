using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TcpClient.Data;

namespace TcpClient
{
    public partial class ClientForm : Form
    {
        private List<Room> _rooms = new List<Room>();
        private List<User> _users = new List<User>();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            if (_users.Select(u => u.Username).Contains(username))
            {
                MessageBox.Show(@"Username is already taken");
                return;
            }
            var room = txtRoomName.Text;
            if (string.IsNullOrEmpty(room))
            {
                MessageBox.Show(@"Room name can't be empty");
                return;
            }
            
            cntWelcome.Visible = false;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            cntWelcome.Visible = true;
        }
    }
}