using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Paint.Shapes;

namespace Paint
{
    public partial class MainForm : Form
    {
        private readonly Graphics _graphics;
        private Point _mouseLocation;
        private List<House> Houses { get; set; }

        public MainForm()
        {
            InitializeComponent();
            _graphics = mainPanel.CreateGraphics();
        }

        private void mainPanel_Click(object sender, EventArgs e)
        {
            var house = new House(_mouseLocation);
            Houses.Add(house);
            
            house.Draw(_graphics);
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = e.Location;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var house in Houses)
            {
                house.Draw(_graphics);
            }
        }
    }
}