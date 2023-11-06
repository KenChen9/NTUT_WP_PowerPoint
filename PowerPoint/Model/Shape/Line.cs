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
                return "線";
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
                int penWidth = 2;
                graphics.DrawLine(ShapeColor.Red, penWidth, _x1, _y1, _x2, _y2);
                int smallCircleRadius = 4;
                int centerX = (_x1 + _x2) / 2;
                int centerY = (_y1 + _y2) / 2;
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x1 - smallCircleRadius, _y1 - smallCircleRadius, _x1 + smallCircleRadius, _y1 + smallCircleRadius);
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x2 - smallCircleRadius, _y2 - smallCircleRadius, _x2 + smallCircleRadius, _y2 + smallCircleRadius);
                graphics.DrawCircle(ShapeColor.Red, penWidth, centerX - smallCircleRadius, centerY - smallCircleRadius, centerX + smallCircleRadius, centerY + smallCircleRadius);
            }
            else
            {
                int penWidth = 1;
                graphics.DrawLine(ShapeColor.Black, penWidth, _x1, _y1, _x2, _y2);
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int x, int y)
        {
            if (_x1 == _x2)
            {
                return Math.Min(_y1, _y2) <= y && y <= Math.Max(_y1, _y2);
            }
            if (_y1 == _y2)
            {
                return Math.Min(_x1, _x2) <= x && x <= Math.Max(_x1, _x2);
            }
            double m1 = (double)(_y2 - _y1) / (_x2 - _x1);
            double m2 = -1 / m1;
            double d = Math.Abs(x - _x1 - (y - _y1) / m1);
            double y3 = _y1 + m2 * (x - _x1);
            double y4 = _y2 + m2 * (x - _x2);
            return d <= 10 && Math.Min(y3, y4) <= y && y <= Math.Max(y3, y4);
        }
    }
}
