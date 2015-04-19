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
            List<TrackStatDTO> trackStats = new List<TrackStatDTO>();
            foreach(SoundTrackr.Domain.Entities.TrackStat.TrackStat ts in t.TrackStats)
            {
                trackStats.Add(ts.ConvertoToDTO());
            }
            return new TrackDTO
            {
                Id = t.Id,
                StartCity = t.StartCity,
                StartState = t.StartState,
                TrackStart = t.TrackStart,
                TrackEnd = t.TrackEnd,
                TrackStats = trackStats
            };
        }

        public static TrackStatDTO ConvertoToDTO(this SoundTrackr.Domain.Entities.TrackStat.TrackStat t)
        {
            return new TrackStatDTO()
            {
                Id = t.Id,
                Artist =  t.Artist,
                Song = t.Song,
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
