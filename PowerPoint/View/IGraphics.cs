using System.Drawing;

namespace PowerPoint
{
    /// <summary>
    /// Interface for drawing shapes with specified color and coordinates.
    /// </summary>
    public interface IGraphics
    {
        /// <summary>
        /// Draws a line with the specified shape color and coordinates.
        /// </summary>
        /// <param name="shapeColor">Color of the line.</param>
        /// <param name="x1">X-coordinate of the starting point.</param>
        /// <param name="y1">Y-coordinate of the starting point.</param>
        /// <param name="x2">X-coordinate of the ending point.</param>
        /// <param name="y2">Y-coordinate of the ending point.</param>
        void DrawLine(ShapeColor shapeColor, int penWidth, Point point1, Point point2);

        /// <summary>
        /// Draws a rectangle with the specified shape color and coordinates.
        /// </summary>
        /// <param name="shapeColor">Color of the rectangle.</param>
        /// <param name="x1">X-coordinate of the top-left corner.</param>
        /// <param name="y1">Y-coordinate of the top-left corner.</param>
        /// <param name="x2">X-coordinate of the bottom-right corner.</param>
        /// <param name="y2">Y-coordinate of the bottom-right corner.</param>
        void DrawRectangle(ShapeColor shapeColor, int penWidth, Point point1, Point point2);

        /// <summary>
        /// Draws a circle with the specified shape color and coordinates.
        /// </summary>
        /// <param name="shapeColor">Color of the circle.</param>
        /// <param name="x1">X-coordinate of the center.</param>
        /// <param name="y1">Y-coordinate of the center.</param>
        /// <param name="x2">X-coordinate of a point on the circle.</param>
        /// <param name="y2">Y-coordinate of a point on the circle.</param>
        void DrawCircle(ShapeColor shapeColor, int penWidth, Point point1, Point point2);
    }
}
