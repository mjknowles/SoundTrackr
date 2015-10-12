using GeoJSON.Net;
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
            // return item will be a collection of geojson details representing start points,
            // end points, and all subtracks
            GeoJsonDTO dto = new GeoJsonDTO();

            if (resp.Track.SubTracks.Count != 0)
            {
                int lastSubTrackIndex = resp.Track.SubTracks.Count - 1;
                int lastTrackStatIndex = resp.Track.SubTracks[lastSubTrackIndex].TrackStats.Count - 1;

                var startProps = CreatePointFeatureProperties(resp.Track.SubTracks[0].TrackStats[0], "Start", "#9c89cc", "medium", "building");
                var startPoint = new Feature(new Point(new GeographicPosition(resp.Track.SubTracks[0].TrackStats[0].Location.Latitude, resp.Track.SubTracks[0].TrackStats[0].Location.Longitude)), startProps.FeatureProperties);
                dto.GeoJsonFeatures.Features.Add(startPoint);

                var endProps = CreatePointFeatureProperties(resp.Track.SubTracks[lastSubTrackIndex].TrackStats[lastTrackStatIndex], "End", "#9c89cc", "medium", "building");
                var endPoint = new Feature(new Point(new GeographicPosition(resp.Track.SubTracks[lastSubTrackIndex].TrackStats[lastTrackStatIndex].Location.Latitude, resp.Track.SubTracks[lastSubTrackIndex].TrackStats[lastTrackStatIndex].Location.Longitude)), endProps.FeatureProperties);
                dto.GeoJsonFeatures.Features.Add(endPoint);

                // Create subtracks
                LineStringFeatureProperties lineProps;
                List<IPosition> lineCoords;
                Feature line;

                for (int i = 0; i < resp.Track.SubTracks.Count; i++)
                {
                    var st = resp.Track.SubTracks[i];

                    lineProps = CreateLineStringFeatureProperties("#fa946e", 1, 6, st.Artist, st.Song);
                    lineCoords = new List<IPosition>();

                    foreach (var ts in st.TrackStats)
                    {
                        lineCoords.Add(new GeographicPosition(ts.Location.Latitude, ts.Location.Longitude));
                    }
                    line = new Feature(new LineString(new List<IPosition>(lineCoords)), lineProps.FeatureProperties);
                    dto.GeoJsonFeatures.Features.Add(line);

                    // If subtrack is first in list, then it doesn't need a start point since that's the beginning of the track
                    if (i != 0)
                    {
                        var subTrackStartProps = CreatePointFeatureProperties(resp.Track.SubTracks[0].TrackStats[0], "Start", "#9c89cc", "medium", "circle");
                        var subTrackStart = new Feature(new Point(new GeographicPosition(st.TrackStats[0].Location.Latitude, st.TrackStats[0].Location.Longitude)), subTrackStartProps.FeatureProperties);
                        dto.GeoJsonFeatures.Features.Add(line);
                    }
                }
            }

            return dto;
        }

        private static LineStringFeatureProperties CreateLineStringFeatureProperties(string stroke, int strokeOpacity, int strokeWidth, string song, string artist)
        {
            return new LineStringFeatureProperties(stroke, strokeOpacity, strokeWidth, song, artist);
        }

        private static PointFeatureProperties CreatePointFeatureProperties(TrackStatDTO ts, string title, string markerColor, string markerSize, string markerSymbol)
        {
            return new PointFeatureProperties(title, markerColor, markerSize, markerSymbol);
        }
    }
}