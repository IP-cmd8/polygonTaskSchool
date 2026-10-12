using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polygonTaskSchool
{
    public partial class Form1 : Form
    {
        Circle A;
        Triangle B;
        Square C;
        List <Shape> shapes;
        int lastX, lastY;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            A = new Circle(100, 100);
            B = new Triangle(100, 100);
            C = new Square(100, 100);
            shapes = new List<Shape>{A, B, C};
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            
            foreach (Shape shape in shapes)
            {
                shape.Draw(G);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastX = e.X;
            lastY = e.Y;
            bool flag = false;
            foreach (Shape shape in shapes)
            {
                if (shape.IsInside(e.X, e.Y))
                {
                    shape.IsPressed = true;
                    flag = true;

                }
            }
            if(!flag) { shapes.Add(new Circle(e.X, e.Y));  Refresh();}
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape shape in shapes)
            { 
                shape.IsPressed = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int dX = e.X - lastX;
            int dY = e.Y - lastY;
            if (e.Button == MouseButtons.Left)
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.IsPressed == false) { continue; }
                    shape.X += dX;
                    shape.Y += dY;
                }
                lastX = e.X;
                lastY = e.Y;
                Refresh();
            }
        }
    }
}
