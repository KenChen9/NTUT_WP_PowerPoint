using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace PowerPoint
{
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

        public FormPresentationModel(Model model)
        {
            _model = model;
            _model.CurrentToolChanged += UpdateCurrentTool;
            _model.ShapeListChanged += UpdateDrawingPanel;
        }

        public void AddShape(string shapeType)
        {
            _model.AddShape(shapeType);
        }

        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            _model.RemoveShapeAt(rowIndex, columnIndex);
        }

        public void SelectTool(ShapeType shapeType)
        {
            _model.SelectTool(shapeType);
            NotifyToolCursorChanged();
        }

        public void PressMouse()
        {
            _model.PressMouse();
        }

        public void MoveMouse(int x, int y)
        {
            _model.MoveMouse(x, y);
        }

        public void ReleaseMouse()
        {
            _currentCursor = Cursors.Arrow;
            _model.ReleaseMouse();
            NotifyToolCursorChanged();
        }

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

        public void LeavePanel()
        {
            _currentCursor = Cursors.Arrow;
            _model.SetPointerMode();
            NotifyToolCursorChanged();
        }

        public void DrawShapes(IGraphics graphics)
        {
            _model.DrawShapes(graphics);
        }

        private void NotifyToolCursorChanged()
        {
            Dictionary<ShapeType, bool> toolStatus = new Dictionary<ShapeType, bool>();
            toolStatus.Add(ShapeType.Line, _currentTool == ShapeType.Line);
            toolStatus.Add(ShapeType.Rectangle, _currentTool == ShapeType.Rectangle);
            toolStatus.Add(ShapeType.Circle, _currentTool == ShapeType.Circle);
            toolStatus.Add(ShapeType.Arrow, _currentTool == ShapeType.Arrow);
            ToolCursorChanged?.Invoke(toolStatus, _currentCursor);
        }

        private void NotifyShapeListChanged()
        {
            ShapeListChanged?.Invoke();
        }

        private void UpdateCurrentTool(ShapeType shapeType)
        {
            _currentTool = shapeType;
            NotifyToolCursorChanged();
        }

        private void UpdateDrawingPanel()
        {
            NotifyShapeListChanged();
        }
    }
}
