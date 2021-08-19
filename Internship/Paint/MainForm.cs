using System;
using System.Drawing;
using System.Windows.Forms;
using Paint.Shapes;

namespace Paint
{
    public partial class MainForm : Form
    {
        private readonly Graphics _graphics;
        private Point _mouseLocation;

        public MainForm()
        {
            InitializeComponent();
            _graphics = mainPanel.CreateGraphics();
        }

        private void mainPanel_Click(object sender, EventArgs e)
        {
            House.DrawHouse(_graphics, _mouseLocation);
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = e.Location;
        }
    }
}