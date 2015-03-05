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
        public DateTime TrackStart { get; set; }
        public DateTime TrackEnd { get; set; }
        public string StartCity { get; set; }
        public string StartState { get; set; }
        public List<SongCoord.SongCoord> SongCoords { get; set; }

        protected override void Validate()
        {
        }
    }
}
