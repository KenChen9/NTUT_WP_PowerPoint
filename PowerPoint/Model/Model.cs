using System.ComponentModel;

namespace PowerPoint
{
    /// <summary>
    /// Represents the main model of the application.
    /// </summary>
    public class Model
    {
        public delegate void CurrentToolChangedHandler(ShapeType shapeType);
        public delegate void ShapeListChangedHandler();
        public event CurrentToolChangedHandler CurrentToolChanged;
        public event ShapeListChangedHandler ShapeListChanged;
        private IState _state;
        private Shapes _shapes = new Shapes();

        public ShapeType CurrentTool { get; set; } = ShapeType.Arrow;

        public int SelectedIndex { get; set; } = -1;

        public BindingList<Shape> ShapeList
        {
            get { return _shapes.ShapeList; }
        }

        public Model()
        {
            _state = new PointerState(this);
        }

        /// <summary>
        /// Adds a new shape to the shape list based on the specified shape type.
        /// </summary>
        /// <param name="shapeType">The type of the shape to add.</param>
        public void AddShape(string shapeType)
        {
            _shapes.Add(shapeType);
            NotifyShapeListChanged();
        }

        /// <summary>
        /// Adds a shape to the shape list.
        /// </summary>
        /// <param name="shape">The shape to add.</param>
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
            NotifyShapeListChanged();
        }

        /// <summary>
        /// Removes a shape at the specified row index and column index from the shape list.
        /// </summary>
        /// <param name="rowIndex">The row index of the shape to remove.</param>
        /// <param name="columnIndex">The column index of the shape to remove.</param>
        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.RemoveAt(rowIndex);
            }
            NotifyShapeListChanged();
        }

        /// <summary>
        /// RemoveSelectedShape
        /// </summary>
        public void RemoveSelectedShape()
        {
            if (SelectedIndex != -1)
            {
                _shapes.RemoveAt(SelectedIndex);
            }
        }

        /// <summary>
        /// Selects the specified shape type as the current drawing tool.
        /// </summary>
        /// <param name="shapeType">The type of the shape to select.</param>
        public void SelectTool(ShapeType shapeType)
        {
            CurrentTool = shapeType;
            NotifyCurrentToolChanged();
        }

        /// <summary>
        /// Sets the model to pointer mode for handling user interactions.
        /// </summary>
        public void SetPointerMode()
        {
            _state = new PointerState(this);
        }

        /// <summary>
        /// Sets the model to drawing mode for handling user interactions.
        /// </summary>
        public void SetDrawingMode()
        {
            _state = new DrawingState(this);
        }

        /// <summary>
        /// Handles the press mouse event based on the current state.
        /// </summary>
        public void PressMouse()
        {
            _state.PressMouse();
            NotifyCurrentToolChanged();
        }

        /// <summary>
        /// Handles the move mouse event based on the current state and updates the shape list.
        /// </summary>
        /// <param name="x">The X-coordinate of the mouse position.</param>
        /// <param name="y">The Y-coordinate of the mouse position.</param>
        public void MoveMouse(int x, int y)
        {
            _state.MoveMouse(x, y);
            NotifyCurrentToolChanged();
            NotifyShapeListChanged();
        }

        /// <summary>
        /// Handles the release mouse event based on the current state and updates the shape list.
        /// </summary>
        public void ReleaseMouse(int x, int y)
        {
            _state.ReleaseMouse(x, y);
            NotifyCurrentToolChanged();
        }

        /// <summary>
        /// Draws shapes on the specified graphics object including the preview shape.
        /// </summary>
        /// <param name="graphics">The IGraphics object used for drawing.</param>
        public void DrawShapes(IGraphics graphics)
        {
            _state.Draw(graphics, _shapes);
        }

        /// <summary>
        /// Notifies subscribers about changes in the current selected tool.
        /// </summary>
        private void NotifyCurrentToolChanged()
        {
            CurrentToolChanged?.Invoke(CurrentTool);
        }

        /// <summary>
        /// Notifies subscribers about changes in the shape list.
        /// </summary>
        private void NotifyShapeListChanged()
        {
            ShapeListChanged?.Invoke();
        }
    }
}
