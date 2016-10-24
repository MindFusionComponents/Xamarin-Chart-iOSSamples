using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MindFusion.Charting;
using MindFusion.Drawing;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace IOSSamples
{
	public partial class AppPage : ContentPage
	{
		public AppPage ()
		{
			InitializeComponent ();
			lineChart.BackgroundColor = Colors.White;
			lineChart.LineType = LineType.Curve;

			var xml = GetEmbeddedResourceString(Assembly.GetAssembly(typeof(App)), "Data.xml");

			// load sample xml file
			var doc = XDocument.Parse(xml);

			var xdata = doc.Element("weather-observations").Element("product").Element("group").Elements("obs").Elements("d")
				.Where(e => e.Attribute("t").Value == "tx");

			// create XML series bound to XPath expressions and add them to the chart;
			// alternatively, you could assign the XmlDocument to Chart.DataSource
			// and assign the XPath expressions to its various DataField* properties
			var series = new XmlSeries(xdata, null, null, null, null, null, null, null, null);
			series.Title = "maximum temperature";
			lineChart.Series.Add(series);

			xdata = doc.Element("weather-observations").Element("product").Element("group").Elements("obs").Elements("d")
				.Where(e => e.Attribute("t").Value == "tn");

			series = new XmlSeries(xdata, null, null, null, null, null, null, null, null);
			series.Title = "minimum temperature";
			lineChart.Series.Add(series);

			// customize appearance
			lineChart.XAxis.Title = "Time";
			lineChart.YAxis.Title = "Degrees Celsius";

			lineChart.LegendHorizontalAlignment = MindFusion.Charting.Components.LayoutAlignment.Far;
			lineChart.LegendVerticalAlignment = MindFusion.Charting.Components.LayoutAlignment.Far;

			lineChart.Theme = new Theme();
			lineChart.Theme.CommonSeriesFills = lineChart.Theme.CommonSeriesStrokes = new List<Brush>
			{
				Brushes.Red,
				Brushes.Blue
			};
			lineChart.Theme.LegendBackground = Brushes.White;
			lineChart.Theme.LegendBorderStroke = Brushes.Black;
		}

		static Stream GetEmbeddedResourceStream(Assembly assembly, string resourceFileName)
		{
			var resourceNames = assembly.GetManifestResourceNames();

			var resourcePaths = resourceNames
				.Where(x => x.EndsWith(resourceFileName, StringComparison.CurrentCultureIgnoreCase))
				.ToArray();

			if (!resourcePaths.Any())
			{
				throw new Exception(string.Format("Resource ending with {0} not found.", resourceFileName));
			}

			if (resourcePaths.Count() > 1)
			{
				throw new Exception(string.Format("Multiple resources ending with {0} found: {1}{2}", resourceFileName, Environment.NewLine, string.Join(Environment.NewLine, resourcePaths)));
			}

			return assembly.GetManifestResourceStream(resourcePaths.Single());
		}

		static string GetEmbeddedResourceString(Assembly assembly, string resourceFileName)
		{
			var stream = GetEmbeddedResourceStream(assembly, resourceFileName);

			using (var streamReader = new StreamReader(stream))
			{
				return streamReader.ReadToEnd();
			}
		}
	}
}

