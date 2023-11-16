using System;
using System.Drawing;

namespace PowerPoint
{
    public class Circle : Shape
    {
        public override string Name
        {
            get
            {
                const string CIRCLE_NAME = "圓";
                return CIRCLE_NAME;
            }
        }

        public Circle(Point point1, Point point2) : base(GetTopLeftPoint(point1, point2), GetBottomRightPoint(point1, point2))
        {

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

        /// <summary>
        /// Draws the circle shape.
        /// </summary>
        public override void Draw(IGraphics graphics, bool selected)
        {
            if (selected)
            {
                const int PEN_WIDTH = 2;
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, Point1, Point2);
                graphics.DrawCircleFrame(PEN_WIDTH, Point1, Point2);
            }
            else
            {
                const int PEN_WIDTH = 1;
                graphics.DrawCircle(ShapeColor.Black, PEN_WIDTH, Point1, Point2);
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int cursorX, int cursorY)
        {
            const int ONE = 1;
            const int TWO = 2;
            double centerX = (Point1.X + Point2.X) / TWO;
            double centerY = (Point1.Y + Point2.Y) / TWO;
            double horizontalRadius = Math.Abs(Point1.X - Point2.X) / TWO;
            double verticalRadius = Math.Abs(Point1.Y - Point2.Y) / TWO;
            return Math.Pow((cursorX - centerX) / horizontalRadius, TWO) + Math.Pow((cursorY - centerY) / verticalRadius, TWO) <= ONE;
        }
    }
}
