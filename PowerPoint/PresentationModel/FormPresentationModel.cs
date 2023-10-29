using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class FormPresentationModel
    {
        private Model _model;

        public FormPresentationModel(Model model)
        {
            _model = model;
        }

        public void AddShape(string shapeType)
        {
            _model.AddShape(shapeType);
        }

        public void RemoveShapeAt(int rowIndex, int columnIndex)
        {
            _model.RemoveShapeAt(rowIndex, columnIndex);
        }
    }
}
