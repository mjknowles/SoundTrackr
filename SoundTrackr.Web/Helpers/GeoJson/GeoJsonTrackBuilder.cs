using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using SoundTrackr.Service.DTOs;
using SoundTrackr.Service.Messaging.Track;
using SoundTrackr.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundTrackr.Web.Helpers.GeoJson
{
    public static class GeoJsonTrackBuilder
    {
        public static GeoJsonDTO CreateTrack(GetTrackResponse resp)
        {

            int lastTrackStatIndex = resp.Track.TrackStats.Count - 1;

            var startProps = CreatePointFeatureProperties(resp.Track.TrackStats[0], "Start", "#9c89cc", "medium", "building");
            var startPoint = new Feature(new Point(new GeographicPosition(resp.Track.TrackStats[0].Location.Latitude, resp.Track.TrackStats[0].Location.Longitude)), startProps);

            var endProps = CreatePointFeatureProperties(resp.Track.TrackStats[lastTrackStatIndex], "End", "#9c89cc", "medium", "building");
            var endPoint = new Feature(new Point(new GeographicPosition(resp.Track.TrackStats[lastTrackStatIndex].Location.Latitude, resp.Track.TrackStats[lastTrackStatIndex].Location.Longitude)), endProps);

            var lineProps = CreateLineStringFeatureProperties("#fa946e", 1, 6);
            var lineCoords = new List<IPosition>();
            foreach (var ts in resp.Track.TrackStats)
            {
                lineCoords.Add(new GeographicPosition(ts.Location.Latitude, ts.Location.Longitude));
            }
            var line = new Feature(new LineString(new List<IPosition>(lineCoords)), lineProps);

            return new GeoJsonDTO
            {
                GeoJsonLayers = new List<GeoJsonDetails>()
                {
                    new GeoJsonDetails
                    {
                        GeoJsonObject = new FeatureCollection(new List<Feature> { startPoint, endPoint, line })
                    }
                }
            };

        }

        private static LineStringFeatureProperties CreateLineStringFeatureProperties(string stroke, int strokeOpacity, int strokeWidth)
        {
            return new LineStringFeatureProperties(stroke, strokeOpacity, strokeWidth);
        }

        private static PointFeatureProperties CreatePointFeatureProperties(TrackStatDTO ts, string title, string markerColor, string markerSize, string markerSymbol)
        {
            return new PointFeatureProperties(title, markerColor, markerSize, markerSymbol);
        }
    }
}