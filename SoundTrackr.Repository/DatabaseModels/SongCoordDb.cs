using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.DatabaseModels
{
    public class SongCoordDb
    {
        public int Id { get; set; }
        public string Song { get; set; }
        public string Artist { get; set; }
        public DbGeography Location { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
