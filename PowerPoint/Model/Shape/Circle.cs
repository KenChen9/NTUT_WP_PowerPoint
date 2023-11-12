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
                const string CIRCLE = "圓";
                return CIRCLE;
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
                const int PEN_WIDTH = 2;
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, _x1, _y1, _x2, _y2);
                const int SMALL_CIRCLE_RADIUS = 4;
                const int TWO = 2;
                int centerX = (_x1 + _x2) / TWO;
                int centerY = (_y1 + _y2) / TWO;
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, centerX - SMALL_CIRCLE_RADIUS, _y1 - SMALL_CIRCLE_RADIUS, centerX + SMALL_CIRCLE_RADIUS, _y1 + SMALL_CIRCLE_RADIUS);
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, centerX - SMALL_CIRCLE_RADIUS, _y2 - SMALL_CIRCLE_RADIUS, centerX + SMALL_CIRCLE_RADIUS, _y2 + SMALL_CIRCLE_RADIUS);
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, _x1 - SMALL_CIRCLE_RADIUS, centerY - SMALL_CIRCLE_RADIUS, _x1 + SMALL_CIRCLE_RADIUS, centerY + SMALL_CIRCLE_RADIUS);
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, _x2 - SMALL_CIRCLE_RADIUS, centerY - SMALL_CIRCLE_RADIUS, _x2 + SMALL_CIRCLE_RADIUS, centerY + SMALL_CIRCLE_RADIUS);
            }
            else
            {
                const int PEN_WIDTH = 1;
                graphics.DrawCircle(ShapeColor.Black, PEN_WIDTH, _x1, _y1, _x2, _y2);
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int x, int y)
        {
            const int ONE = 1;
            const int TWO = 2;
            double h = (_x1 + _x2) / TWO;
            double k = (_y1 + _y2) / TWO;
            double a = Math.Abs(_x1 - _x2) / TWO;
            double b = Math.Abs(_y1 - _y2) / TWO;
            return Math.Pow((x - h) / a, TWO) + Math.Pow((y - k) / b, TWO) <= ONE;
        }
    }
}
