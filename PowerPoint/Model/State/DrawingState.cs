using System.Drawing;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        private Model _model;
        private Point _startPoint = new Point(0, 0);
        private Point _endPoint = new Point(0, 0);
        private bool _pressed = false;
        private Shape _preview = null;

        public DrawingState(Model model)
        {
            _model = model;
        }

        /// <summary>
        /// Handles the mouse press event.
        /// </summary>
        public void PressMouse(Point cursorPoint)
        {
            _pressed = true;
        }

        /// <summary>
        /// Handles the mouse move event.
        /// </summary>
        public void MoveMouse(Point cursorPoint)
        {
            _startPoint = _pressed ? _startPoint : cursorPoint;
            _endPoint = _pressed ? cursorPoint : _endPoint;
            _preview = _pressed ? _model.CreatePreview(_startPoint, _endPoint) : null;
        }

        /// <summary>
        /// Handles the mouse release event.
        /// </summary>
        public void ReleaseMouse(Point cursorPoint)
        {
            _pressed = false;
            if (_preview != null)
            {
                _model.AddShape(_preview);
                _preview = null;
            }
            _model.SelectTool(ShapeType.Arrow);
            _model.SetPointerMode();
        }

        /// <summary>
        /// Draw
        /// </summary>
        public void Draw(IGraphics graphics)
        {
            if (_preview != null)
            {
                _preview.Draw(graphics, false);
            }
        }
    }
}
