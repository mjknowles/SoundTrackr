using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.DTOs.DTOConversions
{
    public static class ConversionHelper
    {
        public static TrackDTO ConvertToDTO(this SoundTrackr.Domain.Entities.Track.Track t)
        {
            List<SubTrackDTO> subTracks = new List<SubTrackDTO>();
            foreach(SoundTrackr.Domain.Entities.SubTrack.SubTrack st in t.SubTracks)
            {
                subTracks.Add(st.ConvertToDTO());
            }
            return new TrackDTO
            {
                Id = t.Id,
                Name = t.Name,
                StartCity = t.StartCity,
                StartState = t.StartState,
                TrackStart = t.TrackStart,
                TrackEnd = t.TrackEnd,
                SubTracks = subTracks
            };
        }

        public static SubTrackDTO ConvertToDTO(this SoundTrackr.Domain.Entities.SubTrack.SubTrack st)
        {
            if (st != null)
            {
                List<TrackStatDTO> trackStats = new List<TrackStatDTO>();
                foreach (SoundTrackr.Domain.Entities.TrackStat.TrackStat ts in st.TrackStats)
                {
                    trackStats.Add(ts.ConvertoToDTO());
                }
                return new SubTrackDTO
                {
                    Id = st.Id,
                    StartTimestamp = st.StartTimestamp,
                    Artist = st.Artist,
                    Song = st.Song,
                    TrackStats = trackStats
                };
            }
            return new SubTrackDTO() { TrackStats = new List<TrackStatDTO>() };
        }

        public static TrackStatDTO ConvertoToDTO(this SoundTrackr.Domain.Entities.TrackStat.TrackStat t)
        {
            return new TrackStatDTO()
            {
                Id = t.Id,
                Timestamp = t.Timestamp,
                Location = new LocationDTO() 
                {
                    Latitude = t.Location.Latitude,
                    Longitude = t.Location.Longitude
                }
            };
        }
    }
}
