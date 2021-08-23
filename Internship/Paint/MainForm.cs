using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Paint.Helpers;
using Paint.Shapes;

namespace Paint
{
    public partial class MainForm : Form
    {
        private static Point _mouseLocation;
        private readonly Graphics _graphics;
        private List<House> _houses = new();

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
            SaveHelper.SaveFile(_houses);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _houses = LoadHelper.LoadFile();
            Refresh();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _houses = new List<House>();
            Refresh();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var house in _houses)
            {
                house.Draw(_graphics);
            }
        }
    }
}