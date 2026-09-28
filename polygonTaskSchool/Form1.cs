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
        public Form1()
        {
            InitializeComponent();
            A = new Circle(100, 100);
            B = new Triangle(100, 100);
            C = new Square(100, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            A.Draw(G);
            B.Draw(G);
            C.Draw(G);
        }
    }
}
