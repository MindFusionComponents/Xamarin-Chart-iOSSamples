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
			var plot = (RadarPlot)radarChart.Plot;

			// create sample data, a list of .NET objects
			var data = CreateData();
			for (var i = 0; i < 5; i++)
				plot.Axes.Add(new Axis() { Title = data[i].Subject, MinValue = 0, MaxValue = 4 });

			// set the data source and specify property names to use as data
			radarChart.XDataFields = radarChart.YDataFields = new ObservableCollection<string>() { "GPA1", "GPA2", "GPA3" };
			radarChart.InnerLabelsDataFields = new ObservableCollection<string>() { "GPA1", "GPA2", "GPA3" };
			radarChart.ToolTipsDataFields = new ObservableCollection<string>() { "Subject", "Subject", "Subject" };
			radarChart.DataSource = data;
			radarChart.DataBind();

			// set the series titles
			((DataBoundSeries)radarChart.Series[0]).Title = "age range 7-10";
			((DataBoundSeries)radarChart.Series[1]).Title = "age range 11-13";
			((DataBoundSeries)radarChart.Series[2]).Title = "age range 14-17";

			// set up legend
			radarChart.LegendTitle = "GPA by subject and age";
			radarChart.Theme.LegendBackground = new MindFusion.Drawing.SolidBrush(Color.Transparent);
			radarChart.AllowMoveLegend = false;

			// customize appearance
			radarChart.ShowCoordinates = false;
			radarChart.Plot.Margin = new Margins(0, 0, 0, 30);
			radarChart.BackgroundColor = Colors.FloralWhite;
			radarChart.GridColor1 = Colors.PaleGoldenrod;
			radarChart.GridColor2 = Colors.PaleTurquoise;
			radarChart.Theme.HighlightStroke = Brushes.Gold;
			radarChart.Theme.AxisTitleFontStyle = FontAttributes.Bold;
			radarChart.Theme.LegendTitleFontStyle = FontAttributes.Bold;
			radarChart.Theme.AxisStroke = Brushes.LightGray;
			radarChart.Theme.CommonSeriesFills = radarChart.Theme.CommonSeriesStrokes = new List<MindFusion.Drawing.Brush>
			{
				Brushes.Tomato,
				Brushes.Turquoise,
				Brushes.Violet
			};
			radarChart.Theme.UniformSeriesStrokeThickness = 5;
		}

		List<StudentData> CreateData()
		{
			var data = new List<StudentData>();

			string[] subjects = { "Math", "Physics", "Chemistry", "Biology", "IT" };
			double[] gpa1 = { 2.3, 1.7, 2, 4, 3.7 };
			double[] gpa2 = { 3.3, 2.7, 1.7, 2, 3.3 };
			double[] gpa3 = { 4, 3.7, 2, 1, 1.3 };

			for (var i = 0; i < 5; i++)
			{
				data.Add(new StudentData()
					{
						Subject = subjects[i],
						GPA1 = gpa1[i],
						GPA2 = gpa2[i],
						GPA3 = gpa3[i]
					});
			}

			return data;
		}

		void cbRadarType_Toggled(object sender, ToggledEventArgs e)
		{
			radarChart.RadarType = radarChart.RadarType == RadarType.Pie ? RadarType.Polygon : RadarType.Pie;
			lbRadarType.Text = radarChart.RadarType == RadarType.Pie ? "RadarType=Pie" : "RadarType=Polygon";
		}

		void cbGridType_Toggled(object sender, ToggledEventArgs e)
		{
			radarChart.GridType = radarChart.GridType == RadarGridType.Radar ? RadarGridType.Spiderweb : RadarGridType.Radar;
			lbGridType.Text = radarChart.GridType == RadarGridType.Radar ? "GridType=Radar" : "GridType=Spiderweb";
		}

		void cbShowScatter_Toggled(object sender, ToggledEventArgs e)
		{
			radarChart.ShowScatter = cbShowScatter.IsToggled;
		}

		public class StudentData
		{
			public StudentData() { }

			public string Subject { get; set; }
			public double GPA1 { get; set; }
			public double GPA2 { get; set; }
			public double GPA3 { get; set; }
		}
	}
}

