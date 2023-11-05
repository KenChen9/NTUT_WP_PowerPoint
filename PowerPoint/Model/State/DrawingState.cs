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
            _startX = _endX;
            _startY = _endY;
            _pressed = true;
            _model.Preview = _pressed ? Factory.CreateShape(_model.CurrentTool, _startX, _startY, _endX, _endY) : null;
        }

        /// <summary>
        /// Handles the mouse move event.
        /// </summary>
        /// <param name="x">X-coordinate of the mouse position.</param>
        /// <param name="y">Y-coordinate of the mouse position.</param>
        public void MoveMouse(int x, int y)
        {
            _endX = x;
            _endY = y;
            _model.Preview = _pressed ? Factory.CreateShape(_model.CurrentTool, _startX, _startY, _endX, _endY) : null;
        }

        /// <summary>
        /// Handles the mouse release event.
        /// </summary>
        public void ReleaseMouse()
        {
            _startX = _endX;
            _startY = _endY;
            _pressed = false;
            if (_model.Preview != null)
            {
                _model.AddShape(_model.Preview);
            }
            _model.Preview = null;
            _model.CurrentTool = ShapeType.Arrow;
            _model.SetPointerMode();
        }
    }
}
