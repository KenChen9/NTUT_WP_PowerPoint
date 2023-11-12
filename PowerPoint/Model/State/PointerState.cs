namespace PowerPoint
{
    public class PointerState : IState
    {
        private Model _model;
        private int _lastMouseX = 0;
        private int _lastMouseY = 0;
        private bool _pressed = false;

        public PointerState(Model model)
        {
            _model = model;
        }

        /// <summary>
        /// PressMouse
        /// </summary>
        public void PressMouse()
        {
            _pressed = true;
        }

        /// <summary>
        /// MoveMouse
        /// </summary>
        public void MoveMouse(int cursorX, int cursorY)
        {
            if (_pressed && _model.IsSelectedShapeOverlap(cursorX, cursorY))
            {
                _model.MoveSelectedShapeDelta(cursorX - _lastMouseX, cursorY - _lastMouseY);
            }
            _lastMouseX = cursorX;
            _lastMouseY = cursorY;
        }

        /// <summary>
        /// ReleaseMouse
        /// </summary>
        public void ReleaseMouse(int cursorX, int cursorY)
        {
            _pressed = false;
            _model.TrySelectShapeIndex(cursorX, cursorY);
        }

        /// <summary>
        /// Draw
        /// </summary>
        public void Draw(IGraphics graphics, Shapes shapes, int selectedIndex)
        {
            shapes.Draw(graphics, selectedIndex);
        }
    }
}
