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
    }
    class Shape
    {
        protected int x;
        protected int y;
        static int R;
        static string Color;
        public Shape(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
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
