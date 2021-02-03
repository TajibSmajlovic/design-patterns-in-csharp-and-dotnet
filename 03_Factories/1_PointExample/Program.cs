using System;

namespace _1_PointExample
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public class Point
    {
        private double x, y;

        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(double a,
          double b, // names do not communicate intent
          CoordinateSystem cs = CoordinateSystem.Cartesian)
        {
            switch (cs)
            {
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;

                default:
                    x = a;
                    y = b;
                    break;
            }

            // steps to add a new system
            // 1. augment CoordinateSystem
            // 2. change ctor
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var p1 = new Point(2, 3, CoordinateSystem.Cartesian);
        }
    }
}