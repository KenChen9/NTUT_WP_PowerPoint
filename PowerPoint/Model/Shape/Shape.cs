namespace PowerPoint
{
    /// <summary>
    /// Abstract base class representing a shape in a PowerPoint presentation.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// X-coordinate of the first point defining the shape.
        /// </summary>
        protected int _x1;

        /// <summary>
        /// Y-coordinate of the first point defining the shape.
        /// </summary>
        protected int _y1;

        /// <summary>
        /// X-coordinate of the second point defining the shape.
        /// </summary>
        protected int _x2;

        /// <summary>
        /// Y-coordinate of the second point defining the shape.
        /// </summary>
        protected int _y2;

        /// <summary>
        /// Gets the information about the shape's coordinates in the format "(x1, y1), (x2, y2)".
        /// </summary>
        public string Information
        {
            get
            {
                const string FORMAT_PART1 = "(";
                const string FORMAT_PART2 = ", ";
                const string FORMAT_PART3 = "), (";
                const string FORMAT_PART4 = ", ";
                const string FORMAT_PART5 = ")";
                return FORMAT_PART1 + _x1 + FORMAT_PART2 + _y1 + FORMAT_PART3 + _x2 + FORMAT_PART4 + _y2 + FORMAT_PART5;
            }
        }

        /// <summary>
        /// Gets the name of the shape.
        /// </summary>
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of the Shape class with specified coordinates.
        /// </summary>
        /// <param name="x1">X-coordinate of the first point.</param>
        /// <param name="y1">Y-coordinate of the first point.</param>
        /// <param name="x2">X-coordinate of the second point.</param>
        /// <param name="y2">Y-coordinate of the second point.</param>
        protected Shape(int x1, int y1, int x2, int y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        /// <summary>
        /// MoveDelta
        /// </summary>
        public void MoveDelta(int deltaX, int deltaY)
        {
            _x1 += deltaX;
            _y1 += deltaY;
            _x2 += deltaX;
            _y2 += deltaY;
        }

        /// <summary>
        /// Draws the shape using the specified graphics object and shape color.
        /// </summary>
        /// <param name="graphics">The IGraphics object used for drawing.</param>
        /// <param name="shapeColor">The color of the shape.</param>
        public abstract void Draw(IGraphics graphics, bool selected);

        /// <summary>
        /// IsOverlap
        /// </summary>
        public abstract bool IsOverlap(int cursorX, int cursorY);
    }
}
