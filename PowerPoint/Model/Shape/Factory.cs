using System;
using System.Drawing;

namespace PowerPoint
{
    public static class Factory
    {
        /// <summary>
        /// Creates a shape based on the provided shape type string.
        /// </summary>
        public static Shape CreateShape(string shapeType)
        {
            const string LINE_NAME = "線";
            const string RECTANGLE_NAME = "矩形";
            const string CIRCLE_NAME = "圓";
            switch (shapeType)
            {
                case LINE_NAME:
                    return CreateShape(ShapeType.Line);
                case RECTANGLE_NAME:
                    return CreateShape(ShapeType.Rectangle);
                case CIRCLE_NAME:
                    return CreateShape(ShapeType.Circle);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Creates a shape with random coordinates based on the specified shape type.
        /// </summary>
        public static Shape CreateShape(ShapeType shapeType)
        {
            const int RANDOM_MIN = 0;
            const int RANDOM_MAX = 500;
            Random random = new Random();
            Point point1 = new Point(random.Next(RANDOM_MIN, RANDOM_MAX), random.Next(RANDOM_MIN, RANDOM_MAX));
            Point point2 = new Point(random.Next(RANDOM_MIN, RANDOM_MAX), random.Next(RANDOM_MIN, RANDOM_MAX));
            return CreateShape(shapeType, point1, point2);
        }

        /// <summary>
        /// Creates a shape with specified coordinates based on the specified shape type.
        /// </summary>
        public static Shape CreateShape(ShapeType shapeType, Point point1, Point point2)
        {
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line(GetTopLeftPoint(point1, point2), GetBottomRightPoint(point1, point2));
                case ShapeType.Rectangle:
                    return new MyRectangle(GetTopLeftPoint(point1, point2), GetBottomRightPoint(point1, point2));
                case ShapeType.Circle:
                    return new Circle(GetTopLeftPoint(point1, point2), GetBottomRightPoint(point1, point2));
                default:
                    return null;
            }
        }

        /// <summary>
        /// GetTopLeftPoint
        /// </summary>
        private static Point GetTopLeftPoint(Point point1, Point point2)
        {
            return new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
        }

        /// <summary>
        /// GetBottomRightPoint
        /// </summary>
        private static Point GetBottomRightPoint(Point point1, Point point2)
        {
            return new Point(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
        }
    }
}
