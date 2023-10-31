using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public class FormPresentationModel
    {
        public delegate void FormPresentationModelChangedHandler(
            bool lineToolSelected,
            bool rectangleToolSelected,
            bool circleToolSelected,
            bool arrowToolSelected,
            Cursor currentCursor
        );
        public event FormPresentationModelChangedHandler FormPresentationModelChanged;
        private Model _model;
        private ShapeType _currentTool = ShapeType.Arrow;
        private Cursor _currentCursor = Cursors.Arrow;

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

        public void SelectTool(ShapeType shapeType)
        {
            _currentTool = shapeType;
            _model.SelectTool(shapeType);
            NotifyObserver();
        }

        public void enterPanel()
        {
            _currentCursor = _currentTool == ShapeType.Arrow ? Cursors.Arrow : Cursors.Cross;
            NotifyObserver();
        }

        public void leavePanel()
        {
            _currentCursor = Cursors.Arrow;
            NotifyObserver();
        }

        private void NotifyObserver()
        {
            FormPresentationModelChanged?.Invoke(
                _currentTool == ShapeType.Line,
                _currentTool == ShapeType.Rectangle,
                _currentTool == ShapeType.Circle,
                _currentTool == ShapeType.Arrow,
                _currentCursor
            );
        }
    }
}
