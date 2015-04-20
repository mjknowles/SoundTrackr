using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.DatabaseModels
{
    public class TrackDb : GenericDb
    {
        public DateTime TrackStart { get; set; }
        public DateTime TrackEnd { get; set; }
        public string StartCity { get; set; }
        public string StartState { get; set; }
        public List<TrackStatDb> TrackStats { get; set; }
        [MaxLength(128)]
        public string  UserId { get; set; }

        public virtual UserDb User { get; set; }
    }
}
