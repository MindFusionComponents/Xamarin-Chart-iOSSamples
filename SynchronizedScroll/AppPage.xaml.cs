using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MindFusion.Charting.Components;
using MindFusion.Charting;
using System.Collections.ObjectModel;
using MindFusion.Drawing;

namespace IOSSamples
{
	public partial class AppPage : ContentPage
	{
		public AppPage ()
		{
			InitializeComponent ();
			// set up grid panel
			var grid = new GridPanel();
			grid.Columns.Add(new GridColumn());
			for (int i = 0; i < 3; i++)
				grid.Rows.Add(new GridRow());

			// create two plots to it
			var plot1 = new Plot2D();
			var plot2 = new Plot2D();

			plot1.GridColumn = 1;
			plot1.GridRow = 0;

			plot2.GridColumn = 1;
			plot2.GridRow = 3;

			// assigning a shared Axis to plots makes them show same data
			// range and scroll together when the user pans any plot
			var commonAxis = new Axis();
			commonAxis.MinValue = 0;
			commonAxis.Interval = 0.5;
			commonAxis.Title = "";

			plot1.XAxis = commonAxis;
			plot2.XAxis = commonAxis;

			// use second axis renderer for shared axis just to show ticks from other side
			var commonAxisRenderer1 = new XAxisRenderer(commonAxis);
			commonAxisRenderer1.GridColumn = 1;
			commonAxisRenderer1.GridRow = 1;

			var commonAxisRenderer2 = new XAxisRenderer(commonAxis);
			commonAxisRenderer2.GridColumn = 1;
			commonAxisRenderer2.GridRow = 2;
			commonAxisRenderer2.PlotBottomSide = false;
			commonAxisRenderer2.ShowCoordinates = false;

			// create Y axes
			var p1YAxis = new Axis();
			var p2YAxis = new Axis();

			p1YAxis.MinValue = 0;
			p1YAxis.Interval = 5;
			p1YAxis.Title = "BarChart";
			plot1.YAxis = p1YAxis;

			p2YAxis.MinValue = 0;
			p2YAxis.Interval = 10;
			p2YAxis.Title = "LineChart";
			plot2.YAxis = p2YAxis;

			var p1Renderer = new YAxisRenderer(p1YAxis);
			p1Renderer.GridColumn = 0;
			p1Renderer.GridRow = 0;
			p1Renderer.ShowTicks = true;

			var p2Renderer = new YAxisRenderer(p2YAxis);
			p2Renderer.GridColumn = 0;
			p2Renderer.GridRow = 3;

			// show sample bar and line graphics in different plots
			var barRenderer = new BarRenderer(
				new ObservableCollection<Series> {
					new Series2D(
						new List<double> { 1, 2, 3, 4, 5, 6, 7 },
						new List<double> { 20.3, 12, 73.23, 21.2, 72, 66, 42.239 },
						null),
					new Series2D(
						new List<double> { 1, 2, 3, 4, 5, 6, 7 },
						new List<double> { 22.3, 15, 43.23, 11.2, 32, 12, 62.239 },
						null
					)
				}
			);

			var lineRenderer = new LineRenderer(
				new ObservableCollection<Series> {
					new Series2D(
						new List<double> { 1, 2, 3, 4, 5, 6, 7 },
						new List<double> { 10.3, 22, 33.23, 41.2, 12, 26, 42.239 },
						null),
					new Series2D(
						new List<double> { 1, 2, 3, 4, 5, 6, 7 },
						new List<double> { 42.3, 45, 43.23, 21.2, 12, 22, 22.239 },
						null
					)
				}
			);

			plot1.SeriesStyle = new PerSeriesStyle
			{
				Fills = new List<Brush>
				{
					new LinearGradientBrush(Color.Purple, Color.Yellow, 0),
					Brushes.LightBlue
				}
			};

			plot2.SeriesStyle = new PerSeriesStyle
			{
				Strokes = new List<Brush>
				{
					Brushes.Purple,
					Brushes.LightBlue
				}
			};

			plot1.SeriesRenderers.Add(barRenderer);
			plot2.SeriesRenderers.Add(lineRenderer);

			// add the plots and axes to the dashboard
			grid.Children.Add(plot1);
			grid.Children.Add(plot2);
			grid.Children.Add(commonAxisRenderer1);
			grid.Children.Add(commonAxisRenderer2);
			grid.Children.Add(p1Renderer);
			grid.Children.Add(p2Renderer);
			dashboard.LayoutPanel.Children.Add(grid);
		}
	}
}

