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
        /// Draws the circle shape using the specified graphics object and shape color.
        /// </summary>
        /// <param name="graphics">The IGraphics object used for drawing.</param>
        /// <param name="shapeColor">The color of the circle shape.</param>
        public override void Draw(IGraphics graphics, ShapeColor shapeColor)
        {
            graphics.DrawCircle(shapeColor, _x1, _y1, _x2, _y2);
        }
    }
}
