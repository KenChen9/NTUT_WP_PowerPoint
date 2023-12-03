using System.Drawing;
using System.Diagnostics;

namespace PowerPoint
{
    public class WindowsFormsGraphics : IGraphics
    {
        private Graphics _graphics;

        public WindowsFormsGraphics(Graphics graphics)
        {
            Debug.Assert(graphics != null);
            _graphics = graphics;
        }

        // Comment
        public void DrawLine(bool selected, Point first, Point second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            _graphics.DrawLine(GetPen(selected), first, second);
        }

        // Comment
        public void DrawRectangle(bool selected, Rectangle body)
        {
            Debug.Assert(body != null);
            _graphics.DrawRectangle(GetPen(selected), body);
        }

        // Comment
        public void DrawCircle(bool selected, Rectangle body)
        {
            Debug.Assert(body != null);
            _graphics.DrawEllipse(GetPen(selected), body);
        }

        // Comment
        private Pen GetPen(bool selected)
        {
            return selected ? Pens.Red : Pens.Black;
        }
    }
}
