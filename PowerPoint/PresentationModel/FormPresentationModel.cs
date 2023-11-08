using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    /// <summary>
    /// Presentation model for the main form of the PowerPoint application.
    /// </summary>
    public class FormPresentationModel
    {
        public delegate void ToolCursorChangedHandler(Dictionary<ShapeType, bool> toolStatus, Cursor currentCursor);
        public event ToolCursorChangedHandler ToolCursorChanged;
        public delegate void ShapeListChangedHandler();
        public event ShapeListChangedHandler ShapeListChanged;
        private Model _model;
        private ShapeType _currentTool = ShapeType.Arrow;
        private Cursor _currentCursor = Cursors.Arrow;

        public BindingList<Shape> ShapeList
        {
            get
            {
                return _model.ShapeList;
            }
        }

        /// <summary>
        /// Initializes a new instance of the FormPresentationModel class with the specified model.
        /// </summary>
        /// <param name="model">The Model instance associated with the presentation model.</param>
        public FormPresentationModel(Model model)
        {
            _model = model;
            _model.CurrentToolChanged += UpdateCurrentTool;
            _model.ShapeListChanged += UpdateDrawingPanel;
        }

        /// <summary>
        /// Adds a shape to the model based on the provided shape type.
        /// </summary>
        /// <param name="shapeType">String representation of the shape type (線, 矩形, or 圓).</param>
        public void AddShape(string shapeType)
        {
            _model.AddShape(shapeType);
        }

        /// <summary>
        /// Removes a shape from the model at the specified row and column indices.
        /// </summary>
        /// <param name="rowIndex">Row index of the shape in the grid.</param>
        /// <param name="columnIndex">Column index of the shape in the grid.</param>
        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            _model.RemoveShapeAt(rowIndex, columnIndex);
        }

        /// <summary>
        /// RemoveSelectedShape
        /// </summary>
        public void RemoveSelectedShape()
        {
            _model.RemoveSelectedShape();
        }

        /// <summary>
        /// Selects a drawing tool based on the specified shape type.
        /// </summary>
        /// <param name="shapeType">Type of the selected drawing tool (Line, Rectangle, Circle, Arrow).</param>
        public void SelectTool(ShapeType shapeType)
        {
            _model.SelectTool(shapeType);
            NotifyToolCursorChanged();
        }

        /// <summary>
        /// Handles the mouse press event.
        /// </summary>
        public void PressMouse()
        {
            _model.PressMouse();
        }

        /// <summary>
        /// Handles the mouse move event.
        /// </summary>
        /// <param name="x">X-coordinate of the mouse position.</param>
        /// <param name="y">Y-coordinate of the mouse position.</param>
        public void MoveMouse(int x, int y)
        {
            _model.MoveMouse(x, y);
        }

        /// <summary>
        /// Handles the mouse release event.
        /// </summary>
        public void ReleaseMouse(int x, int y)
        {
            _currentCursor = Cursors.Arrow;
            _model.ReleaseMouse(x, y);
            NotifyToolCursorChanged();
        }

        /// <summary>
        /// Handles the mouse enter event for the drawing panel.
        /// </summary>
        public void EnterPanel()
        {
            _currentCursor = _currentTool == ShapeType.Arrow ? Cursors.Arrow : Cursors.Cross;
            if (_currentTool == ShapeType.Arrow)
            {
                _model.SetPointerMode();
            }
            else
            {
                _model.SetDrawingMode();
            }
            NotifyToolCursorChanged();
        }

        /// <summary>
        /// Handles the mouse leave event for the drawing panel.
        /// </summary>
        public void LeavePanel()
        {
            _currentCursor = Cursors.Arrow;
            _model.SetPointerMode();
            NotifyToolCursorChanged();
        }

        /// <summary>
        /// Draws all shapes using the specified graphics object.
        /// </summary>
        /// <param name="graphics">The IGraphics object used for drawing.</param>
        public void DrawShapes(IGraphics graphics)
        {
            _model.DrawShapes(graphics);
        }

        /// <summary>
        /// NotifyToolCursorChanged
        /// </summary>
        private void NotifyToolCursorChanged()
        {
            Dictionary<ShapeType, bool> toolStatus = new Dictionary<ShapeType, bool>
            {
                { ShapeType.Line, _currentTool == ShapeType.Line },
                { ShapeType.Rectangle, _currentTool == ShapeType.Rectangle },
                { ShapeType.Circle, _currentTool == ShapeType.Circle },
                { ShapeType.Arrow, _currentTool == ShapeType.Arrow }
            };
            ToolCursorChanged?.Invoke(toolStatus, _currentCursor);
        }

        /// <summary>
        /// NotifyShapeListChanged
        /// </summary>
        private void NotifyShapeListChanged()
        {
            ShapeListChanged?.Invoke();
        }

        /// <summary>
        /// UpdateCurrentTool
        /// </summary>
        /// <param name="shapeType">ShapeType</param>
        private void UpdateCurrentTool(ShapeType shapeType)
        {
            _currentTool = shapeType;
            NotifyToolCursorChanged();
        }

        /// <summary>
        /// UpdateDrawingPanel
        /// </summary>
        private void UpdateDrawingPanel()
        {
            NotifyShapeListChanged();
        }
    }
}
