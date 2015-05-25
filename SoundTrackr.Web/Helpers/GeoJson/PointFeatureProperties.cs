using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.Helpers.GeoJson
{
    public class PointFeatureProperties
    {
        public PointFeatureProperties()
        {
            IntializePointFeatureProperties();
        }

        public PointFeatureProperties(string title, string markerColor, string markerSize, string markerSymbol)
        {
            IntializePointFeatureProperties();
            Title = title;
            MarkerColor = markerColor;
            MarkerSize = markerSize;
            MarkerSymbol = markerSymbol;
        }

        public void IntializePointFeatureProperties()
        {
            FeatureProperties = new Dictionary<string, string> {
                { "title", "" },
                { "marker-color", "" },
                { "marker-size", "" },
                { "marker-symbol", "" }
            };
        }

        public Dictionary<string, string> FeatureProperties { get; set; }
        public string Title { get { return FeatureProperties["title"]; } set { FeatureProperties["title"] = value; } }
        public string MarkerColor { get { return FeatureProperties["marker-color"]; } set { FeatureProperties["marker-color"] = value; } }
        public string MarkerSize { get { return FeatureProperties["marker-size"]; } set { FeatureProperties["marker-size"] = value; } }
        public string MarkerSymbol { get { return FeatureProperties["marker-symbol"]; } set { FeatureProperties["marker-symbol"] = value; } }
    }
}