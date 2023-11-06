namespace PowerPoint
{
    /// <summary>
    /// Represents the drawing state of the application.
    /// </summary>
    public class DrawingState : IState
    {
        private Model _model;
        private int _startX = 0;
        private int _startY = 0;
        private int _endX = 0;
        private int _endY = 0;
        private bool _pressed = false;
        private Shape _preview = null;

        /// <summary>
        /// Initializes a new instance of the DrawingState class with the specified model.
        /// </summary>
        /// <param name="model">The Model instance associated with the drawing state.</param>
        public DrawingState(Model model)
        {
            _model = model;
        }

        /// <summary>
        /// Handles the mouse press event.
        /// </summary>
        public void PressMouse()
        {
            _pressed = true;
        }

        /// <summary>
        /// Handles the mouse move event.
        /// </summary>
        /// <param name="x">X-coordinate of the mouse position.</param>
        /// <param name="y">Y-coordinate of the mouse position.</param>
        public void MoveMouse(int x, int y)
        {
            _startX = _pressed ? _startX : x;
            _startY = _pressed ? _startY : y;
            _endX = x;
            _endY = y;
            _preview = _pressed ? Factory.CreateShape(_model.CurrentTool, _startX, _startY, _endX, _endY) : null;
        }

        /// <summary>
        /// Handles the mouse release event.
        /// </summary>
        public void ReleaseMouse(int x, int y)
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
        public void Draw(IGraphics graphics, Shapes shapes)
        {
            shapes.Draw(graphics, -1);
            if (_preview != null)
            {
                _preview.Draw(graphics, false);
            }
        }
    }
}
