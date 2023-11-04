using System.ComponentModel;

namespace PowerPoint
{
    public class Model
    {
        private Shapes _shapes = new Shapes();
        private IState _state;

        public ShapeType CurrentTool { get; set; } = ShapeType.Arrow;
        public int SelectedIndex { get; set; } = -1;

        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapes.ShapeList;
            }
        }

        public Model()
        {
            _state = new PointerState(this);
        }

        public void AddShape(string shapeType)
        {
            _shapes.Add(shapeType);
        }

        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.RemoveAt(rowIndex);
            }
        }

        public void SelectTool(ShapeType shapeType)
        {
            CurrentTool = shapeType;
        }

        public void SetPointerMode()
        {
            _state = new PointerState(this);
        }

        public void SetDrawingMode()
        {
            _state = new DrawingMode(this);
        }

        public void PressMouse()
        {
            _state.PressMouse();
        }

        public void MoveMouse()
        {
            _state.MoveMouse();
        }

        public void ReleaseMouse()
        {
            _state.ReleaseMouse();
        }

        public void EnterPanel()
        {
            _state.EnterPanel();
        }

        public void LeavePanel()
        {
            _state.LeavePanel();
        }

        public void DrawShapes(IGraphics graphics)
        {
            _shapes.Draw(graphics, SelectedIndex);
        }
    }
}
