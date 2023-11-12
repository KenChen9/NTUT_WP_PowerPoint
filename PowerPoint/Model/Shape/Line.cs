using System;

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
                graphics.DrawLine(ShapeColor.Red, PEN_WIDTH, _x1, _y1, _x2, _y2);
                const int SMALL_CIRCLE_RADIUS = 4;
                const int TWO = 2;
                int centerX = (_x1 + _x2) / TWO;
                int centerY = (_y1 + _y2) / TWO;
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, _x1 - SMALL_CIRCLE_RADIUS, _y1 - SMALL_CIRCLE_RADIUS, _x1 + SMALL_CIRCLE_RADIUS, _y1 + SMALL_CIRCLE_RADIUS);
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, _x2 - SMALL_CIRCLE_RADIUS, _y2 - SMALL_CIRCLE_RADIUS, _x2 + SMALL_CIRCLE_RADIUS, _y2 + SMALL_CIRCLE_RADIUS);
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, centerX - SMALL_CIRCLE_RADIUS, centerY - SMALL_CIRCLE_RADIUS, centerX + SMALL_CIRCLE_RADIUS, centerY + SMALL_CIRCLE_RADIUS);
            }
            else
            {
                const int PEN_WIDTH = 1;
                graphics.DrawLine(ShapeColor.Black, PEN_WIDTH, _x1, _y1, _x2, _y2);
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int x, int y)
        {
            const int LINE_WIDTH = 6;
            double w = LINE_WIDTH;
            if (_x1 == _x2)
            {
                return _x1 - w <= x && x <= _x2 + w && Math.Min(_y1, _y2) <= y && y <= Math.Max(_y1, _y2);
            }
            if (_y1 == _y2)
            {
                return _y1 - w <= y && y <= _y2 + w && Math.Min(_x1, _x2) <= x && x <= Math.Max(_x1, _x2);
            }
            double m = (double)(_y2 - _y1) / (_x2 - _x1);
            w /= Math.Cos(Math.Atan(m));
            double yLine = _y1 + m * (x - _x1);
            double yEdgeLine1 = _y1 - (x - _x1) / m;
            double yEdgeLine2 = _y2 - (x - _x2) / m;
            return yLine - w <= y && y <= yLine + w && Math.Min(yEdgeLine1, yEdgeLine2) <= y && y <= Math.Max(yEdgeLine1, yEdgeLine2);
        }
    }
}
