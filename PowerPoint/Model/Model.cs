using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        public delegate void ModelChangedEventHandler(List<Shape> shapes);
        public event ModelChangedEventHandler ModelChanged;
        private Shapes _shapes = new Shapes();
        private ShapeType _currentTool = ShapeType.Arrow;
        private IState _state;

        public Model()
        {
            _state = new PointerState(this);
        }

        public void AddShape(string shapeType)
        {
            _shapes.Add(shapeType);
            NotifyObserver();
        }

        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.RemoveAt(rowIndex);
                NotifyObserver();
            }
        }

        public void SelectTool(ShapeType shapeType)
        {
            _currentTool = shapeType;
        }

        public void SetPointerMode()
        {
            _state = new PointerState(this);
        }

        public void SetDrawingMode()
        {
            _state = new DrawingMode(this);
        }

        public void PressMouse()
        {
            _state.PressMouse();
        }

        public void MoveMouse()
        {
            _state.MoveMouse();
        }

        public void ReleaseMouse()
        {
            _state.ReleaseMouse();
        }

        private void NotifyObserver()
        {
            ModelChanged?.Invoke(_shapes.GetShapes());
        }
    }
}
