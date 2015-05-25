using SoundTrackr.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Domain.Entities.Track
{
    public class Track : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public DateTime TrackStart { get; set; }
        public DateTime TrackEnd { get; set; }
        public string StartCity { get; set; }
        public string StartState { get; set; }
        public List<TrackStat.TrackStat> TrackStats { get; set; }
        public string UserId { get; set; }

        public Track() { }

        protected override void Validate()
        {
        }
    }
}
