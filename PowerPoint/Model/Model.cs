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

        private void NotifyObserver()
        {
            ModelChanged?.Invoke(_shapes.GetShapes());
        }
    }
}
