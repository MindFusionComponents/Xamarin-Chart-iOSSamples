using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MindFusion.Drawing;

namespace IOSSamples
{
	public partial class AppPage : ContentPage
	{
		public AppPage ()
		{
			InitializeComponent ();
			// set MinValue and MaxValue of axes explicitly, or otherwise
			// the chart will loop over all data to set them automatically
			lineChart.XAxis.MinValue = 0;
			lineChart.XAxis.MaxValue = 50;
			lineChart.XAxis.Title = "X Axis";
			lineChart.YAxis.MinValue = -50;
			lineChart.YAxis.MaxValue = 150;
			lineChart.YAxis.Title = "Y Axis";

			// Generator.IsSorted returns true for X axis, so the chart uses O(log(n)) search algorithms
			lineChart.Series.Add(new Generator(500000, 1000000, 100) { Title = "Generated series 1" });
			lineChart.Series.Add(new Generator(250000, 20000, 50) { Title = "Generated series 2" });

			// customize appearance
			lineChart.ShowLegend = true;
			lineChart.AllowMoveLegend = false;
			lineChart.LegendTitle = "";
			lineChart.LegendHorizontalAlignment = MindFusion.Charting.Components.LayoutAlignment.Far;
			lineChart.LegendVerticalAlignment = MindFusion.Charting.Components.LayoutAlignment.Near;
			lineChart.Theme.LegendBackground = Brushes.Transparent;
			lineChart.Theme.CommonSeriesStrokes = lineChart.Theme.CommonSeriesFills =
				new List<Brush>
			{
				Brushes.Red,
				Brushes.Green
			};
		}
	}
}

