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
            FeatureProperties = new Dictionary<string, object> {
                { "title", "" },
                { "marker-color", "" },
                { "marker-size", "" },
                { "marker-symbol", "" }
            };
        }

        public Dictionary<string, object> FeatureProperties { get; set; }
        public string Title { get { return FeatureProperties["title"].ToString(); } set { FeatureProperties["title"] = value; } }
        public string MarkerColor { get { return FeatureProperties["marker-color"].ToString(); } set { FeatureProperties["marker-color"] = value; } }
        public string MarkerSize { get { return FeatureProperties["marker-size"].ToString(); } set { FeatureProperties["marker-size"] = value; } }
        public string MarkerSymbol { get { return FeatureProperties["marker-symbol"].ToString(); } set { FeatureProperties["marker-symbol"] = value; } }
    }
}