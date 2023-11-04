using System;
using System.Drawing;

namespace PowerPoint
{
    public class WindowsFormsGraphics : IGraphics
    {
        private Graphics _graphics;

        public WindowsFormsGraphics(Graphics graphics)
        {
            _graphics = graphics;
        }

        private Pen GetPen(ShapeColor shapeColor)
        {
            switch (shapeColor)
            {
                case ShapeColor.Black:
                    return Pens.Black;
                case ShapeColor.Red:
                    return Pens.Red;
                default:
                    return null;
            }
        }
        
        public void DrawLine(ShapeColor shapeColor, int x1, int y1, int x2, int y2)
        {
            Pen pen = GetPen(shapeColor);
            if (pen != null)
            {
                _graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        public void DrawRectangle(ShapeColor shapeColor, int x1, int y1, int x2, int y2)
        {
            Pen pen = GetPen(shapeColor);
            int topLeftX = Math.Min(x1, x2);
            int topLeftY = Math.Min(y1, y2);
            int bottomRightX = Math.Max(x1, x2);
            int bottomRightY = Math.Max(y1, y2);
            if (pen != null)
            {
                _graphics.DrawRectangle(pen, topLeftX, topLeftY, bottomRightX, bottomRightY);
            }
        }

        public void DrawCircle(ShapeColor shapeColor, int x1, int y1, int x2, int y2)
        {
            Pen pen = GetPen(shapeColor);
            int topLeftX = Math.Min(x1, x2);
            int topLeftY = Math.Min(y1, y2);
            int bottomRightX = Math.Max(x1, x2);
            int bottomRightY = Math.Max(y1, y2);
            if (pen != null)
            {
                _graphics.DrawEllipse(pen, topLeftX, topLeftY, bottomRightX, bottomRightY);
            }
        }
    }
}
