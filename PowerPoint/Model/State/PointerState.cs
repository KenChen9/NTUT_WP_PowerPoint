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
        public void MoveMouse(int x, int y)
        {
            if (_pressed && _model.IsSelectedShapeOverlap(x, y))
            {
                _model.MoveSelectedShapeDelta(x - _lastMouseX, y - _lastMouseY);
            }
            _lastMouseX = x;
            _lastMouseY = y;
        }

        /// <summary>
        /// ReleaseMouse
        /// </summary>
        public void ReleaseMouse(int x, int y)
        {
            _pressed = false;
            _model.TrySelectShapeIndex(x, y);
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
