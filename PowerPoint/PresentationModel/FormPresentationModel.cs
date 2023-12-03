using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace PowerPoint
{
    public class FormPresentationModel
    {
        public delegate void ToolsChangedEventHandler(bool lineToolChecked, bool rectangleToolChecked, bool circleToolChecked, bool arrowToolChecked);
        public event ToolsChangedEventHandler ToolsChanged;
        public delegate void CursorChangedEventHandler(Cursor currentCursor);
        public event CursorChangedEventHandler CursorChanged;
        public delegate void ShapesChangedEventHandler();
        public event ShapesChangedEventHandler ShapesChanged;
        public delegate void SlidesChangedEventHandler();
        public event SlidesChangedEventHandler SlidesChanged;
        private Model _model;
        private Cursor _currentCursor = Cursors.Arrow;
        private ShapeType _currentTool = ShapeType.None;

        // 必要之惡，禁止其他部分使用
        public BindingList<Shape> ShapeList
        {
            get => _model.ShapeList;
        }

        public FormPresentationModel(Model model)
        {
            Debug.Assert(model != null);
            _model = model;
            _model.ShapesChanged += UpdateDrawingPanel;
        }

        // Comment
        public void AddShape(string shapeType)
        {
            const string LINE = "線";
            const string RECTANGLE = "矩形";
            const string CIRCLE = "圓";
            Debug.Assert(shapeType == LINE || shapeType == RECTANGLE || shapeType == CIRCLE);
            _model.AddShape(shapeType);
        }

        // Comment
        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            Debug.Assert(rowIndex >= 0);
            Debug.Assert(columnIndex >= 0);
            _model.RemoveShapeAt(rowIndex, columnIndex);
        }

        // Comment
        public void RemoveSelectedShape()
        {
            _model.RemoveSelectedShape();
        }

        // Comment
        public void SelectTool(ShapeType shapeType)
        {
            _currentTool = shapeType;
            NotifyToolsChanged();
        }

        // Comment
        public void UnselectTool()
        {
            _currentTool = ShapeType.None;
            NotifyToolsChanged();
        }

        // Comment
        public void PressMouse(MyPoint point)
        {
            Debug.Assert(point != null);
            _model.PressMouse(point);
        }

        // Comment
        public void MoveMouse(MyPoint point)
        {
            Debug.Assert(point != null);
            _model.MoveMouse(_currentTool, point);
        }

        // Comment
        public void ReleaseMouse()
        {
            _currentCursor = Cursors.Arrow;
            _currentTool = ShapeType.None;
            _model.ReleaseMouse();
            NotifyToolsChanged();
            NotifySlidesChanged();
        }

        // Comment
        public void EnterPanel()
        {
            if (_currentTool != ShapeType.None)
            {
                _currentCursor = Cursors.Cross;
                _model.SetDrawingMode();
            }
            NotifyCursorChanged();
            NotifyToolsChanged();
        }

        // Comment
        public void LeavePanel()
        {
            _currentCursor = Cursors.Arrow;
            _model.SetPointerMode();
            NotifyCursorChanged();
        }

        // Comment
        public void DrawShapes(IGraphics graphics)
        {
            Debug.Assert(graphics != null);
            _model.DrawShapes(graphics);
        }

        // Comment
        public void ClearAllShapes()
        {
            _model.ClearAllShapes();
        }

        // Comment
        private void UpdateDrawingPanel()
        {
            NotifyShapesChanged();
        }

        // Comment
        private void NotifyToolsChanged()
        {
            Debug.Assert(ToolsChanged != null);
            if (ToolsChanged != null)
            {
                bool lineToolChecked = _currentTool == ShapeType.Line;
                bool ractangleToolChecked = _currentTool == ShapeType.Rectangle;
                bool circleToolChecked = _currentTool == ShapeType.Circle;
                bool arrowToolChecked = _currentTool == ShapeType.None;
                ToolsChanged(lineToolChecked, ractangleToolChecked, circleToolChecked, arrowToolChecked);
            }
        }

        // Comment
        private void NotifyCursorChanged()
        {
            Debug.Assert(CursorChanged != null);
            if (CursorChanged != null)
            {
                CursorChanged(_currentCursor);
            }
        }

        // Comment
        private void NotifyShapesChanged()
        {
            Debug.Assert(ShapesChanged != null);
            if (ShapesChanged != null)
            {
                ShapesChanged();
            }
        }

        // Comment
        private void NotifySlidesChanged()
        {
            Debug.Assert(SlidesChanged != null);
            if (SlidesChanged != null)
            {
                SlidesChanged();
            }
        }
    }
}
