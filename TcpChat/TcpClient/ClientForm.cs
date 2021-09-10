using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TcpClient.Data;

namespace TcpClient
{
    public partial class ClientForm : Form
    {
        private List<Room> _rooms = new List<Room>();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var room = txtRoomName.Text;
            
            cntWelcome.Visible = false;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            cntWelcome.Visible = true;
        }
    }
}