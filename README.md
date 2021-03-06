# How to add a view at center hole of WF Donut Charts
[WinForms Chart Control](https://help.syncfusion.com/windowsforms/chart/getting-started) supports a [Donut chart](https://help.syncfusion.com/windowsforms/chart/chart-types#doughnut-chart) by specifying with [DoughnutCoefficient](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.ChartPieConfigItem.html#Syncfusion_Windows_Forms_Chart_ChartPieConfigItem_DoughnutCoeficient) property of Pie chart.  Donut (or Doughnut chart) is actually a pie chart in additional having a “hole” at center. This article explains how to add your desired view on that hole. 
Likewise, in other platforms, doesn’t have a direct support. But it has been achieved by hooking [ChartAreaPaint](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Chart.ChartControl.html#Syncfusion_Windows_Forms_Chart_ChartControl_ChartAreaPaint) event in the chart control and adjust its position to its chart hole by using the Location property.

![](https://github.com/SyncfusionExamples/How-to-add-a-view-at-center-hole-of-WF-Donut-Charts/blob/main/Center_View_of_Donut_Chart.png)

To know more about this, please refer [this article](https://www.syncfusion.com/kb/12484/?utm_medium=listing&utm_source=github-examples)
