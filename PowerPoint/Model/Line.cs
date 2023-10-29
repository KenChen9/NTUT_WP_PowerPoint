using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Line : Shape
    {
        public Line(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {

        }

        public override string GetName()
        {
            return "線";
        }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_x1, _y1, _x2, _y2);
        }
    }
}
