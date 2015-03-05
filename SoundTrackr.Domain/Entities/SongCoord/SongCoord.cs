using SoundTrackr.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Spatial;

namespace SoundTrackr.Domain.Entities.SongCoord
{
    public class SongCoord : EntityBase<int>
    {
        public string Song { get; set; }
        public string Artist { get; set; }
        public DateTime Timestamp { get; set; }
        public DbGeography Location { get; set; } 

        protected override void Validate()
        {
        }
    }
}
