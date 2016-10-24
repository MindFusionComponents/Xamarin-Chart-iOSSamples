using System;
using System.Collections.Generic;

using Xamarin.Forms;
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
			// create sample data
			var data = new ObservableCollection<Series>();

			var years = new DateTime[10];
			var dt = new DateTime(DateTime.Now.Year + 1, 12, 31);
			for (var i = 0; i < 10; i++)
				years[i] = dt.AddYears(-(10 - i));

			var income = new double[10] { 13.2, 15.6, 17.8, 39, 20, 29, 79, 101, 120, 122 };

			var series = new MindFusion.Charting.DateTimeSeries(
				years, income, years[0], years[years.Length - 1]);
			series.MinValue = 0;
			series.MaxValue = 1;
			series.DateTimeFormat = DateTimeFormat.CustomDateTime;
			series.CustomDateTimeFormat = "yyyy";

			data.Add(series);

			// setup chart
			areaChart.BackgroundColor = Colors.PaleGoldenrod;
			areaChart.Series = data;
			areaChart.Title = "Acme Inc. financial report";
			areaChart.ShowXCoordinates = false;
			areaChart.ShowLegend = false;

			areaChart.XAxis.Title = "";
			areaChart.XAxis.MinValue = 0;
			areaChart.XAxis.MaxValue = 1;
			areaChart.XAxis.Interval = 0.1;

			areaChart.YAxis.Title = "Income ($ in millions)";

			areaChart.Theme.UniformSeriesFill = new LinearGradientBrush(Colors.Cornsilk, Colors.Crimson, 0);
		}
	}
}

