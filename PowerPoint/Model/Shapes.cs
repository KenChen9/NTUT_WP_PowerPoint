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

        public void Add(string shapeType)
        {
            Shape shape = Factory.CreateShape(shapeType);
            if (shape != null)
            {
                _shapes.Add(shape);
            }
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
