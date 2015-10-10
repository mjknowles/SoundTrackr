using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.DTOs
{
    public class SubTrackDTO
    {
        public int Id { get; set; }
        public DateTime StartTimestamp { get; set; }
        public List<TrackStatDTO> TrackStats { get; set; }
        public string Artist { get; set; }
        public string Song { get; set; }
    }
}
