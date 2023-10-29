using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public abstract class Shape
    {
        protected int _x1;
        protected int _y1;
        protected int _x2;
        protected int _y2;

        protected Shape(int x1, int y1, int x2, int y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        public string GetInfo()
        {
            return $"{_x1}, {_y1}, {_x2}, {_y2}";
        }

        public abstract string GetName();
        public abstract void Draw(IGraphics graphics);
    }
}
