using System;

namespace _3_Factory
{
    internal class Point
    {
        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"{nameof(x)}: {x}, {nameof(y)}: {y}";
    }

    internal static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y) => new Point(x, y);

        public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var point = new Point(1, 2); // can't initialize Polar point
        }
    }
}