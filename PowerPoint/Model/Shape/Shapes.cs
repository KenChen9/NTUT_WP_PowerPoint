using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    public class Shapes
    {
        private BindingList<Shape> _shapeList = new BindingList<Shape>();

        // 必要之惡
        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapeList;
            }
        }

        /// <summary>
        /// Adds a shape to the Shapes collection based on the provided shape type.
        /// </summary>
        public void Add(string shapeType)
        {
            Add(Factory.CreateShape(shapeType));
        }

        /// <summary>
        /// Adds a specified shape to the Shapes collection.
        /// </summary>
        public void Add(Shape shape)
        {
            if (shape != null)
            {
                _shapeList.Add(shape);
            }
        }

        /// <summary>
        /// Removes the shape at the specified index from the Shapes collection.
        /// </summary>
        public void RemoveAt(int index)
        {
            _shapeList.RemoveAt(index);
        }

        /// <summary>
        /// ClearAll
        /// </summary>
        public void ClearAll()
        {
            _shapeList.Clear();
        }

        /// <summary>
        /// IsShapeOverlap
        /// </summary>
        public bool IsShapeOverlap(int selectedIndex, Point cursorPoint)
        {
            return _shapeList[selectedIndex].IsOverlap(cursorPoint);
        }

        /// <summary>
        /// IsShapeSupportPointOverlap
        /// </summary>
        public int FindShapeSupportCircleOverlapIndex(int selectedIndex, Point cursorPoint)
        {
            return _shapeList[selectedIndex].FindSupportCircleOverlapIndex(cursorPoint);
        }

        /// <summary>
        /// ResizeShape
        /// </summary>
        public void ResizeShape(int selectedIndex, int supportCircleOverlapIndex, Point cursorPoint)
        {
            _shapeList[selectedIndex].Resize(supportCircleOverlapIndex, cursorPoint);
        }

        /// <summary>
        /// MoveShapeDelta
        /// </summary>
        public void MoveShapeDelta(int selectedIndex, Point deltaDirection)
        {
            _shapeList[selectedIndex].MoveDelta(deltaDirection);
        }

        /// <summary>
        /// SelectShapeIndex
        /// </summary>
        public int SelectShapeIndex(Point cursorPoint)
        {
            for (int i = _shapeList.Count - 1; i >= 0; i--)
            {
                if (_shapeList[i].IsOverlap(cursorPoint))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Draws all shapes using the specified graphics object, highlighting the shape at the specified index in red.
        /// </summary>
        public void Draw(IGraphics graphics, int selectedIndex)
        {
            for (int i = 0; i < _shapeList.Count; i++)
            {
                _shapeList[i].Draw(graphics, i == selectedIndex);
            }
        }
    }
}
