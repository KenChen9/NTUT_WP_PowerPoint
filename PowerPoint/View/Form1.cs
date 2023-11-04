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
        
        public MainForm(FormPresentationModel formPresentationModel)
        {
            InitializeComponent();
            _formPresentationModel = formPresentationModel;
        }

        private void LoadForm(object sender, EventArgs e)
        {
            _formPresentationModel.FormPresentationModelChanged += UpdateToolStrip;

            _deleteColumn.Text = "刪除";
            _deleteColumn.UseColumnTextForButtonValue = true;

            _shapeColumn.DataPropertyName = "Name";

            _infomationColumn.DataPropertyName = "Information";

            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.DataSource = _formPresentationModel.ShapeList;
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
            _formPresentationModel.PressMouse();
        }

        private void DoMouseUpOnPanel(object sender, MouseEventArgs e)
        {
            _formPresentationModel.ReleaseMouse();
        }

        private void DoMouseMoveOnPanel(object sender, MouseEventArgs e)
        {
            _formPresentationModel.MoveMouse();
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
            _formPresentationModel.DrawShapes(new WindowsFormsGraphics(e.Graphics));
        }

        private void UpdateToolStrip(Dictionary<ShapeType, bool> toolStatus, Cursor currentCursor)
        {
            _lineTool.Checked = toolStatus[ShapeType.Line];
            _rectangleTool.Checked = toolStatus[ShapeType.Rectangle];
            _circleTool.Checked = toolStatus[ShapeType.Circle];
            _arrowTool.Checked = toolStatus[ShapeType.Arrow];
            Cursor = currentCursor;
        }
    }
}
