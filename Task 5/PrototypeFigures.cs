using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PrototypeFigure
{
    class PrototypeFigures
    {
        static void Main(string[] args)
        {
            IFigure figure = new Rectangle(10, 20);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
            figure = new Circle(15);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
            figure = new Triangle(3, 4, 5);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
        }
    }
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} i шириною {1}", height, width);
        }
    }
    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }
        public IFigure Clone()
        {
            return new Circle(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радiусом {0}", radius);
        }
    }

    class Triangle : IFigure
    {
        int a1;
        int a2;
        int a3;

        public Triangle(int a1, int a2, int a3)
        {
            if (a1 + a2 <= a3 || a2 + a3 <= a1 || a1 + a3 <= a2) throw new Exception("Attempt to create invalid Triangle");
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
        }

        public IFigure Clone()
        {
            return new Triangle(a1, a2, a3);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Трикутник зi сторонами {a1}, {a2} i {a3}");
        }
    }
}
