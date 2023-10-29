using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Shapes
    {
        private List<Shape> _shapes = new List<Shape>();

        public void Add(ShapeType shapeType)
        {
            _shapes.Add(Factory.CreateShape(shapeType));
        }

        public void RemoveAt(int index)
        {
            _shapes.RemoveAt(index);
        }

        public void Draw(IGraphics graphics)
        {
            _shapes.ForEach(shape => shape.Draw(graphics));
        }
    }
}
