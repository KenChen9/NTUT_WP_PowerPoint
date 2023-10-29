using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(Pens.Black, x1, y1, x2, y2);
        }

        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            int topLeftX = Math.Min(x1, x2);
            int topLeftY = Math.Min(y1, y2);
            int bottomRightX = Math.Max(x1, x2);
            int bottomRightY = Math.Max(y1, y2);
            _graphics.DrawRectangle(Pens.Black, topLeftX, topLeftY, bottomRightX, bottomRightY);
        }

        public void DrawCircle(int x1, int y1, int x2, int y2)
        {
            int topLeftX = Math.Min(x1, x2);
            int topLeftY = Math.Min(y1, y2);
            int bottomRightX = Math.Max(x1, x2);
            int bottomRightY = Math.Max(y1, y2);
            _graphics.DrawEllipse(Pens.Black, topLeftX, topLeftY, bottomRightX, bottomRightY);
        }
    }
}
