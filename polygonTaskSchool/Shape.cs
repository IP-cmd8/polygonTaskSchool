using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polygonTaskSchool
{
    using System;
    using System.Drawing;
    using System.Security.AccessControl;

    abstract class Shape
    {
        protected int x;
        protected int y;
        protected static int R;
        protected static Color c;
        protected static Pen p;
        public Shape(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        static Shape()
        {
            R = 100;
            c = Color.Red;
            p = new Pen(c);
        }
        public abstract void Draw(Graphics G);
        public abstract bool IsInside(int x, int y);
        public int X{
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    class Circle : Shape
    {
        public Circle(int xx, int yy) : base(xx, yy) { }
        public override void Draw(Graphics G)
        {
            G.DrawEllipse(p, x - R, y - R, R*2, R*2);
        }
        public override bool IsInside(int xx, int yy)
        {
            if ((xx - x)* (xx-x)+ (yy-y) * (yy-y) <= (R * R))
            {
                return true;
            }
            return false;
        }
    }

    class Triangle : Shape
    {
        public Triangle(int xx, int yy) : base(xx, yy) { }
        public override void Draw(Graphics G)
        {
            G.DrawPolygon(p, new PointF[] {new PointF(x,y-R), new PointF(x-R * (float)Math.Sqrt(3)/2,y + R/2), new PointF(x + R * (float)Math.Sqrt(3) / 2, y + R / 2) }); //x = X + Rcos0, y = Y + Rsin0
        }
        public override bool IsInside(int xx, int yy)
        {
            PointF vertexOne = new Point(x,y - R);
            PointF vertexTwo = new PointF(x - R * (float)Math.Sqrt(3) / 2, y + R / 2);
            PointF vertexThree = new PointF(x + R * (float)Math.Sqrt(3) / 2, y + R / 2);
            PointF mouseP = new PointF(xx, yy);

            float areaABC = calculateHerons(vertexOne, vertexTwo, vertexThree);
            float areaABP = calculateHerons(vertexOne, vertexTwo, mouseP);
            float areaBCP = calculateHerons(vertexTwo, vertexThree, mouseP);
            float areaCAP = calculateHerons(vertexThree, vertexOne, mouseP);

            if (Math.Abs(areaABC - (areaABP + areaBCP + areaCAP)) < 0.01f)
            {
                return true;
            }
            return false;
        }
        private float calculateHerons(PointF vertex1, PointF vertex2, PointF vertex3)
        {
            float ab = (float)Math.Sqrt((vertex1.X - vertex2.X) * (vertex1.X - vertex2.X) + (vertex1.Y - vertex2.Y) * (vertex1.Y - vertex2.Y));
            float bc = (float)Math.Sqrt((vertex2.X - vertex3.X) * (vertex2.X - vertex3.X) + (vertex2.Y - vertex3.Y) * (vertex2.Y - vertex3.Y));
            float ca = (float)Math.Sqrt((vertex3.X - vertex1.X) * (vertex3.X - vertex1.X) + (vertex3.Y - vertex1.Y) * (vertex3.Y - vertex1.Y));
            float p = (ab + bc + ca) / 2;
            return (float)Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca));
        }
    }

    class Square : Shape
    {
        public Square(int xx, int yy) : base(xx, yy) { }
        public override void Draw(Graphics G)
        {
            float sideLength = R * (float)Math.Sqrt(2);
            G.DrawRectangle(p, -sideLength/2 + x, -sideLength/2 + y,sideLength,sideLength);
        }
        public override bool IsInside(int xx, int yy)
        {
            float sideLength = R * (float)Math.Sqrt(2);
            if (Math.Abs(xx - x) <= sideLength/2 && Math.Abs(yy - y) <= sideLength/2)
            {
                return true;
            }
            return false;
        }
    }
}
