using System.Drawing;

namespace PowerPoint
{
    public interface IGraphics
    {
        // Comment
        void DrawLine(bool selected, Point first, Point second);

        // Comment
        void DrawRectangle(bool selected, Rectangle body);

        // Comment
        void DrawCircle(bool selected, Rectangle body);
    }
}
