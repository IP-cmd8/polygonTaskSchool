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
    enum ShapeType
    {
        Triangle,
        Circle,
        Square
    }

    public partial class Form1 : Form
    {
        List<Shape> shapes;
        ShapeType currentShape = ShapeType.Circle;
        int lastX, lastY;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            shapes = new List<Shape>();
        }

        private Shape CreateShape(int x, int y)
        {
            switch (currentShape)
            {
                case ShapeType.Triangle:
                    return new Triangle(x, y);
                case ShapeType.Square:
                    return new Square(x, y);
                default:
                    return new Circle(x, y);
            }
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Circle;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Triangle;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Square;
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
            drawHullSlow(G);
        }
        private void drawHullSlow(Graphics e)
        {
            if (shapes.Count >= 3)
            {
                for (int i = 0; i <= shapes.Count - 1; i++)
                {
                    for (int j = i + 1; j <= shapes.Count - 1; j++)
                    {
                        int down = 0;
                        int up = 0;
                        float k = 0;
                        float b = 0;
                        if (shapes[i].X != shapes[j].X)
                        {
                            k = (float)(shapes[i].Y - shapes[j].Y) / (shapes[i].X - shapes[j].X);
                            b = (shapes[i].Y - k * shapes[i].X);

                            for (int p = 0; p <= shapes.Count - 1; p++)
                            {
                                if (p == i || p == j) { continue; }
                                else if (k * shapes[p].X + b > shapes[p].Y) { up += 1; }
                                else if (k * shapes[p].X + b < shapes[p].Y) { down += 1; }
                            }
                            if (up == 0 || down == 0)
                            {
                                e.DrawLine(new Pen(Color.Red), (float)shapes[i].X, shapes[i].Y, shapes[j].X, shapes[j].Y);
                            }
                        }
                        else
                        {
                            for (int p = 0; p <= shapes.Count - 1; p++)
                            {
                                if (p == i || p == j) { continue; }
                                else if (shapes[p].X > shapes[i].X) { up += 1; }
                                else if (shapes[p].X < shapes[i].X) { down += 1; }
                            }
                            if (up == 0 || down == 0)
                            {
                                e.DrawLine(new Pen(Color.Red), (float)shapes[i].X, shapes[i].Y, shapes[j].X, shapes[j].Y);
                            }
                            {

                            }
                        }

                    }
                }
            }
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
                if (!flag)
                {
                    shapes.Add(CreateShape(e.X, e.Y));
                    Refresh();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                bool flag = false;
                for (int i = shapes.Count - 1; i >= 0; i--)
                {
                    if (shapes[i].IsInside(e.X, e.Y))
                    {
                        shapes.RemoveAt(i);
                        Refresh();
                        break;
                    }

                }
            }
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