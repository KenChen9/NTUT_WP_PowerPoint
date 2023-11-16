using System;
using System.Drawing;

namespace PowerPoint
{
    public class MyRectangle : Shape
    {
        public override string Name
        {
            get
            {
                const string RECTANGLE_NAME = "矩形";
                return RECTANGLE_NAME;
            }
        }

        public MyRectangle(Point point1, Point point2) : base(GetTopLeftPoint(point1, point2), GetBottomRightPoint(point1, point2))
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
        /// Draws the rectangle shape.
        /// </summary>
        public override void Draw(IGraphics graphics, bool selected)
        {
            if (selected)
            {
                const int PEN_WIDTH = 2;
                graphics.DrawRectangle(ShapeColor.Red, PEN_WIDTH, Point1, Point2);
                graphics.DrawRectangleFrame(PEN_WIDTH, Point1, Point2);
            }
            else
            {
                int penWidth = 1;
                graphics.DrawRectangle(ShapeColor.Black, penWidth, Point1, Point2);
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int cursorX, int cursorY)
        {
            return Point1.X <= cursorX && cursorX <= Point2.X && Point1.Y <= cursorY && cursorY <= Point2.Y;
        }
    }
}
