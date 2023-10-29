using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model
    {
        private Shapes _shapes = new Shapes();

        public void AddShape(string shapeType)
        {
            _shapes.Add(shapeType);
        }

        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _shapes.RemoveAt(rowIndex);
            }
        }
    }
}
