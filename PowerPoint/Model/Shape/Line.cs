using System;
using System.Drawing;

namespace PowerPoint
{
    public class Line : Shape
    {
        public override string Name
        {
            get
            {
                const string LINE_NAME = "線";
                return LINE_NAME;
            }
        }

        public Line(Point point1, Point point2) : base(point1, point2)
        {
            
        }

        /// <summary>
        /// Draws the line shape.
        /// </summary>
        public override void Draw(IGraphics graphics, bool selected)
        {
            if (selected)
            {
                const int PEN_WIDTH = 2;
                graphics.DrawLine(ShapeColor.Red, PEN_WIDTH, Point1, Point2);
                graphics.DrawLineFrame(PEN_WIDTH, Point1, Point2);
            }
            else
            {
                const int PEN_WIDTH = 1;
                graphics.DrawLine(ShapeColor.Black, PEN_WIDTH, Point1, Point2);
            }
        }

        /// <summary>
        /// IsNearSupportCircle
        /// </summary>
        private bool IsNearSupportCircle(Point cursorPoint)
        {
            const int CLOSENESS_TOLERANCE = 6;
            return GetTwoPointDistance(cursorPoint, Point1) <= CLOSENESS_TOLERANCE || GetTwoPointDistance(cursorPoint, Point2) <= CLOSENESS_TOLERANCE;
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(Point cursorPoint)
        {
            const int LINE_WIDTH = 6;
            if (Point1.X == Point2.X)
            {
                return Point1.X - LINE_WIDTH <= cursorPoint.X && cursorPoint.X <= Point2.X + LINE_WIDTH && Math.Min(Point1.Y, Point2.Y) <= cursorPoint.Y && cursorPoint.Y <= Math.Max(Point1.Y, Point2.Y);
            }
            if (Point1.Y == Point2.Y)
            {
                return Point1.Y - LINE_WIDTH <= cursorPoint.Y && cursorPoint.Y <= Point2.Y + LINE_WIDTH && Math.Min(Point1.X, Point2.X) <= cursorPoint.X && cursorPoint.X <= Math.Max(Point1.X, Point2.X);
            }
            double slope = (double)(Point2.Y - Point1.Y) / (Point2.X - Point1.X);
            double rotatedLineWidth = LINE_WIDTH / Math.Cos(Math.Atan(slope));
            double yLine = Point1.Y + slope * (cursorPoint.X - Point1.X);
            double yEdgeLine1 = Point1.Y - (cursorPoint.X - Point1.X) / slope;
            double yEdgeLine2 = Point2.Y - (cursorPoint.X - Point2.X) / slope;
            bool onLine = yLine - rotatedLineWidth <= cursorPoint.Y && cursorPoint.Y <= yLine + rotatedLineWidth && Math.Min(yEdgeLine1, yEdgeLine2) <= cursorPoint.Y && cursorPoint.Y <= Math.Max(yEdgeLine1, yEdgeLine2);
            return onLine || IsNearSupportCircle(cursorPoint);
        }

        /// <summary>
        /// FindSupportCircleOverlapIndex
        /// </summary>
        public override int FindSupportCircleOverlapIndex(Point cursorPoint)
        {
            const int SUPPORT_CIRCLE_INDEX1 = 1;
            const int SUPPORT_CIRCLE_INDEX2 = 2;
            if (GetTwoPointDistance(cursorPoint, Point1) <= 6)
            {
                return SUPPORT_CIRCLE_INDEX1;
            }
            if (GetTwoPointDistance(cursorPoint, Point2) <= 6)
            {
                return SUPPORT_CIRCLE_INDEX2;
            }
            return -1;
        }
    }
}
