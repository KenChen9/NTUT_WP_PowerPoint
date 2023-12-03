using System.ComponentModel;
using System.Linq;
using System.Diagnostics;

namespace PowerPoint
{
    public class Shapes
    {
        public BindingList<Shape> ShapeList
        {
            get;
        } = new BindingList<Shape>();

        // Comment
        public void Add(string shapeType)
        {
            const string LINE = "線";
            const string RECTANGLE = "矩形";
            const string CIRCLE = "圓";
            Debug.Assert(shapeType == LINE || shapeType == RECTANGLE || shapeType == CIRCLE);
            Add(Factory.CreateRandomShape(shapeType));
        }

        // Comment
        public void Add(Shape shape)
        {
            Debug.Assert(shape != null);
            ShapeList.Add(shape);
        }

        // Comment
        public void RemoveAt(int index)
        {
            Debug.Assert(0 <= index && index < ShapeList.Count);
            ShapeList.RemoveAt(index);
        }

        // Comment
        public void RemoveLast()
        {
            if (ShapeList.Count > 0)
            {
                ShapeList.RemoveAt(ShapeList.Count - 1);
            }
        }

        // Comment
        public void ClearAll()
        {
            ShapeList.Clear();
        }

        // Comment
        public int SelectShapeIndex(MyPoint point)
        {
            Debug.Assert(point != null);
            return ShapeList.Reverse().ToList().FindIndex(shape => shape.IsOverlap(point));
        }

        // Comment
        public void ResizeShape(int selectedIndex, MyPoint point, MyPoint destination)
        {
            Debug.Assert(-1 <= selectedIndex && selectedIndex < ShapeList.Count);
            Debug.Assert(point != null);
            Debug.Assert(destination != null);
            if (selectedIndex >= 0)
            {
                ShapeList[selectedIndex].Resize(point, destination);
            }
        }

        // Comment
        public void Offset(int selectedIndex, MyPoint point, MyPoint delta)
        {
            Debug.Assert(-1 <= selectedIndex && selectedIndex < ShapeList.Count);
            Debug.Assert(point != null);
            Debug.Assert(delta != null);
            if (selectedIndex >= 0 && ShapeList[selectedIndex].IsOverlap(point))
            {
                ShapeList[selectedIndex].Offset(delta);
            }
        }

        // Comment
        public void Draw(IGraphics graphics, int selectedIndex)
        {
            Debug.Assert(graphics != null);
            Debug.Assert(-1 <= selectedIndex && selectedIndex < ShapeList.Count);
            for (int i = 0; i < ShapeList.Count; i++)
            {
                ShapeList[i].Draw(graphics, i == selectedIndex);
            }
        }

        // Comment
        public bool IsShapeResizable(int selectedIndex, MyPoint point)
        {
            Debug.Assert(-1 <= selectedIndex && selectedIndex < ShapeList.Count);
            Debug.Assert(point != null);
            return selectedIndex >= 0 && ShapeList[selectedIndex].IsOverlapSupport(point);
        }
    }
}
