using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using SimpleTCP;
using Message = SimpleTCP.Message;

namespace TcpServer
{
    public partial class ServerForm : Form
    {
        private SimpleTcpServer _server;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtStatus.Text = @"Starting server...";
            var hostEntry = Dns.GetHostEntry(txtHost.Text);
            var ipAddress = hostEntry.AddressList[0];

            var portNumber = int.Parse(txtPort.Text);
            
            _server.Start(ipAddress, portNumber);
            txtStatus.Text += @"Server started successfully.";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_server.IsStarted)
            {
                _server.Stop();
            }

            txtStatus.Text += @"Server stopped working!";
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            _server = new SimpleTcpServer
            {
                Delimiter = 0x13,
                StringEncoder = Encoding.UTF8
            };
            _server.DataReceived += ServerOnDataReceived;
        }

        private void ServerOnDataReceived(object sender, Message e)
        {
            txtStatus.Invoke((MethodInvoker) delegate
            {
                txtStatus.Text += e.MessageString;
                e.ReplyLine($"You said: {e.MessageString}");
            });
        }
    }
}