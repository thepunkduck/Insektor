namespace Insektor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chartViewer1 = new ChartLib.ChartViewer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxCATEGORY = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxITEM = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxX = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxY = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToCategoryPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartViewer1
            // 
            this.chartViewer1.AxisColor = System.Drawing.Color.Black;
            this.chartViewer1.BoldFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.chartViewer1.BorderFactorWithoutTitle = 2D;
            this.chartViewer1.BorderFactorWithTitle = 6D;
            this.chartViewer1.ClipDataToPlotAreaX = true;
            this.chartViewer1.ClipDataToPlotAreaY = true;
            this.chartViewer1.CursorSize = 20;
            this.chartViewer1.CursorThickness = 2;
            this.chartViewer1.CursorXcolor = System.Drawing.Color.Empty;
            this.chartViewer1.CursorYcolor = System.Drawing.Color.Empty;
            this.chartViewer1.DataList = ((System.Collections.Generic.List<object>)(resources.GetObject("chartViewer1.DataList")));
            this.chartViewer1.Debug = false;
            this.chartViewer1.DefaultSettings = null;
            this.chartViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartViewer1.Enabled = false;
            this.chartViewer1.EnablePropertiesDialog = true;
            this.chartViewer1.ErrorString = null;
            this.chartViewer1.ExtendedStatusStrip = null;
            this.chartViewer1.FixAspect = false;
            this.chartViewer1.FixedBottomBorder = -1;
            this.chartViewer1.FixedLeftBorder = -1;
            this.chartViewer1.FixedRightBorder = -1;
            this.chartViewer1.FixedTopBorder = -1;
            this.chartViewer1.FocusOnEnter = false;
            this.chartViewer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chartViewer1.Freeze = false;
            this.chartViewer1.FullDrawWhenMoving = false;
            this.chartViewer1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(139)))));
            this.chartViewer1.ImageTitle = null;
            this.chartViewer1.IsShown = true;
            this.chartViewer1.KeyBoldFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.chartViewer1.KeyBuffer = null;
            this.chartViewer1.KeyFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chartViewer1.Location = new System.Drawing.Point(0, 49);
            this.chartViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartViewer1.MoveLimitBottom = double.NaN;
            this.chartViewer1.MoveLimitLeft = double.NaN;
            this.chartViewer1.MoveLimitRight = double.NaN;
            this.chartViewer1.MoveLimitTop = double.NaN;
            this.chartViewer1.MoveMode = false;
            this.chartViewer1.Name = "chartViewer1";
            this.chartViewer1.NormalFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chartViewer1.PointerReadoutControl = null;
            this.chartViewer1.ReadoutText = "         ***";
            this.chartViewer1.ScalebarText = "*";
            this.chartViewer1.SelectionBG = System.Drawing.Color.Blue;
            this.chartViewer1.SelectionEnabled = false;
            this.chartViewer1.SelectionFG = System.Drawing.Color.White;
            this.chartViewer1.ShowError = false;
            this.chartViewer1.ShowKeyExternal = false;
            this.chartViewer1.ShowKeyInternal = false;
            this.chartViewer1.ShowPointerReadout = false;
            this.chartViewer1.ShowReadout = false;
            this.chartViewer1.ShowScalebar = false;
            this.chartViewer1.ShowVerticalEllipse = false;
            this.chartViewer1.ShowXAxisTitle = true;
            this.chartViewer1.ShowYAxisTitle = true;
            this.chartViewer1.Size = new System.Drawing.Size(864, 561);
            this.chartViewer1.SmallFont = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.chartViewer1.SpringLoadedKey = System.Windows.Forms.Keys.Space;
            this.chartViewer1.SymFont = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.chartViewer1.TabIndex = 0;
            this.chartViewer1.Title = "Insektor!";
            this.chartViewer1.Title2 = null;
            this.chartViewer1.XAuto = true;
            this.chartViewer1.XAutoBorder = 0D;
            this.chartViewer1.XAutoRounding = false;
            this.chartViewer1.XAxisAutoZero = true;
            this.chartViewer1.XAxisBottom = true;
            this.chartViewer1.XAxisGridOrder = ChartLib.OrderCode.BeforeObjects;
            this.chartViewer1.XAxisMinTickDelta = -1.7976931348623157E+308D;
            this.chartViewer1.XAxisPolarity = ChartLib.AxisPolarity.Normal;
            this.chartViewer1.XAxisScaleMultiplier = ChartLib.AxisScaleMultiplier.Decimal;
            this.chartViewer1.XAxisScaleTextFormat = null;
            this.chartViewer1.XAxisScaleType = ChartLib.ScaleType.Linear;
            this.chartViewer1.XAxisTicks = true;
            this.chartViewer1.XAxisTitle = "X Axis";
            this.chartViewer1.XAxisTop = false;
            this.chartViewer1.XLeft = 0D;
            this.chartViewer1.XRight = 1D;
            this.chartViewer1.XTitleOffset = -1;
            this.chartViewer1.YAuto = true;
            this.chartViewer1.YAutoBorder = 0D;
            this.chartViewer1.YAutoRounding = false;
            this.chartViewer1.YAxisAutoZero = true;
            this.chartViewer1.YAxisGridOrder = ChartLib.OrderCode.BeforeObjects;
            this.chartViewer1.YAxisLeft = true;
            this.chartViewer1.YAxisMinTickDelta = -1.7976931348623157E+308D;
            this.chartViewer1.YAxisPolarity = ChartLib.AxisPolarity.Normal;
            this.chartViewer1.YAxisRight = false;
            this.chartViewer1.YAxisScaleMultiplier = ChartLib.AxisScaleMultiplier.Decimal;
            this.chartViewer1.YAxisScaleTextFormat = null;
            this.chartViewer1.YAxisScaleType = ChartLib.ScaleType.Linear;
            this.chartViewer1.YAxisTicks = true;
            this.chartViewer1.YAxisTitle = "Y Axis";
            this.chartViewer1.YBottom = 0D;
            this.chartViewer1.YTitleOffset = -1;
            this.chartViewer1.YTop = 1D;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripComboBoxCATEGORY,
            this.toolStripLabel3,
            this.toolStripComboBoxITEM,
            this.toolStripLabel1,
            this.toolStripComboBoxX,
            this.toolStripLabel2,
            this.toolStripComboBoxY,
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel4.Text = "Category:";
            // 
            // toolStripComboBoxCATEGORY
            // 
            this.toolStripComboBoxCATEGORY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxCATEGORY.MaxDropDownItems = 20;
            this.toolStripComboBoxCATEGORY.Name = "toolStripComboBoxCATEGORY";
            this.toolStripComboBoxCATEGORY.Size = new System.Drawing.Size(180, 25);
            this.toolStripComboBoxCATEGORY.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxCATEGORY_SelectedIndexChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel3.Text = "   Item:";
            // 
            // toolStripComboBoxITEM
            // 
            this.toolStripComboBoxITEM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxITEM.DropDownWidth = 120;
            this.toolStripComboBoxITEM.MaxDropDownItems = 20;
            this.toolStripComboBoxITEM.Name = "toolStripComboBoxITEM";
            this.toolStripComboBoxITEM.Size = new System.Drawing.Size(140, 25);
            this.toolStripComboBoxITEM.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxITEM_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "    X:";
            // 
            // toolStripComboBoxX
            // 
            this.toolStripComboBoxX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxX.MaxDropDownItems = 20;
            this.toolStripComboBoxX.Name = "toolStripComboBoxX";
            this.toolStripComboBoxX.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxX.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxX_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(17, 22);
            this.toolStripLabel2.Text = "Y:";
            // 
            // toolStripComboBoxY
            // 
            this.toolStripComboBoxY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxY.MaxDropDownItems = 20;
            this.toolStripComboBoxY.Name = "toolStripComboBoxY";
            this.toolStripComboBoxY.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxY.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxY_SelectedIndexChanged);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButtonREVERSEAXES_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton1.Text = "More...";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(864, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(315, 610);
            this.propertyGrid1.TabIndex = 3;
            this.propertyGrid1.Visible = false;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGrid1_PropertyValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCategoryToolStripMenuItem,
            this.explorerToCategoryPathToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteCategoryToolStripMenuItem
            // 
            this.deleteCategoryToolStripMenuItem.Name = "deleteCategoryToolStripMenuItem";
            this.deleteCategoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteCategoryToolStripMenuItem.Text = "Delete Category";
            this.deleteCategoryToolStripMenuItem.Click += new System.EventHandler(this.DeleteCategoryToolStripMenuItem_Click);
            // 
            // explorerToCategoryPathToolStripMenuItem
            // 
            this.explorerToCategoryPathToolStripMenuItem.Name = "explorerToCategoryPathToolStripMenuItem";
            this.explorerToCategoryPathToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.explorerToCategoryPathToolStripMenuItem.Text = "Explorer to Category Path...";
            this.explorerToCategoryPathToolStripMenuItem.Click += new System.EventHandler(this.ExplorerToCategoryPathToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 610);
            this.Controls.Add(this.chartViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.propertyGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Insektor!";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChartLib.ChartViewer chartViewer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxITEM;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxCATEGORY;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToCategoryPathToolStripMenuItem;
    }
}