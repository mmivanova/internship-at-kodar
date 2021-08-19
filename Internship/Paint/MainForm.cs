using System;
using System.Drawing;
using System.Windows.Forms;

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
            var startingPoint = GetRandomStartingPoint(_mouseLocation);
            var x2 = 2 * _mouseLocation.X - startingPoint.X;
            var y2 = 2 * _mouseLocation.Y - startingPoint.Y;
            
            var width = x2 - startingPoint.X;
            var height = y2 - startingPoint.Y;
            
            var size = new Size(width, height);
            var rect = new Rectangle(startingPoint, size);
            
            
            _graphics.DrawRectangle(new Pen(Color.White, 1.0f), rect);
        }
        
        private static Point GetRandomStartingPoint(Point middle)
        {
            var random = new Random();
            var x1 = random.Next(middle.X - 100, middle.X - 50);
            var y1 = random.Next(middle.Y - 100, middle.Y - 50);
            var start = new Point(x1, y1);
            return start;
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = e.Location;
        }
    }
}