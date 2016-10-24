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
		public AppPage ()
		{
			InitializeComponent ();
			// create sample data
			candlestickChart.Series = GetSeriesCollection ();

			candlestickChart.Title = "Deutsche Bank AG, Germany";
			candlestickChart.ShowZoomWidgets = true;
			candlestickChart.ShowLegend = false;
			candlestickChart.ShowXCoordinates = false;
			candlestickChart.ShowXTicks = false;

			// background appearance
			candlestickChart.GridType = GridType.Vertical;
			candlestickChart.BackgroundColor = Colors.DarkGray;
			candlestickChart.Theme.GridColor1 = Colors.DarkGray;
			candlestickChart.Theme.GridColor2 = Colors.Gray;

			// series style
			candlestickChart.CandlestickWidth = 3;
			candlestickChart.Plot.SeriesStyle = new CandlestickSeriesStyle (
				new MindFusion.Drawing.SolidBrush (Colors.LawnGreen),
				new MindFusion.Drawing.SolidBrush (Colors.Red),
				new MindFusion.Drawing.SolidBrush (Colors.Black),
				1, DashStyle.Solid, (CandlestickRenderer)candlestickChart.Plot.SeriesRenderers [0]);

			candlestickChart.Theme.UniformSeriesStroke = candlestickChart.Theme.HighlightStroke =
				candlestickChart.Theme.DataLabelsBrush = candlestickChart.Theme.AxisLabelsBrush =
					candlestickChart.Theme.AxisTitleBrush = candlestickChart.Theme.AxisStroke = new SolidBrush(Color.White);

			SetupControls();
		}
		static string[] DateFormats = {
			"dd",
			"d, ddd",
			"d, MMM",
			"d/MM/yy",
			"MM/d/yy"};

		void SetupControls()
		{
			cbDateFormat.HeightRequest = 24;//RowHeight = 24;
			foreach(var item in DateFormats)
			{
				cbDateFormat.Items.Add(item);
			}
			cbDateFormat.SelectedIndex = 0;
			//cbDateFormat.ItemsSource = DateFormats;
			//cbDateFormat.SelectedItem = DateFormats[0];

			cbWidgets.IsToggled = candlestickChart.ShowZoomWidgets;
		}

		ObservableCollection<Series> GetSeriesCollection()
		{
			// [ open, high, low, close ]
			var data = new double[][] {
				new [] { 15.99, 16.07, 15.80, 15.94 },
				new [] { 15.93, 16.03, 15.89, 15.97 },
				new [] { 15.97, 16.43, 15.94, 16.40 },
				new [] { 16.36, 16.52, 16.34, 16.46 },
				new [] { 16.44, 16.47, 16.23, 16.38 },
				new [] { 16.38, 17.08, 16.37, 17.02 },
				new [] { 17.01, 17.32, 16.93, 17.27 },
				new [] { 17.24, 17.36, 17.14, 17.32 },
				new [] { 17.28, 17.44, 17.08, 17.41 },
				new [] { 17.40, 17.47, 17.21, 17.38 },
				new [] { 17.34, 17.59, 17.32, 17.50 },
				new [] { 17.51, 17.85, 17.14, 17.15 },
				new [] { 17.16, 17.48, 17.16, 17.45 },
				new [] { 17.41, 17.62, 17.27, 17.47 },
				new [] { 17.46, 17.56, 17.16, 17.27 },
				new [] { 17.22, 17.32, 17.10, 17.24 },
				new [] { 17.15, 17.47, 17.14, 17.28 },
				new [] { 17.03, 18.30, 17.02, 17.74 },
				new [] { 17.72, 17.90, 17.61, 17.72 },
				new [] { 17.71, 17.83, 17.51, 17.75 },
				new [] { 17.74, 18.46, 17.74, 18.26 },
				new [] { 18.21, 18.80, 18.17, 18.69 },
				new [] { 18.70, 19.88, 18.65, 19.68 },
				new [] { 19.72, 21.12, 19.66, 20.40 },
				new [] { 20.29, 20.44, 19.52, 19.92 },
				new [] { 19.87, 20.49, 19.84, 20.07 },
				new [] { 20.06, 20.25, 19.45, 19.66 },
				new [] { 19.65, 20.20, 19.17, 20.19 },
				new [] { 20.30, 20.66, 20.09, 20.27 },
				new [] { 20.26, 20.51, 19.95, 20.13 },
				new [] { 20.10, 20.46, 19.88, 20.32 },
				new [] { 20.31, 20.54, 19.99, 20.28 },
				new [] { 20.28, 20.32, 19.98, 20.07 },
				new [] { 20.11, 20.22, 19.69, 20.01 },
				new [] { 19.98, 20.05, 19.79, 19.89 },
				new [] { 19.87, 19.97, 19.31, 19.39 },
				new [] { 19.36, 19.86, 19.20, 19.76 },
				new [] { 19.76, 19.93, 19.55, 19.63 },
				new [] { 19.63, 19.70, 19.29, 19.55 },
				new [] { 19.48, 19.73, 19.42, 19.61 },
				new [] { 19.57, 20.39, 19.51, 20.33 },
				new [] { 20.32, 20.50, 20.09, 20.13 },
				new [] { 20.13, 20.39, 19.95, 20.33 },
				new [] { 20.30, 20.63, 20.28, 20.43 },
				new [] { 20.44, 20.77, 20.32, 20.58 },
				new [] { 20.59, 20.71, 20.36, 20.38 },
				new [] { 20.37, 20.50, 20.04, 20.34 },
				new [] { 20.33, 20.42, 19.68, 19.69 },
				new [] { 19.49, 19.85, 19.48, 19.72 },
				new [] { 19.70, 19.86, 19.57, 19.83 },
				new [] { 19.83, 20.48, 19.83, 20.11 },
				new [] { 20.08, 20.31, 19.87, 19.95 },
				new [] { 19.95, 20.21, 19.64, 19.69 },
				new [] { 19.74, 20.03, 19.69, 19.79 },
				new [] { 19.80, 20.10, 19.70, 19.78 },
				new [] { 19.72, 19.88, 19.35, 19.66 },
				new [] { 19.63, 19.92, 19.60, 19.71 },
				new [] { 19.72, 19.77, 19.22, 19.42 }
			};

			var dataList = new List<StockPrice>();
			for (var i = 0; i < data.GetLength(0); i++)
			{
				var d = data[i];
				var open = d[0];
				var close = d[3];
				var low = d[2];
				var high = d[1];
				var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
				var dataItem = new StockPrice(open, close, low, high, date.AddDays(i));
				dataList.Add(dataItem);
			}

			var series = new MyStockSeries(dataList);
			series.DateTimeFormat = DateTimeFormat.CustomDateTime;
			series.CustomDateTimeFormat = "dd";

			var result = new ObservableCollection<Series>();
			result.Add(series);
			return result;
		}

		void cbWidgets_Toggled(object sender, ToggledEventArgs e)
		{
			candlestickChart.ShowZoomWidgets = cbWidgets.IsToggled;
		}

		void cbDateFormat_ItemSelected(object sender, EventArgs e)
		{
			((MyStockSeries)candlestickChart.Series [0]).CustomDateTimeFormat = DateFormats [cbDateFormat.SelectedIndex];//SelectedItem.ToString();
		}

		class MyStockSeries : Series
		{
			public MyStockSeries(IList<StockPrice> values)
			{
				series = new StockPriceSeries(values);
			}

			public int Dimensions
			{
				get { return series.Dimensions; }
			}

			public int Size
			{
				get { return series.Size; }
			}

			public LabelKinds SupportedLabels
			{
				get { return series.SupportedLabels; }
			}

			public string Title
			{
				get { return series.Title; }
			}

			public string GetLabel(int index, LabelKinds kind)
			{
				// Skip some labels to avoid overlapping
				if (index % 7 == 0)
					return series.GetLabel(index, kind);

				return string.Empty;
			}

			public double GetValue(int index, int dimension)
			{
				return series.GetValue(index, dimension);
			}

			public bool IsEmphasized(int index)
			{
				return series.IsEmphasized(index);
			}

			public bool IsSorted(int dimension)
			{
				return series.IsSorted(dimension);
			}


			public event EventHandler DataChanged
			{
				add { series.DataChanged += value; }
				remove { series.DataChanged -= value; }
			}

			public DateTimeFormat DateTimeFormat
			{
				get { return series.DateTimeFormat; }
				set { series.DateTimeFormat = value; }
			}

			public string CustomDateTimeFormat
			{
				get { return series.CustomDateTimeFormat; }
				set { series.CustomDateTimeFormat = value; }
			}


			StockPriceSeries series;
		}
	}
}

