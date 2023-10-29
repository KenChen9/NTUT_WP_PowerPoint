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
        }

        private void ClickLineTool(object sender, EventArgs e)
        {

        }

        private void ClickRectangleTool(object sender, EventArgs e)
        {

        }

        private void ClickCircleTool(object sender, EventArgs e)
        {
            
        }

        private void ClickArrowTool(object sender, EventArgs e)
        {

        }

        private void ClickAddShapeButton(object sender, EventArgs e)
        {
            _formPresentationModel.AddShape(_shapeSelectionBox.Text);
        }

        private void ClickDataGridCell(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DoMouseDownOnPanel(object sender, MouseEventArgs e)
        {

        }

        private void DoMouseUpOnPanel(object sender, MouseEventArgs e)
        {

        }

        private void DoMouseMoveOnPanel(object sender, MouseEventArgs e)
        {

        }

        private void DoMouseEnterOnPanel(object sender, EventArgs e)
        {

        }

        private void DoMouseLeaveOnPanel(object sender, EventArgs e)
        {

        }

        private void DoPanelOnPanel(object sender, PaintEventArgs e)
        {
            
        }
    }
}
