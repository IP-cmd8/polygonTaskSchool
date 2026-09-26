using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polygonTaskSchool
{
    using System;
    using System.Drawing;

    abstract class Shape
    {
        protected int x;
        protected int z;
        protected int y;
        protected static int R;
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
        public override void Draw(Graphics G)
        {
            Pen p = new Pen(Color.Black);
            G.DrawEllipse(p, x - R, y - R, R*2, R*2);
        }
    }

    class Triangle : Shape
    {
        public Triangle(int xx, int yy) : base(xx, yy) { }
        public override void Draw(Graphics G)
        {
            Pen p = new Pen(Color.Black);
            G.DrawPolygon(p, new PointF[] {new PointF(x,y-R), new PointF(x-R * (float)Math.Sqrt(3)/2,y + R/2), new PointF(x + R * (float)Math.Sqrt(3) / 2, y + R / 2) }); //x = X + Rcos0, y = Y + Rsin0
        }
    }

    class Square : Shape
    {
        public Square(int xx, int yy) : base(xx, yy) { }
        public override void Draw(Graphics G)
        {
            float sideLength = R * (float)Math.Sqrt(2);
            Pen p = new Pen(Color.Black);
            G.DrawRectangle(p, -sideLength/2 + x, -sideLength/2 + y,sideLength,sideLength);
        }
    }
}
