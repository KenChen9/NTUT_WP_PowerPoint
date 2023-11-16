using System.Drawing;

namespace PowerPoint
{
    public interface IGraphics
    {
        /// <summary>
        /// Draws a line with the specified shape color and coordinates.
        /// </summary>
        void DrawLine(ShapeColor shapeColor, int penWidth, Point point1, Point point2);

        /// <summary>
        /// Draws a rectangle with the specified shape color and coordinates.
        /// </summary>
        void DrawRectangle(ShapeColor shapeColor, int penWidth, Point point1, Point point2);

        /// <summary>
        /// Draws a circle with the specified shape color and coordinates.
        /// </summary>
        void DrawCircle(ShapeColor shapeColor, int penWidth, Point point1, Point point2);

        /// <summary>
        /// DrawLineSupportCircles
        /// </summary>
        void DrawLineFrame(int penWidth, Point point1, Point point2);

        /// <summary>
        /// DrawRectangleSupportCircles
        /// </summary>
        void DrawRectangleFrame(int penWidth, Point point1, Point point2);

        /// <summary>
        /// DrawCircleSupportCircle
        /// </summary>
        void DrawCircleFrame(int penWidth, Point point1, Point point2);
    }
}
