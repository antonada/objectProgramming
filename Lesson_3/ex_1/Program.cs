using System;
using System.Collections.Generic;

namespace ex_1
{
    class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine($"Drawing a generic shape at ({X}, {Y}) with height {Height} and width {Width}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Rectangle(0, 0, 5, 10));
            shapes.Add(new Triangle(0, 0, 5, 10));
            shapes.Add(new Circle(0, 5, 10));

            foreach (var shape in shapes)
            {
                shape.Draw();
                Console.WriteLine();
            }

        }
    }

    class Rectangle : Shape
    {
        public Rectangle(int x, int y, int height, int width)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a rectangle at ({X}, {Y}) with height {Height} and width {Width}");
        }
    }

    class Triangle : Shape
    {
        public Triangle(int x, int y, int height, int width)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a Triangle at ({X}, {Y}) with height {Height} and width {Width}");
        }
    }

    class Circle : Shape
    {
        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Height = radius * 2;
            Width = radius * 2;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a Circle at ({X}, {Y}) with radius {Height / 2}");
        }
    }
}
