using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    /// <summary>
    /// Represents the main model of the application.
    /// </summary>
    public class Model
    {
        public delegate void CurrentToolChangedEventHandler(ShapeType shapeType);
        public event CurrentToolChangedEventHandler CurrentToolChanged;
        public delegate void ShapeListChangedEventHandler();
        public event ShapeListChangedEventHandler ShapeListChanged;
        private IState _state;
        private Shapes _shapes = new Shapes();
        private ShapeType _currentTool = ShapeType.Arrow;
        private int _selectedIndex = -1;

        // 必要之惡
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
            if (_selectedIndex != -1)
            {
                _shapes.RemoveAt(_selectedIndex);
                _selectedIndex = -1;
                NotifyShapeListChanged();
            }
        }

        /// <summary>
        /// Selects the specified shape type as the current drawing tool.
        /// </summary>
        /// <param name="shapeType">The type of the shape to select.</param>
        public void SelectTool(ShapeType shapeType)
        {
            _currentTool = shapeType;
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
        public void PressMouse(Point cursorPoint)
        {
            _state.PressMouse(cursorPoint);
            NotifyCurrentToolChanged();
        }

        /// <summary>
        /// Handles the move mouse event based on the current state and updates the shape list.
        /// </summary>
        /// <param name="x">The X-coordinate of the mouse position.</param>
        /// <param name="y">The Y-coordinate of the mouse position.</param>
        public void MoveMouse(Point cursorPoint)
        {
            _state.MoveMouse(cursorPoint);
            NotifyCurrentToolChanged();
            NotifyShapeListChanged();
        }

        /// <summary>
        /// Handles the release mouse event based on the current state and updates the shape list.
        /// </summary>
        public void ReleaseMouse(Point cursorPoint)
        {
            _state.ReleaseMouse(cursorPoint);
            NotifyCurrentToolChanged();
        }

        /// <summary>
        /// Draws shapes on the specified graphics object including the preview shape.
        /// </summary>
        /// <param name="graphics">The IGraphics object used for drawing.</param>
        public void DrawShapes(IGraphics graphics)
        {
            _shapes.Draw(graphics, _selectedIndex);
            _state.Draw(graphics);
        }

        /// <summary>
        /// CreatePreview
        /// </summary>
        public Shape CreatePreview(Point startPoint, Point endPoint)
        {
            return Factory.CreateShape(_currentTool, startPoint, endPoint);
        }

        /// <summary>
        /// IsSelectedShapeOverlap
        /// </summary>
        public bool IsSelectedShapeOverlap(Point cursorPoint)
        {
            return _selectedIndex != -1 && _shapes.IsShapeOverlap(_selectedIndex, cursorPoint);
        }

        /// <summary>
        /// MoveSelectedShapeDelta
        /// </summary>
        public void MoveSelectedShapeDelta(Point deltaDirection)
        {
            _shapes.MoveShapeDelta(_selectedIndex, deltaDirection);
        }

        /// <summary>
        /// TryResizeSelectedShape
        /// </summary>
        public void TryResizeSelectedShape(Point cursorPoint)
        {
            if (_selectedIndex != -1 && _shapes.IsShapeSupportPointOverlap(_selectedIndex, cursorPoint))
            {
                _shapes.ResizeShape(_selectedIndex, cursorPoint);
            }
        }

        /// <summary>
        /// TrySelectShapeIndex
        /// </summary>
        public void SelectShapeIndex(Point cursorPoint)
        {
            _selectedIndex = _shapes.SelectShapeIndex(cursorPoint);
        }

        /// <summary>
        /// ClearAllShapes
        /// </summary>
        public void ClearAllShapes()
        {
            _shapes.ClearAll();
            NotifyShapeListChanged();
        }

        /// <summary>
        /// Notifies subscribers about changes in the current selected tool.
        /// </summary>
        private void NotifyCurrentToolChanged()
        {
            if (CurrentToolChanged != null)
            {
                CurrentToolChanged(_currentTool);
            }
        }

        /// <summary>
        /// Notifies subscribers about changes in the shape list.
        /// </summary>
        private void NotifyShapeListChanged()
        {
            if (ShapeListChanged != null)
            {
                ShapeListChanged();
            }
        }
    }
}
