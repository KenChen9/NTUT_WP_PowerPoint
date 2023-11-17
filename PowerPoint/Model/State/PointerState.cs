using System.Drawing;

namespace PowerPoint
{
    public class PointerState : IState
    {
        private Model _model;
        private Point _lastMousePoint = new Point(0, 0);
        private bool _pressed = false;

        public PointerState(Model model)
        {
            _model = model;
        }

        /// <summary>
        /// PressMouse
        /// </summary>
        public void PressMouse(Point cursorPoint)
        {
            _pressed = true;
            _model.TryResizeSelectedShape(cursorPoint);
            _model.SelectShapeIndex(cursorPoint);
        }

        /// <summary>
        /// MoveMouse
        /// </summary>
        public void MoveMouse(Point cursorPoint)
        {
            if (_pressed && _model.IsSelectedShapeOverlap(cursorPoint))
            {
                _model.MoveSelectedShapeDelta(new Point(cursorPoint.X - _lastMousePoint.X, cursorPoint.Y - _lastMousePoint.Y));
            }
            _lastMousePoint = cursorPoint;
        }

        /// <summary>
        /// ReleaseMouse
        /// </summary>
        public void ReleaseMouse(Point cursorPoint)
        {
            _pressed = false;
        }

        /// <summary>
        /// Draw
        /// </summary>
        public void Draw(IGraphics graphics)
        {
            
        }
    }
}
