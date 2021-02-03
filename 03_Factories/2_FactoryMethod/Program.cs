using System;

namespace _2_FactoryMethod
{
    internal class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // not aligned with separation of concerns principle
        public static Point NewCartesianPoint(double x, double y) => new Point(x, y);

        // not aligned with separation of concerns principle
        public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));

        public override string ToString() => $"{nameof(x)}: {x}, {nameof(y)}: {y}";
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);

            Console.WriteLine(point);
        }
    }
}