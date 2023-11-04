using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Circle : Shape
    {
        public override string Name
        {
            get
            {
                return "圓";
            }
        }

        public Circle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {

        }

        public override void Draw(IGraphics graphics, ShapeColor shapeColor)
        {
            graphics.DrawCircle(shapeColor, _x1, _y1, _x2, _y2);
        }
    }
}
