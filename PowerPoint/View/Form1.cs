using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class MainForm : Form
    {
        private FormPresentationModel _formPresentationModel;
        
        public MainForm(Model model)
        {
            InitializeComponent();
            _formPresentationModel = new FormPresentationModel(model);
            model.ModelChanged += UpdateDataGridView;
            _formPresentationModel.FormPresentationModelChanged += UpdateToolStrip;
        }

        private void ClickLineTool(object sender, EventArgs e)
        {
            _formPresentationModel.SelectTool(ShapeType.Line);
        }

        private void ClickRectangleTool(object sender, EventArgs e)
        {
            _formPresentationModel.SelectTool(ShapeType.Rectangle);
        }

        private void ClickCircleTool(object sender, EventArgs e)
        {
            _formPresentationModel.SelectTool(ShapeType.Circle);
        }

        private void ClickArrowTool(object sender, EventArgs e)
        {
            _formPresentationModel.SelectTool(ShapeType.Arrow);
        }

        private void ClickAddShapeButton(object sender, EventArgs e)
        {
            _formPresentationModel.AddShape(_shapeSelectionBox.Text);
        }

        private void ClickDataGridCell(object sender, DataGridViewCellEventArgs e)
        {
            _formPresentationModel.RemoveShapeAt(e.RowIndex, e.ColumnIndex);
        }

        private void DoMouseDownOnPanel(object sender, MouseEventArgs e)
        {
            _formPresentationModel.();
        }

        private void DoMouseUpOnPanel(object sender, MouseEventArgs e)
        {
            _formPresentationModel.PressMouse();
        }

        private void DoMouseMoveOnPanel(object sender, MouseEventArgs e)
        {
            _formPresentationModel.ReleaseMouse();
        }

        private void DoMouseEnterOnPanel(object sender, EventArgs e)
        {
            _formPresentationModel.EnterPanel();
        }

        private void DoMouseLeaveOnPanel(object sender, EventArgs e)
        {
            _formPresentationModel.LeavePanel();
        }

        private void DoPaintOnPanel(object sender, PaintEventArgs e)
        {

        }

        private void UpdateDataGridView(List<Shape> shapes)
        {
            _dataGridView.Rows.Clear();
            shapes.ForEach(shape => _dataGridView.Rows.Add("刪除", shape.GetName(), shape.GetInfo()));
        }

        private void UpdateToolStrip(bool lineToolSelected, bool rectangleToolSelected, bool circleToolSelected, bool arrowToolSelected, Cursor currentCursor)
        {
            _lineTool.Checked = lineToolSelected;
            _rectangleTool.Checked = rectangleToolSelected;
            _circleTool.Checked = circleToolSelected;
            _arrowTool.Checked = arrowToolSelected;
            Cursor = currentCursor;
        }
    }
}
