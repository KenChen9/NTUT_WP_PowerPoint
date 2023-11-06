using System;

namespace PowerPoint
{
    /// <summary>
    /// Represents a rectangle shape in a PowerPoint presentation.
    /// </summary>
    public class MyRectangle : Shape
    {
        /// <summary>
        /// Gets the name of the rectangle shape, which is "矩形".
        /// </summary>
        public override string Name
        {
            get
            {
                return "矩形";
            }
        }

        /// <summary>
        /// Initializes a new instance of the MyRectangle class with specified coordinates.
        /// </summary>
        /// <param name="x1">The x-coordinate of the top-left corner.</param>
        /// <param name="y1">The y-coordinate of the top-left corner.</param>
        /// <param name="x2">The x-coordinate of the bottom-right corner.</param>
        /// <param name="y2">The y-coordinate of the bottom-right corner.</param>
        public MyRectangle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
            // Constructor logic, if any.
        }

        /// <summary>
        /// Draws the rectangle shape.
        /// </summary>
        public override void Draw(IGraphics graphics, bool selected)
        {
            if (selected)
            {
                int penWidth = 2;
                graphics.DrawRectangle(ShapeColor.Red, penWidth, _x1, _y1, _x2, _y2);
                int smallCircleRadius = 4;
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x1 - smallCircleRadius, _y1 - smallCircleRadius, _x1 + smallCircleRadius, _y1 + smallCircleRadius);
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x1 - smallCircleRadius, _y2 - smallCircleRadius, _x1 + smallCircleRadius, _y2 + smallCircleRadius);
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x2 - smallCircleRadius, _y1 - smallCircleRadius, _x2 + smallCircleRadius, _y1 + smallCircleRadius);
                graphics.DrawCircle(ShapeColor.Red, penWidth, _x2 - smallCircleRadius, _y2 - smallCircleRadius, _x2 + smallCircleRadius, _y2 + smallCircleRadius);
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
                graphics.DrawRectangle(ShapeColor.Black, penWidth, _x1, _y1, _x2, _y2);
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int x, int y)
        {
            return _x1 <= x && x <= _x2 && _y1 <= y && y <= _y2;
        }
    }
}
