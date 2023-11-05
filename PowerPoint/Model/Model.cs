using System.ComponentModel;

namespace PowerPoint
{
    public class Model
    {
        public delegate void CurrentToolChangedHandler(ShapeType shapeType);
        public CurrentToolChangedHandler CurrentToolChanged;

        public delegate void ShapeListChangedHandler();
        public ShapeListChangedHandler ShapeListChanged;
        
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
            NotifyShapeListChanged();
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
            NotifyShapeListChanged();
        }

        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.RemoveAt(rowIndex);
            }
            NotifyShapeListChanged();
        }

        public void SelectTool(ShapeType shapeType)
        {
            CurrentTool = shapeType;
            Preview = null;
            NotifyCurrentToolChanged();
        }

        public void SetPointerMode()
        {
            _state = new PointerState(this);
        }

        public void SetDrawingMode()
        {
            _state = new DrawingState(this);
        }

        public void PressMouse()
        {
            _state.PressMouse();
            NotifyCurrentToolChanged();
        }

        public void MoveMouse(int x, int y)
        {
            _state.MoveMouse(x, y);
            NotifyCurrentToolChanged();
            NotifyShapeListChanged();
        }

        public void ReleaseMouse()
        {
            _state.ReleaseMouse();
            NotifyCurrentToolChanged();
        }

        public void DrawShapes(IGraphics graphics)
        {
            _shapes.Draw(graphics, SelectedIndex);
            if (Preview != null)
            {
                Preview.Draw(graphics, ShapeColor.Black);
            }
        }

        private void NotifyCurrentToolChanged()
        {
            CurrentToolChanged?.Invoke(CurrentTool);
        }

        private void NotifyShapeListChanged()
        {
            ShapeListChanged?.Invoke();
        }
    }
}
