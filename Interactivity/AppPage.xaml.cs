using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MindFusion.Drawing;
using MindFusion.Charting;
using System.Collections.ObjectModel;

namespace IOSSamples
{
	public partial class AppPage : ContentPage
	{
		public AppPage ()
		{
			InitializeComponent ();
			// BarChart
			barChart.Series = GetSeriesCollection();
			barChart.Title = "Bar Chart";
			barChart.BackgroundColor = Colors.WhiteSmoke;

			barChart.AllowZoom = true;
			barChart.AllowPan = true;
			barChart.AllowMoveLegend = true;

			barChart.XAxis.Title = "";
			barChart.XAxis.MinValue = 0;
			barChart.XAxis.MaxValue = 3;
			barChart.YAxis.Title = "";
			barChart.YAxis.MinValue = 0;
			barChart.YAxis.MaxValue = 100;

			barChart.ShowLegend = true;
			barChart.LegendHorizontalAlignment = MindFusion.Charting.Components.LayoutAlignment.Near;
			barChart.LegendVerticalAlignment = MindFusion.Charting.Components.LayoutAlignment.Near;

			barChart.Theme = new Theme();
			barChart.Theme.CommonSeriesFills = GetBarFills();
			barChart.Theme.CommonSeriesStrokes = GetBarFills();
			barChart.Theme.LegendBackground = Brushes.WhiteSmoke;
			barChart.Theme.LegendBorderStroke = new SolidBrush(Color.Teal);
			barChart.Theme.HighlightStroke = Brushes.CadetBlue;

			// PieChart
			pieChart.Series = new PieSeries(
				new double[] { 20, 60, 40, 55 },
				new string[] { "January", "February", "March", "April" },
				new string[] { "January", "February", "March", "April" })
			{ Title = "Pie Series" };
			pieChart.Title = "Pie Chart";
			pieChart.BackgroundColor = Colors.WhiteSmoke;

			pieChart.AllowZoom = true;
			pieChart.AllowRotate = true;

			pieChart.ShowLegend = false;
			pieChart.ShowDataLabels = LabelKinds.OuterLabel;

			pieChart.Theme = new Theme();
			pieChart.Theme.SeriesFills = GetPieFills();
			pieChart.Theme.UniformSeriesStroke = new SolidBrush(Color.FromRgb(240, 240, 240));
			pieChart.Theme.SeriesStrokeThicknesses = new List<List<double>>() { new List<double>() { 15 } };
			pieChart.Theme.HighlightStroke = new SolidBrush(Color.White);
			pieChart.Theme.HighlightStrokeThickness = 10;
		}

		ObservableCollection<Series> GetSeriesCollection()
		{
			ObservableCollection<Series> collection = new ObservableCollection<Series>();
			for (int i = 0; i < 3; i++)
			{
				if (i == 0)
				{
					collection.Add(new Series2D(new double[] { 0, 1, 2, 3 },
						new double[] { 20, 60, 40, 55 },
						new string[] { "January", "February", "March", "April" })
						{ Title = "Series 1" });
				}
				if (i == 1)
				{
					collection.Add(new Series2D(new double[] { 0, 1, 2, 3 },
						new double[] { 30, 70, 65, 19 },
						new string[] { "May", "June", "July", "August" })
						{ Title = "Series 2" });
				}
				if (i == 2)
				{
					collection.Add(new Series2D(new double[] { 0, 1, 2, 3 },
						new double[] { 22, 44, 33, 66 },
						new string[] { "September", "October", "November", "December" })
						{ Title = "Series 3" });
				}
			}
			return collection;
		}

		List<Brush> GetBarFills()
		{
			var fills = new List<Brush>();

			fills.Add(Brushes.SkyBlue);
			fills.Add(Brushes.Teal);
			fills.Add(Brushes.PowderBlue);

			return fills;
		}

		List<List<Brush>> GetPieFills()
		{
			var fills = new List<List<Brush>>();

			fills.Add(new List<Brush>() {
				Brushes.RosyBrown,
				Brushes.Coral,
				Brushes.Crimson,
				Brushes.DarkRed,
			});

			return fills;
		}

		void button1_Click(object sender, EventArgs e)
		{
			barChart.ResetZoom();
		}
	}
}

