using System;
using System.Drawing;

namespace PowerPoint
{
    /// <summary>
    /// Represents a line shape in a PowerPoint presentation.
    /// </summary>
    public class Line : Shape
    {
        /// <summary>
        /// Gets the name of the line shape, which is "線".
        /// </summary>
        public override string Name
        {
            get
            {
                const string LINE = "線";
                return LINE;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Line class with specified coordinates.
        /// </summary>
        /// <param name="x1">The x-coordinate of the starting point.</param>
        /// <param name="y1">The y-coordinate of the starting point.</param>
        /// <param name="x2">The x-coordinate of the ending point.</param>
        /// <param name="y2">The y-coordinate of the ending point.</param>
        public Line(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
            // Constructor logic, if any.
        }

        /// <summary>
        /// Draws the line shape.
        /// </summary>
        public override void Draw(IGraphics graphics, bool selected)
        {
            if (selected)
            {
                const int PEN_WIDTH = 2;
                graphics.DrawLine(ShapeColor.Red, PEN_WIDTH, new Point(_x1, _y1), new Point(_x2, _y2));
                const int SMALL_CIRCLE_RADIUS = 4;
                const int TWO = 2;
                int centerX = (_x1 + _x2) / TWO;
                int centerY = (_y1 + _y2) / TWO;
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, new Point(_x1 - SMALL_CIRCLE_RADIUS, _y1 - SMALL_CIRCLE_RADIUS), new Point(_x1 + SMALL_CIRCLE_RADIUS, _y1 + SMALL_CIRCLE_RADIUS));
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, new Point(_x2 - SMALL_CIRCLE_RADIUS, _y2 - SMALL_CIRCLE_RADIUS), new Point(_x2 + SMALL_CIRCLE_RADIUS, _y2 + SMALL_CIRCLE_RADIUS));
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, new Point(centerX - SMALL_CIRCLE_RADIUS, centerY - SMALL_CIRCLE_RADIUS), new Point(centerX + SMALL_CIRCLE_RADIUS, centerY + SMALL_CIRCLE_RADIUS));
            }
            else
            {
                const int PEN_WIDTH = 1;
                graphics.DrawLine(ShapeColor.Black, PEN_WIDTH, new Point(_x1, _y1), new Point(_x2, _y2));
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int cursorX, int cursorY)
        {
            const int LINE_WIDTH = 6;
            double lineWidth = LINE_WIDTH;
            if (_x1 == _x2)
            {
                return _x1 - lineWidth <= cursorX && cursorX <= _x2 + lineWidth && Math.Min(_y1, _y2) <= cursorY && cursorY <= Math.Max(_y1, _y2);
            }
            if (_y1 == _y2)
            {
                return _y1 - lineWidth <= cursorY && cursorY <= _y2 + lineWidth && Math.Min(_x1, _x2) <= cursorX && cursorX <= Math.Max(_x1, _x2);
            }
            double slope = (double)(_y2 - _y1) / (_x2 - _x1);
            lineWidth /= Math.Cos(Math.Atan(slope));
            double yLine = _y1 + slope * (cursorX - _x1);
            double yEdgeLine1 = _y1 - (cursorX - _x1) / slope;
            double yEdgeLine2 = _y2 - (cursorX - _x2) / slope;
            return yLine - lineWidth <= cursorY && cursorY <= yLine + lineWidth && Math.Min(yEdgeLine1, yEdgeLine2) <= cursorY && cursorY <= Math.Max(yEdgeLine1, yEdgeLine2);
        }
    }
}
