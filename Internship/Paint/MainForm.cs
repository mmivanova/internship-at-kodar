using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Paint.Shapes;

namespace Paint
{
    public partial class MainForm : Form
    {
        private static Point _mouseLocation;
        private readonly Graphics _graphics;
        private List<House> _houses = new List<House>();

        public MainForm()
        {
            InitializeComponent();
            _graphics = mainPanel.CreateGraphics();
        }

        private void mainPanel_Click(object sender, EventArgs e)
        {
            var house = new House(_mouseLocation);
            _houses.Add(house);

            house.Draw(_graphics);
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = e.Location;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "XML file (*.xml)| *.xml";
            sfd.ShowDialog();

            if (sfd.FileName == "") return;
            var path = Path.GetFullPath(sfd.FileName);
            var fs = new FileStream(path, FileMode.OpenOrCreate);
            var serializer = new XmlSerializer(typeof(List<House>));
            serializer.Serialize(fs, _houses);
            fs.Close();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var house in _houses)
            {
                house.Draw(_graphics);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML file (*.xml)| *.xml";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName == "") return;
            var path = Path.GetFullPath(openFileDialog.FileName);
            var fs = new FileStream(path, FileMode.Open);
            var serializer = new XmlSerializer(_houses.GetType());
            _houses = (List<House>) serializer.Deserialize(fs);
            fs.Close();
            Refresh();
        }
    }
}