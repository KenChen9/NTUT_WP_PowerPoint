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
        /// Draws the rectangle shape using the specified graphics object and shape color.
        /// </summary>
        /// <param name="graphics">The IGraphics object used for drawing.</param>
        /// <param name="shapeColor">The color of the rectangle shape.</param>
        public override void Draw(IGraphics graphics, ShapeColor shapeColor)
        {
            graphics.DrawRectangle(shapeColor, _x1, _y1, _x2, _y2);
        }
    }
}
