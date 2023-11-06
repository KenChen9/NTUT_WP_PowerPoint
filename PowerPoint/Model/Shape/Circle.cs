using System;

namespace PowerPoint
{
    /// <summary>
    /// Represents a circle shape in a PowerPoint presentation.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Gets the name of the circle shape, which is "圓".
        /// </summary>
        public override string Name
        {
            get
            {
                return "圓";
            }
        }

        /// <summary>
        /// Initializes a new instance of the Circle class with specified coordinates.
        /// </summary>
        /// <param name="x1">The x-coordinate of the starting point.</param>
        /// <param name="y1">The y-coordinate of the starting point.</param>
        /// <param name="x2">The x-coordinate of the ending point.</param>
        /// <param name="y2">The y-coordinate of the ending point.</param>
        public Circle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
            // Constructor logic, if any.
        }

        /// <summary>
        /// Draws the circle shape.
        /// </summary>
        public override void Draw(IGraphics graphics, bool selected)
        {
            if (selected)
            {
                int penWidth = 2;
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x1, _y1, _x2, _y2);
                int smallCircleRadius = 4;
                int centerX = (_x1 + _x2) / 2;
                int centerY = (_y1 + _y2) / 2;
                graphics.DrawCircle(ShapeColor.Red, penWidth, centerX - smallCircleRadius, _y1 - smallCircleRadius, centerX + smallCircleRadius, _y1 + smallCircleRadius);
                graphics.DrawCircle(ShapeColor.Red, penWidth, centerX - smallCircleRadius, _y2 - smallCircleRadius, centerX + smallCircleRadius, _y2 + smallCircleRadius);
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x1 - smallCircleRadius, centerY - smallCircleRadius, _x1 + smallCircleRadius, centerY + smallCircleRadius);
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x2 - smallCircleRadius, centerY - smallCircleRadius, _x2 + smallCircleRadius, centerY + smallCircleRadius);
            }
            else
            {
                int penWidth = 1;
                graphics.DrawCircle(ShapeColor.Black, penWidth, _x1, _y1, _x2, _y2);
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int x, int y)
        {
            double h = (_x1 + _x2) / 2;
            double k = (_y1 + _y2) / 2;
            double a = Math.Abs(_x1 - _x2) / 2;
            double b = Math.Abs(_y1 - _y2) / 2;
            return Math.Pow((x - h) / a, 2) + Math.Pow((y - k) / b, 2) <= 1;
        }
    }
}
