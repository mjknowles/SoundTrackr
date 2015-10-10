using SoundTrackr.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Domain.Entities.SubTrack
{
    public class SubTrack : EntityBase<int>
    {
        public DateTime StartTimestamp { get; set; }
        public List<TrackStat.TrackStat> TrackStats { get; set; }
        public string Artist { get; set; }
        public string Song { get; set; }

        protected override void Validate()
        {
        }
    }
}
