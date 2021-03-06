﻿using SoundTrackr.Domain.Entities.SubTrack;
using SoundTrackr.Domain.Entities.Track;
using SoundTrackr.Domain.Entities.TrackStat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.DatabaseModels
{
    public class TrackDb : GenericDb<int, Track>
    {
        public string Name { get; set; } 
        public DateTime TrackStart { get; set; }
        public DateTime TrackEnd { get; set; }
        public string StartCity { get; set; }
        public string StartState { get; set; }
        public List<SubTrackDb> SubTracks { get; set; }
        [MaxLength(128)]
        public string  UserId { get; set; }

        public virtual UserDb User { get; set; }

        public override Track ConvertToDomain()
        {
            Track track = new Track()
            {
                Id = Id,
                Name = Name,
                StartCity = StartCity,
                StartState = StartState,
                TrackStart = TrackStart,
                TrackEnd = TrackEnd,
                UserId = UserId,
                SubTracks = new List<SubTrack>()
            };

            foreach (SubTrackDb stdb in SubTracks)
            {
                track.SubTracks.Add(stdb.ConvertToDomain());
            }

            return track;
        }
    }
}
