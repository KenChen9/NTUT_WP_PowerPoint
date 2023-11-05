namespace PowerPoint
{
    public class DrawingMode : IState
    {
        private Model _model;
        private int _startX = 0;
        private int _startY = 0;
        private int _endX = 0;
        private int _endY = 0;
        private bool _pressed = false;
        
        public DrawingMode(Model model)
        {
            _model = model;
        }
        
        public void PressMouse()
        {
            _startX = _endX;
            _startY = _endY;
            _pressed = true;
            _model.Preview = _pressed && _model.CurrentTool != ShapeType.Arrow
                ? Factory.CreateShape(_model.CurrentTool, _startX, _startY, _endX, _endY)
                : null;
        }

        public void MoveMouse(int x, int y)
        {
            _endX = x;
            _endY = y;
            _model.Preview = _pressed && _model.CurrentTool != ShapeType.Arrow
                ? Factory.CreateShape(_model.CurrentTool, _startX, _startY, _endX, _endY)
                : null;
        }

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
