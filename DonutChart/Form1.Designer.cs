
using Syncfusion.Windows.Forms.Chart;
using System.Drawing;

namespace DonutChart
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
        private ChartControl chartControl;
        private System.Windows.Forms.Label centerLabel;
        private ChartSeries chartSeries;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.chartControl = new ChartControl();
            this.chartControl.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LightBlue);
            this.chartControl.Location = new System.Drawing.Point(143, 55);
            this.chartControl.Palette = ChartColorPalette.Nature;
            this.chartControl.Size = new System.Drawing.Size(452, 331);
            this.chartControl.TabIndex = 2;
            this.chartControl.Text = "Doughnut Chart";
            //Event hook to add desired view at the center of donut
            chartControl.ChartAreaPaint += ChartControl1_ChartAreaPaint;

            chartSeries = new ChartSeries();
            chartSeries.Type = ChartSeriesType.Pie;
            chartSeries.ConfigItems.PieItem.HeightCoeficient = 0.1f;
            chartSeries.ConfigItems.PieItem.DoughnutCoeficient = 0.8f;
            chartSeries.Points.Add(new ChartPoint(0, 12));
            chartSeries.Points.Add(new ChartPoint(0, 14));
            chartSeries.Points.Add(new ChartPoint(0, 24));
            chartSeries.Points.Add(new ChartPoint(0, 18));
            chartSeries.Points.Add(new ChartPoint(0, 20));

            //Donut series added to chart control
            this.chartControl.Series.Add(chartSeries);

            this.centerLabel = new System.Windows.Forms.Label();
            this.Controls.Add(this.centerLabel);
            this.Controls.Add(this.chartControl);

            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void ChartControl1_ChartAreaPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //After chart loaded. 
            this.centerLabel.AutoSize = true;
            this.centerLabel.Size = new System.Drawing.Size(10, 13);
            this.centerLabel.TabIndex = 3;
            this.centerLabel.Text = "5 \r\nTOTAL \r\nPRODUCTS";
            this.centerLabel.Font = new Font("", 10, FontStyle.Bold);
            this.centerLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.centerLabel.BackColor = chartControl.ChartArea.BackInterior.BackColor;

            int labelWidth = centerLabel.Size.Width;
            int labelHeight = centerLabel.Size.Height;
            var areaBound = chartControl.ChartArea.GetSeriesBounds(chartSeries);
            var chartBound = chartControl.Location;
            var center = chartControl.ChartArea.Center;
            //Center label location.
            int x = (int)((chartBound.X + areaBound.X) + ((areaBound.Width / 2 - labelWidth / 2)));
            int y = (int)((chartBound.Y + areaBound.Y) + ((areaBound.Height / 2 - labelHeight / 2)));
            this.centerLabel.Location = new System.Drawing.Point((int)x, (int)y);
        }
        #endregion
    }
}

