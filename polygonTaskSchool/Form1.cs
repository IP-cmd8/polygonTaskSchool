using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Shape[] shapes;
        Shape[] selectedShapes;
        int lastX, lastY;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            A = new Circle(100, 100);
            B = new Triangle(100, 100);
            C = new Square(100, 100);
            shapes =  new Shape[] { A, B, C };
            selectedShapes = new Shape[3];
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
            int k = 0;
            lastX = e.X;
            lastY = e.Y;
            foreach (Shape shape in shapes)
            {
                if (shape.IsInside(e.X, e.Y))
                {
                    selectedShapes[k] = shape;
                    k++;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < selectedShapes.Length; i++)
            {
                selectedShapes[i] = null;   
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int dX = e.X - lastX;
            int dY = e.Y - lastY;
            if (e.Button == MouseButtons.Left)
            {
                foreach (Shape shape in selectedShapes)
                {
                    if (shape == null) { continue; }
                    shape.X += e.X - lastX;
                    shape.Y += e.Y - lastY;
                }
                lastX = e.X;
                lastY = e.Y;
                Refresh();
            }
        }
    }
}
