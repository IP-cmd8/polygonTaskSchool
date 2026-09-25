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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Pen p = new Pen(Color.Red);
            G.DrawLine(p, 100, 100, 200, 300);
            Pen P1 = new Pen(Color.Blue);
            G.DrawEllipse(P1, 100, 100, 200, 300);
            Circle A = new Circle(100, 100);
            A.Draw(G);
            Triangle B = new Triangle(100, 100);
            B.Draw(G)
        }
    }
    abstract class Shape
    {
        protected int x;
        protected int z;
        protected int y;
        static int R;
        static Color c;
        public Shape(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        static Shape()
        {
            R = 10;
            c = Color.Red;
        }
        public abstract void Draw(Graphics G);
    }

    class Circle : Shape
    {
        public Circle(int xx, int yy) : base(xx, yy) { }
    }

    class Triangle : Shape
    {
        public Triangle(int xx, int yy) : base(xx, yy) { }
    }

    class Square : Shape 
    {
        public Square(int xx, int yy) : base(xx, yy) { }
    }
}
