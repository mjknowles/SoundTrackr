using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.Helpers.GeoJson
{
    public class LineStringFeatureProperties
    {
        public LineStringFeatureProperties()
        {
            IntializeLineStringFeatureProperties();
        }

        public LineStringFeatureProperties(string stroke, int strokeOpacity, int strokeWidth, string song, string artist)
        {
            IntializeLineStringFeatureProperties();
            Stroke = stroke;
            StrokeOpacity = strokeOpacity;
            StrokeWidth = strokeWidth;
            Song = song;
            Artist = artist;
        }

        public void IntializeLineStringFeatureProperties()
        {
            FeatureProperties = new Dictionary<string, object> {
                { "stroke", "" },
                { "stroke-opacity", "" },
                { "stroke-width", "" },
                { "song", "" },
                {"artist", "" }
            };
        }

        public Dictionary<string, object> FeatureProperties { get; set; }
        public string Stroke { get { return FeatureProperties["stroke"].ToString(); } set { FeatureProperties["stroke"] = value; } }
        public int StrokeOpacity { get { return (int)FeatureProperties["stroke-opacity"]; } set { FeatureProperties["stroke-opacity"] = value; } }
        public int StrokeWidth { get { return (int)FeatureProperties["stroke-width"]; } set { FeatureProperties["stroke-width"] = value; } }
        public string Song { get { return FeatureProperties["song"].ToString(); } set { FeatureProperties["song"] = value; } }
        public string Artist { get { return FeatureProperties["artist"].ToString(); } set { FeatureProperties["artist"] = value; } }
    }
}