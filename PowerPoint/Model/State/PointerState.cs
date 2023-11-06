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
            if (_pressed && _model.SelectedIndex != -1 && _model.ShapeList[_model.SelectedIndex].IsOverlap(x, y))
            {
                _model.ShapeList[_model.SelectedIndex].MoveDelta(x - _lastMouseX, y - _lastMouseY);
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
            _model.SelectedIndex = _model.SelectedIndex == -1 ? FindSelectShapeIndex(x, y) : -1;
        }

        /// <summary>
        /// Draw
        /// </summary>
        public void Draw(IGraphics graphics, Shapes shapes)
        {
            shapes.Draw(graphics, _model.SelectedIndex);
        }

        /// <summary>
        /// FindSelectShapeIndex
        /// </summary>
        private int FindSelectShapeIndex(int x, int y)
        {
            for (int i = _model.ShapeList.Count - 1; i >= 0; i--)
            {
                if (_model.ShapeList[i].IsOverlap(x, y))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
