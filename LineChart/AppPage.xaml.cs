using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MindFusion.Drawing;
using MindFusion.Charting;

namespace IOSSamples
{
	public partial class AppPage : ContentPage
	{
		public AppPage ()
		{
			InitializeComponent ();
			// create line brushes
			firstBrush = Brushes.SkyBlue;
			secondBrush = Brushes.DeepPink;
			thirdBrush = Brushes.Green;

			lineChart.LegendRenderer.Background = Brushes.Khaki;
			lineChart.BackgroundColor = Colors.WhiteSmoke;

			// create sample data series
			lineChart.Series.Add(
				new Series2D(
					new List<double> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
					new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
					labels
				)
				{ Title = "Series 1" });

			lineChart.Series.Add(
				new Series2D(
					new List<double> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
					new List<double> { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24 },
					labels
				)
				{ Title = "Series 2" });

			lineChart.Series.Add(
				new FunctionSeries(x => x * Math.Sin(x) + x + 5, 36, 12)
				{ Title = "Series 3" });

			lineChart.XAxis.Interval = 1;

			// assign one brush per series
			lineChart.Plot.SeriesStyle = new MixedSeriesStyle
			{
				CommonFills = new List<Brush>
				{
					firstBrush, secondBrush, thirdBrush
				},
				CommonStrokes = new List<Brush>
				{
					firstBrush, secondBrush, thirdBrush
				},
				UniformStrokeThickness = 5
			};

			// set up grid type combo box
			var gridTypeValues = Enum.GetValues (typeof(GridType));
			foreach (var v in gridTypeValues) {
				cbxGridType.Items.Add (v.ToString ());
			}
			cbxGridType.SelectedIndex = cbxGridType.Items.IndexOf(GridType.Crossed.ToString());
			lineChart.GridType = GridType.Crossed;
			//cbxGridType.SelectedIndexChanged += cbxGridType_ItemSelected;

			// set up line type combo box
			var lineTypeValues = Enum.GetValues (typeof(LineType));
			foreach (var v in lineTypeValues) {
				cbxLineType.Items.Add (v.ToString ());
			}
			cbxLineType.SelectedIndex = cbxLineType.Items.IndexOf(LineType.Polyline.ToString());
			lineChart.LineType = LineType.Polyline;
            //cbxLineType.SelectedIndexChanged += cbxLineType_ItemSelected;
            lineChart.XAxis.Title = "";
            lineChart.YAxis.Title = "";
		}

		void cbxLineType_ItemSelected(object sender, EventArgs e)
		{
			lineChart.LineType = (LineType) Enum.GetValues(typeof(LineType)).GetValue(cbxLineType.SelectedIndex);
		}

		void cbxGridType_ItemSelected(object sender, EventArgs e)
		{
			lineChart.GridType = (GridType) Enum.GetValues(typeof(GridType)).GetValue(cbxGridType.SelectedIndex);
		}


		List<string> labels = new List<string>
		{
			"one", "two", "three", "four", "five", "six",
			"seven", "eight", "nine", "ten", "eleven", "twelve"
		};

		Brush firstBrush;
		Brush secondBrush;
		Brush thirdBrush;
	}
}

