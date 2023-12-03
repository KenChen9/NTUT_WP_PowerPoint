using System.ComponentModel;
using System.Diagnostics;

namespace PowerPoint
{
    public class Model
    {
        public delegate void ShapesChangedEventHandler();
        public event ShapesChangedEventHandler ShapesChanged;
        private const int UNAVAILABLE_INDEX = -1;
        private Shapes _shapes = new Shapes();
        private IState _state;
        private int _selectedIndex = UNAVAILABLE_INDEX;

        // 必要之惡，禁止其他部分使用
        public BindingList<Shape> ShapeList
        {
            get => _shapes.ShapeList;
        }

        public Model()
        {
            _state = new PointerState(this);
        }

        // Comment
        public void AddShape(string shapeType)
        {
            const string LINE = "線";
            const string RECTANGLE = "矩形";
            const string CIRCLE = "圓";
            Debug.Assert(shapeType == LINE || shapeType == RECTANGLE || shapeType == CIRCLE);
            _shapes.Add(shapeType);
            NotifyShapesChanged();
        }

        // Comment
        public void AddShape(Shape shape)
        {
            Debug.Assert(shape != null);
            _shapes.Add(shape);
            NotifyShapesChanged();
        }

        // Comment
        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            Debug.Assert(rowIndex >= 0);
            Debug.Assert(columnIndex == 0);
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.RemoveAt(rowIndex);
                _selectedIndex = UNAVAILABLE_INDEX;
            }
            NotifyShapesChanged();
        }

        // Comment
        public void RemoveLastShape()
        {
            _shapes.RemoveLast();
        }

        // Comment
        public void RemoveSelectedShape()
        {
            _shapes.RemoveAt(_selectedIndex);
            _selectedIndex = UNAVAILABLE_INDEX;
            NotifyShapesChanged();
        }

        // Comment
        public void ClearAllShapes()
        {
            _shapes.ClearAll();
            NotifyShapesChanged();
        }

        // Comment
        public void SetPointerMode()
        {
            _state = new PointerState(this);
        }

        // Comment
        public void SetDrawingMode()
        {
            _state = new DrawingState(this);
        }

        // Comment
        public void PressMouse(MyPoint point)
        {
            Debug.Assert(point != null);
            _state.PressMouse(point);
        }

        // Comment
        public void MoveMouse(ShapeType currentTool, MyPoint point)
        {
            Debug.Assert(point != null);
            _state.MoveMouse(currentTool, point);
        }

        // Comment
        public void ReleaseMouse()
        {
            _state.ReleaseMouse();
        }

        // Comment
        public void DrawShapes(IGraphics graphics)
        {
            Debug.Assert(graphics != null);
            _shapes.Draw(graphics, _selectedIndex);
            _state.Draw(graphics);
        }

        // Comment
        public void SelectShapeIndex(MyPoint point)
        {
            Debug.Assert(point != null);
            _selectedIndex = _shapes.SelectShapeIndex(point);
        }

        // Comment
        public void ResizeOrOffsetSelectedShape(MyPoint point, MyPoint destination, MyPoint delta)
        {
            if (_shapes.IsShapeResizable(_selectedIndex, point))
            {
                ResizeSelectedShape(point, destination);
            }
            else
            {
                OffsetSelectedShape(point, delta);
            }
        }

        // Comment
        private void ResizeSelectedShape(MyPoint point, MyPoint destination)
        {
            Debug.Assert(point != null);
            _shapes.ResizeShape(_selectedIndex, point, destination);
        }

        // Comment
        private void OffsetSelectedShape(MyPoint point, MyPoint delta)
        {
            Debug.Assert(point != null);
            Debug.Assert(delta != null);
            _shapes.Offset(_selectedIndex, point, delta);
        }

        // Comment
        private void NotifyShapesChanged()
        {
            if (ShapesChanged != null)
            {
                ShapesChanged();
            }
        }
    }
}
