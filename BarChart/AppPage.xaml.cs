using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MindFusion.Charting;
using MindFusion.Drawing;
using System.Collections.ObjectModel;

namespace IOSSamples
{
	public partial class AppPage : ContentPage
	{
		LinearGradientBrush firstBrush;
		LinearGradientBrush secondBrush;
		SolidBrush thirdBrush;
		int angle = 1;

		List<string> labels = new List<string>()
		{
			"one", "two", "three", "four", "five", "six",
			"seven", "eight", "nine", "ten", "eleven", "twelve"
		};

		public AppPage ()
		{
			InitializeComponent ();
			var values = Enum.GetValues (typeof(BarLayout));
			foreach (var v in values) {
				cbxBarLayout.Items.Add (v.ToString ());
			}
			cbxBarLayout.SelectedIndex = cbxBarLayout.Items.IndexOf(barChart.BarLayout.ToString());

			// create bar brushes
			firstBrush = new LinearGradientBrush(Colors.LightGreen, Colors.LightBlue, 0);
			secondBrush = new LinearGradientBrush(Colors.Yellow, Colors.Red, 0);
			thirdBrush = new SolidBrush(Colors.Khaki);

			barChart.BackgroundColor = Colors.White;

			// create sample data series
			barChart.Series = new ObservableCollection<Series>
			{
				new BarSeries(
					new List<double> { 1,2,3,4,5,6,7,8,9,10,11,12 },
					labels, null
				)
				{ Title = "Series 1" },

				new BarSeries(
					new List<double> { 2,4,6,8,10,12,14,16,18,20,22,24 },
					labels, null
				)
				{ Title = "Series 2" },

				new BarSeries(
					new List<double> { 2,8,13,15,13,8,2,8,13,15,13,8 },
					labels, null
				)
				{ Title = "Series 3" }
			};
			barChart.XAxis.Interval = 1;

            barChart.XAxis.Title = "";
            barChart.YAxis.Title = "";

			// assign one brush per series
			barChart.Plot.SeriesStyle = new PerSeriesStyle()
			{
				Fills = new List<MindFusion.Drawing.Brush>()
				{
					firstBrush, secondBrush, thirdBrush
				}
			};
		}
		void cbxBarLayout_ItemSelected(object sender, EventArgs args)
		{
			barChart.BarLayout = (BarLayout) Enum.GetValues(typeof(BarLayout)).GetValue(cbxBarLayout.SelectedIndex);
		}
		void chbHorizontalBars_Toggled(object sender, ToggledEventArgs e)
		{
			barChart.HorizontalBars = !barChart.HorizontalBars;
			firstBrush.Angle += (angle * 90);
			secondBrush.Angle += (angle * 90);
			angle *= -1;
			barChart.Invalidate();
		}
	}
}

