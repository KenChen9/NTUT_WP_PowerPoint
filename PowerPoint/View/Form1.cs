using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace PowerPoint
{
    public partial class MainForm : Form
    {
        private FormPresentationModel _formPresentationModel;
        private DoubleBufferedPanel _drawingPanel = new DoubleBufferedPanel();
        
        public MainForm(FormPresentationModel formPresentationModel)
        {
            Debug.Assert(formPresentationModel != null);
            InitializeComponent();
            KeyPreview = true;
            _formPresentationModel = formPresentationModel;
            InitializeEventHandlers();
            InitializeDataGridViewControls();
            InitializeDrawingPanel();
        }

        // Comment
        private void InitializeDataGridViewControls()
        {
            _deleteColumn.Text = "刪除";
            _deleteColumn.UseColumnTextForButtonValue = true;
            _shapeColumn.DataPropertyName = "Name";
            _locationColumn.DataPropertyName = "Information";
            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.DataSource = _formPresentationModel.ShapeList;
        }

        // Comment
        private void InitializeDrawingPanel()
        {
            _drawingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _drawingPanel.BackColor = Color.White;
            _drawingPanel.Location = new Point(168, 52);
            _drawingPanel.Name = "_drawingPanel";
            _drawingPanel.Size = new Size(548, 397);
            _drawingPanel.Paint += new PaintEventHandler(DoPaintOnPanel);
            _drawingPanel.MouseDown += new MouseEventHandler(DoMouseDownOnPanel);
            _drawingPanel.MouseEnter += new EventHandler(DoMouseEnterOnPanel);
            _drawingPanel.MouseLeave += new EventHandler(DoMouseLeaveOnPanel);
            _drawingPanel.MouseMove += new MouseEventHandler(DoMouseMoveOnPanel);
            _drawingPanel.MouseUp += new MouseEventHandler(DoMouseUpOnPanel);
            Controls.Add(_drawingPanel);
        }

        // Comment
        private void InitializeEventHandlers()
        {
            _formPresentationModel.ToolsChanged += UpdateTools;
            _formPresentationModel.CursorChanged += UpdateCursor;
            _formPresentationModel.ShapesChanged += UpdateDrawingPanel;
            _formPresentationModel.SlidesChanged += UpdateSlides;
        }

        // Comment
        private void ClickLineTool(object sender, EventArgs e)
        {
            _formPresentationModel.SelectTool(ShapeType.Line);
        }

        // Comment
        private void ClickRectangleTool(object sender, EventArgs e)
        {
            _formPresentationModel.SelectTool(ShapeType.Rectangle);
        }

        // Comment
        private void ClickCircleTool(object sender, EventArgs e)
        {
            _formPresentationModel.SelectTool(ShapeType.Circle);
        }

        // Comment
        private void ClickArrowTool(object sender, EventArgs e)
        {
            _formPresentationModel.UnselectTool();
        }

        // Comment
        private void ClickAddShapeButton(object sender, EventArgs e)
        {
            const string LINE = "線";
            const string RECTANGLE = "矩形";
            const string CIRCLE = "圓";
            Debug.Assert(_shapeSelectionBox.Text == LINE || _shapeSelectionBox.Text == RECTANGLE || _shapeSelectionBox.Text == CIRCLE);
            _formPresentationModel.AddShape(_shapeSelectionBox.Text);
        }

        // Comment
        private void ClickDataGridCell(object sender, DataGridViewCellEventArgs e)
        {
            Debug.Assert(e != null);
            Debug.Assert(e.RowIndex >= 0);
            Debug.Assert(e.ColumnIndex >= 0);
            _formPresentationModel.RemoveShapeAt(e.RowIndex, e.ColumnIndex);
        }

        // Comment
        private void DoMouseDownOnPanel(object sender, MouseEventArgs e)
        {
            Debug.Assert(e.Location != null);
            Debug.Assert(_drawingPanel.Size != null);
            _formPresentationModel.PressMouse(new MyPoint(e.Location, _drawingPanel.Size));
        }

        // Comment
        private void DoMouseUpOnPanel(object sender, MouseEventArgs e)
        {
            Debug.Assert(e.Location != null);
            Debug.Assert(_drawingPanel.Size != null);
            _formPresentationModel.ReleaseMouse();
        }

        // Comment
        private void DoMouseMoveOnPanel(object sender, MouseEventArgs e)
        {
            Debug.Assert(e.Location != null);
            Debug.Assert(_drawingPanel.Size != null);
            _formPresentationModel.MoveMouse(new MyPoint(e.Location, _drawingPanel.Size));
        }

        // Comment
        private void DoMouseEnterOnPanel(object sender, EventArgs e)
        {
            _formPresentationModel.EnterPanel();
        }

        // Comment
        private void DoMouseLeaveOnPanel(object sender, EventArgs e)
        {
            _formPresentationModel.LeavePanel();
        }

        // Comment
        private void DoPaintOnPanel(object sender, PaintEventArgs e)
        {
            Debug.Assert(e.Graphics != null);
            _formPresentationModel.DrawShapes(new WindowsFormsGraphics(e.Graphics));
        }

        // Comment
        private void DoKeyDown(object sender, KeyEventArgs e)
        {
            Debug.Assert(e != null);
            if (e.KeyCode == Keys.Delete)
            {
                _formPresentationModel.RemoveSelectedShape();
            }
        }

        // Comment
        private void ClearAllShapes(object sender, EventArgs e)
        {
            _formPresentationModel.ClearAllShapes();
        }

        // Comment
        private void UpdateTools(bool lineToolChecked, bool rectangleToolChecked, bool circleToolChecked, bool arrowToolChecked)
        {
            _lineTool.Checked = lineToolChecked;
            _rectangleTool.Checked = rectangleToolChecked;
            _circleTool.Checked = circleToolChecked;
            _arrowTool.Checked = arrowToolChecked;
        }

        // Comment
        private void UpdateCursor(Cursor currentCursor)
        {
            Debug.Assert(currentCursor != null);
            Cursor = currentCursor;
        }

        // Comment
        private void UpdateDrawingPanel()
        {
            _drawingPanel.Invalidate();
        }

        // Comment
        private void UpdateSlides()
        {
            Bitmap bitmap = new Bitmap(_drawingPanel.Width, _drawingPanel.Height);
            _drawingPanel.DrawToBitmap(bitmap, new Rectangle(0, 0, _drawingPanel.Width, _drawingPanel.Height));
            _slide1.BackgroundImage = bitmap;
            _slide1.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
