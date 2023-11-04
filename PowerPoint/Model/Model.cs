using System.ComponentModel;

namespace PowerPoint
{
    public class Model
    {
        public delegate void ToolChangedHandler(ShapeType shapeType);
        public ToolChangedHandler ToolChanged;
        
        private IState _state;
        private Shapes _shapes = new Shapes();

        public Shape Preview { get; set; } = null;

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

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
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
            Preview = null;
            NotifyObserver();
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
            NotifyObserver();
        }

        public void MoveMouse(int x, int y)
        {
            _state.MoveMouse(x, y);
            NotifyObserver();
        }

        public void ReleaseMouse()
        {
            _state.ReleaseMouse();
            NotifyObserver();
        }

        public void DrawShapes(IGraphics graphics)
        {
            _shapes.Draw(graphics, SelectedIndex);
            if (Preview != null)
            {
                Preview.Draw(graphics, ShapeColor.Black);
            }
        }

        private void NotifyObserver()
        {
            ToolChanged?.Invoke(CurrentTool);
        }
    }
}
