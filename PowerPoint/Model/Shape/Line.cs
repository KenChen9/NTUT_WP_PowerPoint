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
        /// Draws the line shape using the specified graphics object and shape color.
        /// </summary>
        /// <param name="graphics">The IGraphics object used for drawing.</param>
        /// <param name="shapeColor">The color of the line shape.</param>
        public override void Draw(IGraphics graphics, ShapeColor shapeColor)
        {
            graphics.DrawLine(shapeColor, _x1, _y1, _x2, _y2);
        }
    }
}
