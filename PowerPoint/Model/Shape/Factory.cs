using System;

namespace PowerPoint
{
    /// <summary>
    /// Factory class responsible for creating different types of shapes in a PowerPoint presentation.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Creates a shape based on the provided shape type string.
        /// </summary>
        /// <param name="shapeType">String representation of the shape type (線, 矩形, or 圓).</param>
        /// <returns>A Shape object based on the specified shape type, or null if the type is not recognized.</returns>
        public static Shape CreateShape(string shapeType)
        {
            const string LINE = "線";
            const string RECTANGLE = "矩形";
            const string CIRCLE = "圓";
            switch (shapeType)
            {
                case LINE:
                    return CreateShape(ShapeType.Line);
                case RECTANGLE:
                    return CreateShape(ShapeType.Rectangle);
                case CIRCLE:
                    return CreateShape(ShapeType.Circle);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Creates a shape with random coordinates based on the specified shape type.
        /// </summary>
        /// <param name="shapeType">Type of the shape to create.</param>
        /// <returns>A Shape object with random coordinates based on the specified shape type.</returns>
        public static Shape CreateShape(ShapeType shapeType)
        {
            const int RANDOM_MIN = 0;
            const int RANDOM_MAX = 500;
            Random random = new Random();
            int x1 = random.Next(RANDOM_MIN, RANDOM_MAX);
            int y1 = random.Next(RANDOM_MIN, RANDOM_MAX);
            int x2 = random.Next(RANDOM_MIN, RANDOM_MAX);
            int y2 = random.Next(RANDOM_MIN, RANDOM_MAX);
            return CreateShape(shapeType, x1, y1, x2, y2);
        }

        /// <summary>
        /// Creates a shape with specified coordinates based on the specified shape type.
        /// </summary>
        /// <param name="shapeType">Type of the shape to create.</param>
        /// <param name="x1">X-coordinate of the starting point.</param>
        /// <param name="y1">Y-coordinate of the starting point.</param>
        /// <param name="x2">X-coordinate of the ending point.</param>
        /// <param name="y2">Y-coordinate of the ending point.</param>
        /// <returns>A Shape object with specified coordinates based on the specified shape type.</returns>
        public static Shape CreateShape(ShapeType shapeType, int x1, int y1, int x2, int y2)
        {
            int topLeftX = Math.Min(x1, x2);
            int topLeftY = Math.Min(y1, y2);
            int bottomRightX = Math.Max(x1, x2);
            int bottomRightY = Math.Max(y1, y2);
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line(x1, y1, x2, y2);
                case ShapeType.Rectangle:
                    return new MyRectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);
                case ShapeType.Circle:
                    return new Circle(topLeftX, topLeftY, bottomRightX, bottomRightY);
                default:
                    return null;
            }
        }
    }
}
