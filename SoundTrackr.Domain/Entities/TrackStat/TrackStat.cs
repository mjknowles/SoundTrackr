using SoundTrackr.Common.Domain;
using SoundTrackr.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Domain.Entities.TrackStat
{
    public class TrackStat : EntityBase<int>
    {
        public string Song { get; set; }
        public string Artist { get; set; }
        public DateTime Timestamp { get; set; }
        public Location Location { get; set; } 

        protected override void Validate()
        {
        }
    }
}
