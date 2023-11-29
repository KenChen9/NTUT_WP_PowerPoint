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
                const int PEN_WIDTH = 1;
                graphics.DrawRectangle(ShapeColor.Black, PEN_WIDTH, Point1, Point2);
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(Point cursorPoint)
        {
            return Point1.X <= cursorPoint.X && cursorPoint.X <= Point2.X && Point1.Y <= cursorPoint.Y && cursorPoint.Y <= Point2.Y;
        }

        /// <summary>
        /// FindSupportCircleOverlapIndex
        /// </summary>
        public override int FindSupportCircleOverlapIndex(Point cursorPoint)
        {
            const int SUPPORT_CIRCLE_INDEX2 = 2;
            return GetTwoPointDistance(cursorPoint, Point2) <= 6 ? SUPPORT_CIRCLE_INDEX2 : -1;
        }
    }
}
