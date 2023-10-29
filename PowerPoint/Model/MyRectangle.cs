using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class MyRectangle : Shape
    {
        public MyRectangle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {

        }

        public override string GetName()
        {
            return "矩形";
        }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_x1, _y1, _x2, _y2);
        }
    }
}
