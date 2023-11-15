
namespace PowerPoint
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._dataGroup = new System.Windows.Forms.GroupBox();
            this._shapeSelectionBox = new System.Windows.Forms.ComboBox();
            this._addShapeButton = new System.Windows.Forms.Button();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._locationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._lineTool = new System.Windows.Forms.ToolStripButton();
            this._rectangleTool = new System.Windows.Forms.ToolStripButton();
            this._circleTool = new System.Windows.Forms.ToolStripButton();
            this._arrowTool = new System.Windows.Forms.ToolStripButton();
            this._slidePanel = new System.Windows.Forms.Panel();
            this._slide1 = new System.Windows.Forms.Button();
            this._clearAllButton = new System.Windows.Forms.Button();
            this._dataGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._menuStrip.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this._slidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGroup
            // 
            this._dataGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGroup.Controls.Add(this._clearAllButton);
            this._dataGroup.Controls.Add(this._shapeSelectionBox);
            this._dataGroup.Controls.Add(this._addShapeButton);
            this._dataGroup.Controls.Add(this._dataGridView);
            this._dataGroup.Location = new System.Drawing.Point(963, 65);
            this._dataGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dataGroup.Name = "_dataGroup";
            this._dataGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dataGroup.Size = new System.Drawing.Size(333, 496);
            this._dataGroup.TabIndex = 0;
            this._dataGroup.TabStop = false;
            this._dataGroup.Text = "資料顯示";
            // 
            // _shapeSelectionBox
            // 
            this._shapeSelectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._shapeSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._shapeSelectionBox.FormattingEnabled = true;
            this._shapeSelectionBox.Items.AddRange(new object[] {
            "線",
            "矩形",
            "圓"});
            this._shapeSelectionBox.Location = new System.Drawing.Point(184, 40);
            this._shapeSelectionBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._shapeSelectionBox.Name = "_shapeSelectionBox";
            this._shapeSelectionBox.Size = new System.Drawing.Size(140, 23);
            this._shapeSelectionBox.TabIndex = 4;
            // 
            // _addShapeButton
            // 
            this._addShapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._addShapeButton.Location = new System.Drawing.Point(96, 26);
            this._addShapeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._addShapeButton.Name = "_addShapeButton";
            this._addShapeButton.Size = new System.Drawing.Size(80, 50);
            this._addShapeButton.TabIndex = 3;
            this._addShapeButton.Text = "新增";
            this._addShapeButton.UseVisualStyleBackColor = true;
            this._addShapeButton.Click += new System.EventHandler(this.ClickAddShapeButton);
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._locationColumn});
            this._dataGridView.Location = new System.Drawing.Point(8, 84);
            this._dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowTemplate.Height = 24;
            this._dataGridView.Size = new System.Drawing.Size(317, 405);
            this._dataGridView.TabIndex = 3;
            this._dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridCell);
            // 
            // _deleteColumn
            // 
            this._deleteColumn.HeaderText = "刪除";
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteColumn.Width = 40;
            // 
            // _shapeColumn
            // 
            this._shapeColumn.HeaderText = "形狀";
            this._shapeColumn.Name = "_shapeColumn";
            this._shapeColumn.ReadOnly = true;
            this._shapeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._shapeColumn.Width = 40;
            // 
            // _locationColumn
            // 
            this._locationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._locationColumn.HeaderText = "資訊";
            this._locationColumn.Name = "_locationColumn";
            this._locationColumn.ReadOnly = true;
            this._locationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._manualToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this._menuStrip.Size = new System.Drawing.Size(1312, 24);
            this._menuStrip.TabIndex = 1;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _manualToolStripMenuItem
            // 
            this._manualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._manualToolStripMenuItem.Name = "_manualToolStripMenuItem";
            this._manualToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this._manualToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineTool,
            this._rectangleTool,
            this._circleTool,
            this._arrowTool});
            this._toolStrip.Location = new System.Drawing.Point(0, 24);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(1312, 25);
            this._toolStrip.TabIndex = 2;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _lineTool
            // 
            this._lineTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineTool.Image = ((System.Drawing.Image)(resources.GetObject("_lineTool.Image")));
            this._lineTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineTool.Name = "_lineTool";
            this._lineTool.Size = new System.Drawing.Size(23, 22);
            this._lineTool.Text = "toolStripButton1";
            this._lineTool.Click += new System.EventHandler(this.ClickLineTool);
            // 
            // _rectangleTool
            // 
            this._rectangleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleTool.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleTool.Image")));
            this._rectangleTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleTool.Name = "_rectangleTool";
            this._rectangleTool.Size = new System.Drawing.Size(23, 22);
            this._rectangleTool.Text = "toolStripButton2";
            this._rectangleTool.Click += new System.EventHandler(this.ClickRectangleTool);
            // 
            // _circleTool
            // 
            this._circleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleTool.Image = ((System.Drawing.Image)(resources.GetObject("_circleTool.Image")));
            this._circleTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleTool.Name = "_circleTool";
            this._circleTool.Size = new System.Drawing.Size(23, 22);
            this._circleTool.Text = "toolStripButton3";
            this._circleTool.Click += new System.EventHandler(this.ClickCircleTool);
            // 
            // _arrowTool
            // 
            this._arrowTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._arrowTool.Image = ((System.Drawing.Image)(resources.GetObject("_arrowTool.Image")));
            this._arrowTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._arrowTool.Name = "_arrowTool";
            this._arrowTool.Size = new System.Drawing.Size(23, 22);
            this._arrowTool.Text = "toolStripButton4";
            this._arrowTool.Click += new System.EventHandler(this.ClickArrowTool);
            // 
            // _slidePanel
            // 
            this._slidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._slidePanel.BackColor = System.Drawing.Color.Silver;
            this._slidePanel.Controls.Add(this._slide1);
            this._slidePanel.Location = new System.Drawing.Point(16, 65);
            this._slidePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._slidePanel.Name = "_slidePanel";
            this._slidePanel.Size = new System.Drawing.Size(200, 496);
            this._slidePanel.TabIndex = 3;
            // 
            // _slide1
            // 
            this._slide1.BackColor = System.Drawing.Color.White;
            this._slide1.Location = new System.Drawing.Point(13, 12);
            this._slide1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this._slide1.Name = "_slide1";
            this._slide1.Size = new System.Drawing.Size(173, 100);
            this._slide1.TabIndex = 0;
            this._slide1.UseVisualStyleBackColor = false;
            // 
            // _clearAllButton
            // 
            this._clearAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._clearAllButton.Location = new System.Drawing.Point(8, 25);
            this._clearAllButton.Margin = new System.Windows.Forms.Padding(4);
            this._clearAllButton.Name = "_clearAllButton";
            this._clearAllButton.Size = new System.Drawing.Size(80, 50);
            this._clearAllButton.TabIndex = 5;
            this._clearAllButton.Text = "清空";
            this._clearAllButton.UseVisualStyleBackColor = true;
            this._clearAllButton.Click += new System.EventHandler(this.ClearAllShapes);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 576);
            this.Controls.Add(this._slidePanel);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._dataGroup);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "PowerPoint";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoKeyDown);
            this._dataGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._slidePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _dataGroup;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _lineTool;
        private System.Windows.Forms.ToolStripMenuItem _manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _rectangleTool;
        private System.Windows.Forms.ToolStripButton _circleTool;
        private System.Windows.Forms.ToolStripButton _arrowTool;
        private System.Windows.Forms.ComboBox _shapeSelectionBox;
        private System.Windows.Forms.Button _addShapeButton;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.Panel _slidePanel;
        private System.Windows.Forms.Button _slide1;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _locationColumn;
        private System.Windows.Forms.Button _clearAllButton;
    }
}

