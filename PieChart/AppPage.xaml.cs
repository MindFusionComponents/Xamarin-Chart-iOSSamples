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

			pieChart.BackgroundColor = Colors.White;
			pieChart.ShowLegend = false;


			var values = new List<double> { 20, 30, 10, 40 };
			pieChart.Series = new PieSeries(
				values,
				new List<string>
				{
					"20", "30", "10", "40"
				},
				new List<string>
				{
					"twenty", "thirty", "ten", "forty"
				}
			);

			pieChart.Plot.SeriesStyle = new PerElementSeriesStyle
			{
				Fills = new List<List<MindFusion.Drawing.Brush>>
				{
					new List<Brush>
					{
						Brushes.Aqua,
						Brushes.SkyBlue,
						Brushes.Blue,
						Brushes.LightBlue
					}
				}
			};
		}
		void cbDonut_Toggled(object sender, ToggledEventArgs e)
		{
			pieChart.Doughnut = !pieChart.Doughnut;
			pieChart.Invalidate ();
		}

		void cbShowDataLabels_Toggled(object sender, ToggledEventArgs e)
		{
			if (cbShowDataLabels.IsToggled)
				pieChart.ShowDataLabels = LabelKinds.All;
			else
				pieChart.ShowDataLabels = LabelKinds.None;
			pieChart.Invalidate();
		}
	}
}

