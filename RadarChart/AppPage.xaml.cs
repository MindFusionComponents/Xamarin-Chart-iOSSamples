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
			radarChart.Series = new ObservableCollection<Series>
			{
				new SimpleSeries(
					new List<double>
					{
						20, 30, 43, 40, 44, 37, 35, 51
					},
					new List<string>
					{
						"20", "30", "43", "40", "44", "37", "35", "51"
					}
				),
				new SimpleSeries(
					new List<double>
					{
						12, 40, 23, 30, 34, 47, 45, 21
					},
					new List<string>
					{
						"12", "40", "23", "30", "34", "47", "45", "21"
					}
				)
			};

			// define axis appearance
			radarChart.Theme.AxisLabelsBrush = Brushes.Black;
			radarChart.Theme.AxisLabelsFontStyle = FontAttributes.Bold;
			radarChart.Theme.AxisLabelsFontSize = 10;
			radarChart.Theme.AxisStroke = Brushes.Gray;

			radarChart.GridDivisions = 5;
			radarChart.DefaultAxis.MinValue = 0;
			radarChart.DefaultAxis.MaxValue = 55;
			radarChart.ShowLegend = false;

			radarChart.BackgroundColor = Colors.LightGoldenrodYellow;

			for (int i = 0; i < 8; i++)
				radarChart.Axes.Add(new Axis
					{
						Title = string.Format("Axis {0}", i + 1)
					});

			// fill enumeration combo boxes
			var gridTypeValues = Enum.GetValues (typeof(RadarGridType));
			foreach (var v in gridTypeValues) {
				cbxGridType.Items.Add (v.ToString ());
			}
			cbxGridType.SelectedIndex = cbxGridType.Items.IndexOf(RadarGridType.Spiderweb.ToString());


			var radarTypeValues = Enum.GetValues (typeof(RadarType));
			foreach (var v in radarTypeValues) {
				cbxRadarType.Items.Add (v.ToString ());
			}
			cbxRadarType.SelectedIndex = cbxRadarType.Items.IndexOf(RadarType.Polygon.ToString());


			radarChart.GridType = RadarGridType.Spiderweb;
			radarChart.RadarType = RadarType.Polygon;

			// specify one color per series
			radarChart.Plot.SeriesStyle = new PerSeriesStyle
			{
				Strokes = new List<MindFusion.Drawing.Brush>
				{
					Brushes.Tomato,
					Brushes.Violet
				},
				Fills = new List<MindFusion.Drawing.Brush>
				{
					Brushes.Tomato,
					Brushes.Violet
				}
			};
		}
		void cbxRadarType_ItemSelected(object sender, EventArgs e)
		{
			radarChart.RadarType = (RadarType) Enum.GetValues(typeof(RadarType)).GetValue(cbxRadarType.SelectedIndex);
		}

		void cbxGridType_ItemSelected(object sender, EventArgs e)
		{
			radarChart.GridType = (RadarGridType)Enum.GetValues(typeof(RadarGridType)).GetValue(cbxGridType.SelectedIndex);
		}
	}
}

