using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.DTOs
{
    public class TrackStatDTO
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public LocationDTO Location { get; set; } 
    }
}
