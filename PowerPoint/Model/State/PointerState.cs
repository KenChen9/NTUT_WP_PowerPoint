using System.Diagnostics;

namespace PowerPoint
{
    public class PointerState : IState
    {
        private const int UNAVAILABLE_INDEX = -1;
        private Model _model;
        private MyPoint _lastMousePoint = new MyPoint(0, 0);
        private bool _pressed = false;

        public PointerState(Model model)
        {
            Debug.Assert(model != null);
            _model = model;
        }

        // Comment
        public void PressMouse(MyPoint point)
        {
            Debug.Assert(point != null);
            _pressed = true;
            _model.SelectShapeIndex(point);
        }

        // Comment
        public void MoveMouse(ShapeType currentTool, MyPoint point)
        {
            Debug.Assert(point != null);
            if (_pressed)
            {
                _model.ResizeOrOffsetSelectedShape(_lastMousePoint, point, point - _lastMousePoint);
            }
            _lastMousePoint = point;
        }

        // Comment
        public void ReleaseMouse()
        {
            _pressed = false;
        }

        // Comment
        public void Draw(IGraphics graphics)
        {
            Debug.Assert(graphics != null);
        }
    }
}
