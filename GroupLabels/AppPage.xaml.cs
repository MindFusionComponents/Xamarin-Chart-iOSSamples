using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MindFusion.Charting;
using System.Collections.ObjectModel;
using MindFusion.Charting.Components;
using MindFusion.Drawing;

namespace IOSSamples
{
	public partial class AppPage : ContentPage
	{
		public AppPage ()
		{
			InitializeComponent ();
			// create sample data
			var series = new ObservableCollection<Series>();
			for (int i = 0; i < 4; i++)
			{
				if (i == 0)
				{
					series.Add(new BarSeries(
						new double[] { 20, 60, 40, 55 },
						new string[] { "Acer", "Biostar", "Foxconn", "Supermicro" },
						new string[] { "", "", "", "" }));
				}
				if (i == 1)
				{
					series.Add(new BarSeries(
						new double[] { 30, 70, 65, 19 },
						new string[] { "Biostar", "Intel", "Nvidia", "VIA Technologies" },
						new string[] { "", "", "", "" }));
				}
				if (i == 2)
				{
					series.Add(new BarSeries(
						new double[] { 22, 44, 33, 66 },
						new string[] { "Foxconn", "Nvidia", "Marvell", "NexGen" },
						new string[] { "", "", "", "" }));
				}
				if (i == 3)
				{
					series.Add(new BarSeries(
						new double[] { 12, 45, 77, 90 },
						new string[] { "Supermicro", "VIA Technologies", "NexGen", "Toshiba" },
						new string[] { "", "", "", "" }));
				}
			}

			// create labels data
			var annotations = new ObservableCollection<Series>();
			annotations.Add(new BarSeries(
				new double[] { 0, 0, 0, 0 },
				new string[] { "", "", "", "" },
				new string[] { "", "", "", "" },
				new string[] { "Motherboards", "Chipsets", "CPU", "HDD" }));


			barChart.ShowLegend = false;

			var mainGrid = barChart.ChartPanel;
			mainGrid.HorizontalAlignment = MindFusion.Charting.Components.LayoutAlignment.Stretch;
			mainGrid.VerticalAlignment = MindFusion.Charting.Components.LayoutAlignment.Stretch;

			// add plot
			var plot1 = new Plot2D();
			plot1.GridColumn = 1;
			plot1.GridRow = 0;
			plot1.VerticalScroll = false;
			plot1.XAxis = new Axis();
			plot1.YAxis = new Axis { MinValue = 0, MaxValue = 100 };
			mainGrid.Children.Add(plot1);

			// add renderer
			var barRenderer = new BarRenderer(series);
			barRenderer.LabelBrush = new SolidBrush(Color.FromRgb(70, 70, 70));
			barRenderer.LabelFontStyle = FontAttributes.Italic;
			plot1.SeriesRenderers.Add(barRenderer);

			// add labels renderer
			var annotationRenderer = new AnnotationRenderer(annotations);
			plot1.SeriesRenderers.Add(annotationRenderer);

			// create axes
			var yAxis = new YAxisRenderer(plot1.YAxis, plot1.XAxis);
			yAxis.PlotLeftSide = true;
			yAxis.GridColumn = 0;
			yAxis.LabelsSource = plot1;
			mainGrid.Children.Add(yAxis);

			var xAxis = new XAxisRenderer(plot1.XAxis);
			xAxis.GridRow = 1;
			xAxis.GridColumn = 1;
			xAxis.LabelsSource = plot1;
			xAxis.ShowCoordinates = false;
			xAxis.LabelFontStyle = FontAttributes.Bold;
			mainGrid.Children.Add(xAxis);

			// styles
			plot1.GridType = GridType.Crossed;
			plot1.XAxis.Title = "";
			plot1.YAxis.Title = "";
			plot1.GridColor1 = Colors.Black;
			plot1.GridColor1 = Colors.White;
			barChart.BackgroundColor = Color.FromRgb(70, 70, 70);
			barChart.Theme.CommonSeriesFills = GetFills();
			barChart.Theme.AxisStroke = barChart.Theme.AxisLabelsBrush = new SolidBrush(Color.White);
			barChart.Theme.UniformSeriesStroke = new SolidBrush(Color.White);
			barChart.Theme.HighlightStroke = new SolidBrush(Color.FromRgb(70, 70, 70));
			barChart.Theme.HighlightStrokeThickness = 1;
			barChart.Theme.PlotBackground = new LinearGradientBrush(Colors.Black, Colors.White, 0);
			barChart.Theme.DataLabelsFontSize = 7;
            barChart.XAxis.Title = "";
            barChart.YAxis.Title = "";
		}

		List<Brush> GetFills()
		{
			var fills = new List<Brush>();

			fills.Add(new LinearGradientBrush(Colors.LightGray, Colors.White, 0));
			fills.Add(new LinearGradientBrush(Colors.White, Colors.PaleGreen, 0));
			fills.Add(new LinearGradientBrush(Colors.White, Colors.Orange, 0));
			fills.Add(new LinearGradientBrush(Colors.White, Colors.PowderBlue, 0));

			return fills;
		}
	}
}

