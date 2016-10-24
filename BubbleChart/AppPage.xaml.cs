using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using MindFusion.Charting;
using MindFusion.Drawing;

namespace IOSSamples
{
	public partial class AppPage : ContentPage
	{
		public AppPage ()
		{
			InitializeComponent ();

			// create sample data
			bubbleChart.Series = GetSeriesCollection();

			// axis titles and ranges
			bubbleChart.XAxis.Title = "Average relative annual growth (%)";
			bubbleChart.XAxis.MinValue = -1;
			bubbleChart.XAxis.MaxValue = 1;
			bubbleChart.YAxis.Title = "July 1, 2015 projection";
			bubbleChart.YAxis.MinValue = 0;
			bubbleChart.YAxis.MaxValue = 100;

			// background appearance
			bubbleChart.ShowZoomWidgets = true;
			bubbleChart.GridType = GridType.Vertical;
			bubbleChart.BackgroundColor = Color.Black;
			bubbleChart.Theme.GridColor1 = Color.FromRgb(0, 0, 0);
			bubbleChart.Theme.GridColor2 = Color.FromRgb(0, 0, 0);
			bubbleChart.Theme.LegendBackground = new SolidBrush(Color.Black);

			// series colors
			bubbleChart.Theme.CommonSeriesFills = new List<Brush>
			{
				//Brushes.Orange,
				//Brushes.Blue
				new LinearGradientBrush(Color.Black, Colors.Orange, 90),
				new LinearGradientBrush(Color.Black, Colors.SkyBlue, 90)
			};
			bubbleChart.Theme.UniformSeriesStroke = bubbleChart.Theme.HighlightStroke =
				bubbleChart.Theme.DataLabelsBrush = bubbleChart.Theme.LegendTitleBrush =
					bubbleChart.Theme.LegendBorderStroke = bubbleChart.Theme.AxisLabelsBrush =
						bubbleChart.Theme.AxisTitleBrush = bubbleChart.Theme.AxisStroke = Brushes.White;

			bubbleChart.Theme.HighlightStrokeDashStyle = DashStyle.Dot;

			SetupControls();
		}
		void SetupControls()
		{
			cbShowScatter.IsToggled = bubbleChart.ShowScatter;
			cbShowLabels.IsToggled = true;
			cbLegend.IsToggled = true;
		}

		ObservableCollection<Series> GetSeriesCollection()
		{
			// bubble chart requires three dimensional data;
			// two dimensions for position and one for size
			var series3D1 = new PointSeries3D(
				new List<Point3D>
				{
					new Point3D(0.32, 81, 95),
					new Point3D(0.39, 66, 78),
					new Point3D(0.75, 65, 76),
					new Point3D(0.49, 60, 71)
				},
				new List<string> { "Germany", "France", "UK", "Italy" });
			series3D1.Title = ">50 000 000";

			var series3D2 = new PointSeries3D(
				new List<Point3D>
				{
					new Point3D(-0.28, 46, 54),
					new Point3D(-0.32, 42, 50),
					new Point3D(0.05, 38, 45),
					new Point3D(-0.4, 19, 23)
				},
				new List<string> { "Spain", "Ukraine", "Poland", "Romania" });
			series3D2.Title = "<50 000 000";

			var data = new ObservableCollection<Series>();
			data.Add(series3D1);
			data.Add(series3D2);

			return data;
		}

		void cbShowScatter_Toggled(object sender, ToggledEventArgs e)
		{
			bubbleChart.ShowScatter = cbShowScatter.IsToggled;
		}

		void cbShowLabels_Toggled(object sender, ToggledEventArgs e)
		{
			if (cbShowLabels.IsToggled)
				bubbleChart.ShowDataLabels |= LabelKinds.InnerLabel;
			else
				bubbleChart.ShowDataLabels ^= LabelKinds.InnerLabel;
			bubbleChart.Invalidate();
		}

		void cbLegend_Toggled(object sender, ToggledEventArgs e)
		{
			bubbleChart.ShowLegend = cbLegend.IsToggled;
		}
	}
}

