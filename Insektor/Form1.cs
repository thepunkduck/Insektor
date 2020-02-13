using InsektorComm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insektor
{
    public partial class Form1 : Form
    {

        Timer timer;
        SnapshotCategory _ssCat;
        SnapshotCategory SSCat
        {
            get { return (_ssCat); }
            set { _ssCat = value; propertyGrid1.SelectedObject = _ssCat; }
        }
        string xTitle;
        string yTitle;
        List<double> dxList;
        List<double> dyList;
        bool isDirty = false;




        public Form1()
        {
            InitializeComponent();

            Snapshot.Initialize();
            Snapshot.DataAdded += Snapshot_DataAdded;
            chartViewer1.Enabled = true;

            chartViewer1.AddCustomDraw("main", null,
                 delegate (object data, Rectangle viewport, RectangleF dataport, Graphics graphics, Graphics overlayGraphics)
                 {
                     try
                     {
                         var cV = chartViewer1;
                         var vA = cV.VArea;

                         if (SSCat == null) return;
                         var sItem = SSCat.GetSelectedItem();

                         Pen pen = new Pen(SSCat.LineColor, SSCat.LineWidth);
                         Brush br = new SolidBrush(SSCat.PointColor);

                         if (dyList != null && dxList != null)
                         {
                             List<PointF> pts = new List<PointF>();
                             for (int i = 0; i < dxList.Count; i++)
                             {
                                 if (chkNum(dxList[i]) && chkNum(dyList[i]))
                                     pts.Add(vA.realToScreenPointF(dxList[i], dyList[i]));

                             }

                             switch (SSCat.ChartStyle)
                             {
                                 case ChartStyle.Linear:
                                     if (pts.Count >= 2)
                                         graphics.DrawLines(pen, pts.ToArray());
                                     _drawPoints(graphics, pts, SSCat, br);
                                     break;
                                 case ChartStyle.Curve:
                                     if (pts.Count >= 2)
                                         graphics.DrawCurve(pen, pts.ToArray());
                                     _drawPoints(graphics, pts, SSCat, br);
                                     break;
                                 case ChartStyle.HistoX:
                                     {
                                         float rectW = Math.Max(SSCat.PointSize, Math.Abs(pts[0].X - pts[1].X))/2;
                                         graphics.TranslateTransform(-rectW / 2, 0);
                                         float zeroY = (float)vA.realToScreenY(0);
                                         foreach (var pt in pts)
                                         {
                                             if (pt.Y > zeroY)
                                                 graphics.FillRectangle(br, pt.X, zeroY, rectW, pt.Y - zeroY);
                                             else
                                                 graphics.FillRectangle(br, pt.X, pt.Y, rectW, zeroY - pt.Y);
                                         }
                                         graphics.ResetTransform();
                                     }
                                     break;


                                 case ChartStyle.HistoY:
                                     {
                                         float rectH = Math.Max(SSCat.PointSize, Math.Abs(pts[0].Y - pts[1].Y)/2);
                                         graphics.TranslateTransform(0, -rectH / 2);
                                         float zeroX = (float)vA.realToScreenX(0);
                                         foreach (var pt in pts)
                                         {
                                             if (pt.X > zeroX)
                                                 graphics.FillRectangle(br, zeroX, pt.Y, pt.X-zeroX, rectH);
                                             else
                                                 graphics.FillRectangle(br, pt.X, pt.Y, zeroX-pt.X, rectH);
                                         }
                                         graphics.ResetTransform();
                                     }


                                     break;
                                 default:
                                     break;
                             }




                         }
                     }
                     catch (Exception ex)
                     {

                     }
                 });


            timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
            timer.Start();

            Snapshot_DataAdded(null, null);

            Application.Idle += Application_Idle;
        }

        private void _drawPoints(Graphics graphics, List<PointF> pts, SnapshotCategory sc, Brush br)
        {
            graphics.TranslateTransform(-sc.PointSize / 2, -sc.PointSize / 2);
            float sz = sc.PointSize;
            foreach (var point in pts) graphics.FillRectangle(br, point.X, point.Y, sz, sz);
            graphics.ResetTransform();
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (!isDirty) return;
            isDirty = false;
            _refresh();
        }

        private bool chkNum(double v)
        {
            if (double.IsNaN(v) || double.IsInfinity(v) || v > 1E30 || v < -1E30) return (false);
            return (true);
        }

        private void Snapshot_DataAdded(object sender, EventArgs e)
        {
            isDirty = true;
        }


        private void _getPlotData()
        {
            SSCat = toolStripComboBoxCATEGORY.SelectedItem as SnapshotCategory;
            if (SSCat != null)
            {
                SnapshotItem sItem = SSCat.GetSelectedItem();

                xTitle = toolStripComboBoxX.SelectedItem as string;
                yTitle = toolStripComboBoxY.SelectedItem as string;
                dxList = sItem != null ? sItem.GetDoubleArray(xTitle) : null;
                dyList = sItem != null ? sItem.GetDoubleArray(yTitle) : null;

                SSCat.XAxis = xTitle;
                SSCat.YAxis = yTitle;

                double minX = double.MaxValue;
                double maxX = double.MinValue;
                double minY = double.MaxValue;
                double maxY = double.MinValue;
                if (dxList != null)
                    foreach (var v in dxList) if (chkNum(v)) { minX = Math.Min(minX, v); maxX = Math.Max(maxX, v); }
                if (dyList != null)
                    foreach (var v in dyList) if (chkNum(v)) { minY = Math.Min(minY, v); maxY = Math.Max(maxY, v); }
                if (minX == double.MaxValue) { minX = 0; maxX = 1; }
                if (minY == double.MaxValue) { minY = 0; maxY = 1; }

                if (minX == maxX) { minX -= 1; maxX += 1; }
                else { var d = (maxX - minX) / 10; minX -= d; maxX += d; }
                if (minY == maxY) { minY -= 1; maxY += 1; }
                { var d = (maxY - minY) / 10; minY -= d; maxY += d; }

                chartViewer1.XAuto = false;
                chartViewer1.YAuto = false;


                if (SSCat.XAxisAuto)
                {
                    if (SSCat.XPolarity == Polarity.Normal)
                    {
                        chartViewer1.XLeft = minX;
                        chartViewer1.XRight = maxX;
                    }
                    else
                    {
                        chartViewer1.XLeft = maxX;
                        chartViewer1.XRight = minX;
                    }
                }
                else
                {
                    if (SSCat.XPolarity == Polarity.Normal)
                    {
                        chartViewer1.XLeft = SSCat.XAxisMin;
                        chartViewer1.XRight = SSCat.XAxisMax;
                    }
                    else
                    {
                        chartViewer1.XLeft = SSCat.XAxisMax;
                        chartViewer1.XRight = SSCat.XAxisMin;
                    }
                }
                if (SSCat.YAxisAuto)
                {
                    if (SSCat.YPolarity == Polarity.Normal)
                    {
                        chartViewer1.YTop = maxY;
                        chartViewer1.YBottom = minY;
                    }
                    else
                    {
                        chartViewer1.YTop = minY;
                        chartViewer1.YBottom = maxY;
                    }
                }
                else
                {
                    if (SSCat.YPolarity == Polarity.Normal)
                    {
                        chartViewer1.YTop = SSCat.YAxisMax;
                        chartViewer1.YBottom = SSCat.YAxisMin;
                    }
                    else
                    {
                        chartViewer1.YTop = SSCat.YAxisMin;
                        chartViewer1.YBottom = SSCat.YAxisMax;
                    }
                }

                chartViewer1.XAxisTitle = xTitle;
                chartViewer1.YAxisTitle = yTitle;

                chartViewer1.Title = SSCat.Name + "    :    " + (sItem != null ? sItem.FormattedTime : "*");
                chartViewer1.Title2 = yTitle + " vs " + xTitle;


                SSCat.WriteSettings();
            }

        }


        private void _refresh()
        {
            // set up what to show
            //   if (selectedSnapshotCategory == null) return;



            // combo boxes
            var tmp = toolStripComboBoxCATEGORY.SelectedItem as SnapshotCategory;
            // CAT/ITEM/X/Y
            var all = Snapshot.GetCollection();
            toolStripComboBoxCATEGORY.ComboBox.DisplayMember = "Name";
            toolStripComboBoxCATEGORY.ComboBox.ValueMember = "Name";
            toolStripComboBoxCATEGORY.ComboBox.DataSource = all;
            toolStripComboBoxCATEGORY.SelectedItem = Snapshot.GetSnapshotCategory(all, tmp != null ? tmp.Name : null);

            _getPlotData();

            chartViewer1.Redraw();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Snapshot.WriteRunningViewerStatus();
        }

        private void ToolStripComboBoxCATEGORY_SelectedIndexChanged(object sender, EventArgs e)
        {
            SSCat = toolStripComboBoxCATEGORY.SelectedItem as SnapshotCategory;
            var xaxis = SSCat != null ? SSCat.XAxis : null;
            var yaxis = SSCat != null ? SSCat.YAxis : null;
            var fullName = (SSCat != null && SSCat.Selected != null) ? SSCat.Selected.FullName : null;
            toolStripComboBoxITEM.ComboBox.DisplayMember = "Name";
            toolStripComboBoxITEM.ComboBox.ValueMember = "FullName";
            toolStripComboBoxITEM.ComboBox.DataSource = (SSCat != null) ? SSCat.Collection : null;

            toolStripComboBoxITEM.SelectedItem = (SSCat != null) ? SSCat.GetSnapshotItem(fullName) : null;
            toolStripComboBoxX.SelectedItem = xaxis;
            toolStripComboBoxY.SelectedItem = yaxis;

            _getPlotData();
            chartViewer1.Redraw();
        }

        private void ToolStripComboBoxITEM_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update with selected snapsots items'
            SSCat = toolStripComboBoxCATEGORY.SelectedItem as SnapshotCategory;
            var xaxis = SSCat != null ? SSCat.XAxis : null;
            var yaxis = SSCat != null ? SSCat.YAxis : null;

            if (SSCat != null) SSCat.Selected = toolStripComboBoxITEM.SelectedItem as SnapshotItem;

            SnapshotItem sItem = SSCat != null ? SSCat.GetSelectedItem() : null;

            if (sItem != null)
            {
                toolStripComboBoxX.ComboBox.DataSource = sItem.GetHeaderTitles();
                toolStripComboBoxX.SelectedItem = xaxis;
                toolStripComboBoxY.ComboBox.DataSource = sItem.GetHeaderTitles();
                toolStripComboBoxY.SelectedItem = yaxis;
            }
            else
            {
                toolStripComboBoxX.ComboBox.DataSource = null;
                toolStripComboBoxX.SelectedItem = null;
                toolStripComboBoxY.ComboBox.DataSource = null;
                toolStripComboBoxY.SelectedItem = null;
            }
            _getPlotData();
            chartViewer1.Redraw();
        }

        private void ToolStripComboBoxX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SSCat != null) SSCat.XAxis = toolStripComboBoxX.SelectedItem as string;
            _getPlotData();
            chartViewer1.Redraw();
        }

        private void ToolStripComboBoxY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SSCat != null) SSCat.YAxis = toolStripComboBoxY.SelectedItem as string;
            _getPlotData();
            chartViewer1.Redraw();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            //open/ close
            propertyGrid1.Visible = !propertyGrid1.Visible;
            propertyGrid1.SelectedObject = SSCat;
        }

        private void PropertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (SSCat != null) SSCat.WriteSettings();
            _getPlotData();
            chartViewer1.Redraw();
        }

        private void ToolStripButtonREVERSEAXES_Click(object sender, EventArgs e)
        {
            // reverse
            if (SSCat!=null)
            {
                if (SSCat.ChartStyle == ChartStyle.HistoX) SSCat.ChartStyle = ChartStyle.HistoY;
                else if (SSCat.ChartStyle == ChartStyle.HistoY) SSCat.ChartStyle = ChartStyle.HistoX;
            }
            var selX = toolStripComboBoxX.SelectedItem as string;
            var selY = toolStripComboBoxY.SelectedItem as string;
            toolStripComboBoxX.SelectedItem = selY;
            toolStripComboBoxY.SelectedItem = selX;

        }

        private void DeleteCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete category
            Snapshot.Delete(SSCat);
            toolStripComboBoxCATEGORY.SelectedItem = null;

            SSCat = null;
            _refresh();
        }

        private void ExplorerToCategoryPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SSCat != null)
                System.Diagnostics.Process.Start(SSCat.Directory);
        }
    }
}
