using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class MainForm : Form
    {
        private FormPresentationModel _formPresentationModel;
        private DoubleBufferedPanel _drawingPanel = new DoubleBufferedPanel();
        
        public MainForm(FormPresentationModel formPresentationModel)
        {
            InitializeComponent();
            _formPresentationModel = formPresentationModel;

            _formPresentationModel.ToolCursorChanged += UpdateToolCursor;
            _formPresentationModel.ShapeListChanged += UpdateDrawingPanel;

            _deleteColumn.Text = "刪除";
            _deleteColumn.UseColumnTextForButtonValue = true;

            _shapeColumn.DataPropertyName = "Name";

            _infomationColumn.DataPropertyName = "Information";

            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.DataSource = _formPresentationModel.ShapeList;

            _drawingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _drawingPanel.BackColor = System.Drawing.Color.White;
            _drawingPanel.Location = new System.Drawing.Point(168, 52);
            _drawingPanel.Name = "_drawingPanel";
            _drawingPanel.Size = new System.Drawing.Size(548, 397);
            _drawingPanel.TabIndex = 4;
            _drawingPanel.Paint += new PaintEventHandler(DoPaintOnPanel);
            _drawingPanel.MouseDown += new MouseEventHandler(DoMouseDownOnPanel);
            _drawingPanel.MouseEnter += new EventHandler(DoMouseEnterOnPanel);
            _drawingPanel.MouseLeave += new EventHandler(DoMouseLeaveOnPanel);
            _drawingPanel.MouseMove += new MouseEventHandler(DoMouseMoveOnPanel);
            _drawingPanel.MouseUp += new MouseEventHandler(DoMouseUpOnPanel);
            Controls.Add(_drawingPanel);
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
            _formPresentationModel.MoveMouse(e.X, e.Y);
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

        private void UpdateToolCursor(Dictionary<ShapeType, bool> toolStatus, Cursor currentCursor)
        {
            _lineTool.Checked = toolStatus[ShapeType.Line];
            _rectangleTool.Checked = toolStatus[ShapeType.Rectangle];
            _circleTool.Checked = toolStatus[ShapeType.Circle];
            _arrowTool.Checked = toolStatus[ShapeType.Arrow];
            Cursor = currentCursor;
        }

        private void UpdateDrawingPanel()
        {
            _drawingPanel.Invalidate();
        }
    }
}
