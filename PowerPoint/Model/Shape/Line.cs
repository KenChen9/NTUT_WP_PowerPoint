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
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int cursorX, int cursorY)
        {
            const int LINE_WIDTH = 6;
            if (Point1.X == Point2.X)
            {
                return Point1.X - LINE_WIDTH <= cursorX && cursorX <= Point2.X + LINE_WIDTH && Math.Min(Point1.Y, Point2.Y) <= cursorY && cursorY <= Math.Max(Point1.Y, Point2.Y);
            }
            if (Point1.Y == Point2.Y)
            {
                return Point1.Y - LINE_WIDTH <= cursorY && cursorY <= Point2.Y + LINE_WIDTH && Math.Min(Point1.X, Point2.X) <= cursorX && cursorX <= Math.Max(Point1.X, Point2.X);
            }
            double slope = (double)(Point2.Y - Point1.Y) / (Point2.X - Point1.X);
            double rotatedLineWidth = LINE_WIDTH / Math.Cos(Math.Atan(slope));
            double yLine = Point1.Y + slope * (cursorX - Point1.X);
            double yEdgeLine1 = Point1.Y - (cursorX - Point1.X) / slope;
            double yEdgeLine2 = Point2.Y - (cursorX - Point2.X) / slope;
            return yLine - rotatedLineWidth <= cursorY && cursorY <= yLine + rotatedLineWidth && Math.Min(yEdgeLine1, yEdgeLine2) <= cursorY && cursorY <= Math.Max(yEdgeLine1, yEdgeLine2);
        }
    }
}
