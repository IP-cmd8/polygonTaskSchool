using System;
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