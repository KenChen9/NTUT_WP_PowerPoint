using System;
using System.Drawing;

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
                const string RECTANGLE = "矩形";
                return RECTANGLE;
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
                const int PEN_WIDTH = 2;
                graphics.DrawRectangle(ShapeColor.Red, PEN_WIDTH, new Point(_x1, _y1), new Point(_x2, _y2));
                graphics.DrawRectangleSupportCircles(ShapeColor.Red, PEN_WIDTH, new Point(_x1, _y1), new Point(_x2, _y2));
            }
            else
            {
                int penWidth = 1;
                graphics.DrawRectangle(ShapeColor.Black, penWidth, new Point(_x1, _y1), new Point(_x2, _y2));
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int cursorX, int cursorY)
        {
            return _x1 <= cursorX && cursorX <= _x2 && _y1 <= cursorY && cursorY <= _y2;
        }
    }
}
