using System.Diagnostics;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        private Model _model;
        private MyPoint _first = new MyPoint(0, 0);
        private MyPoint _second = new MyPoint(0, 0);
        private Shape _preview = null;
        private bool _pressed = false;

        public DrawingState(Model model)
        {
            Debug.Assert(model != null);
            _model = model;
        }

        // Comment
        public void PressMouse(MyPoint point)
        {
            Debug.Assert(point != null);
            _pressed = true;
        }

        // Comment
        public void MoveMouse(ShapeType currentTool, MyPoint point)
        {
            Debug.Assert(point != null);
            if (_pressed)
            {
                _second = point;
                _preview = Factory.CreateShape(currentTool, _first, _second);
            }
            else
            {
                _first = point;
                _preview = null;
            }
        }

        // Comment
        public void ReleaseMouse()
        {
            _pressed = false;
            if (_preview != null)
            {
                _model.AddShape(_preview);
                _preview = null;
            }
            _model.SetPointerMode();
        }

        // Comment
        public void Draw(IGraphics graphics)
        {
            Debug.Assert(graphics != null);
            if (_pressed)
            {
                _preview.Draw(graphics, false);
            }
        }
    }
}
