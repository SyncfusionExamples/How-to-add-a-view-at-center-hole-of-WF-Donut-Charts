# How to add a view at center hole of WF Donut Charts

The [WinForms Chart Control](https://help.syncfusion.com/windowsforms/chart/getting-started) supports the [Doughnut chart](https://help.syncfusion.com/windowsforms/chart/chart-types#doughnut-chart) by specifying the [DoughnutCoefficient](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.ChartPieConfigItem.html#Syncfusion_Windows_Forms_Chart_ChartPieConfigItem_DoughnutCoeficient) property of the Pie chart.  Donut (or Doughnut chart) is a pie chart, which has a “hole” at the center. This article explains how to add your desired view on that hole.

Likewise, other platforms do not have direct support. But it has been achieved by hooking the [ChartAreaPaint](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.ChartControl.html#Syncfusion_Windows_Forms_Chart_ChartControl_ChartAreaPaint) event in the chart control and adjust its position to its chart hole by using the [Location](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.ChartArea.html#Syncfusion_Windows_Forms_Chart_ChartArea_Location) property.

Please find the step-by-step procedure to know how to achieve the above UI.

**Step1:** Create a chart control by including necessary packages and populating data to the chart. To know more about it, refer to this [link](https://help.syncfusion.com/windowsforms/chart/getting-started).

**Step2:** Add the chart type as Pie and getting the donut chart by using the [DoughnutCoefficient](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.ChartPieConfigItem.html#Syncfusion_Windows_Forms_Chart_ChartPieConfigItem_DoughnutCoeficient) property.
```
chartSeries = new ChartSeries();
chartSeries.Type = ChartSeriesType.Pie;
chartSeries.ConfigItems.PieItem.HeightCoeficient = 0.1f;
chartSeries.ConfigItems.PieItem.DoughnutCoeficient = 0.8f;
```

**Step3:** Add your desired view to the control. Here going to add a Label to display the product count in the center of the doughnut chart.
```
this.chartControl = new ChartControl();
//Event hook to add the desired view at the center of donut.
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

//Donut series added to the chart control.
this.chartControl.Series.Add(chartSeries);

this.centerLabel = new System.Windows.Forms.Label();

this.Controls.Add(this.centerLabel);
this.Controls.Add(this.chartControl);
```

**Step4:** Label placing position has been calculated by considering the label’s width and height and chart series bounds as shown below.
```
private void ChartControl1_ChartAreaPaint(object sender, System.Windows.Forms.PaintEventArgs e)
{
    //After the chart is loaded. 
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
```

## Output

![Winforms Doughnut chart](https://github.com/SyncfusionExamples/How-to-add-a-view-at-center-hole-of-WF-Donut-Charts/blob/main/Center_View_of_Donut_Chart.png)

KB article - [How to add a view at center hole of WF Donut Charts](https://www.syncfusion.com/kb/12484/how-to-add-a-view-at-center-hole-of-wf-donut-charts)

## See also

[How to customize doughnut chart angle offset in WF Charts](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.ChartPieConfigItem.html#Syncfusion_Windows_Forms_Chart_ChartPieConfigItem_AngleOffset)

[How to create Chart in VB .NET Windows Forms](https://www.syncfusion.com/kb/10806/how-to-create-chart-in-vb-net-windows-forms)

[How to add data to the WinForms chart control](https://www.syncfusion.com/kb/24/how-to-add-data-to-the-chartcontrol)
