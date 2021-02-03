using System;

namespace _04_InnerFactory
{
    internal class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"{nameof(x)}: {x}, {nameof(y)}: {y}";

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y) => new Point(x, y);

            public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);

            Console.WriteLine(point);
        }
    }
}