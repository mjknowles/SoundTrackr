using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.DTOs
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TrackStart { get; set; }
        public DateTime TrackEnd { get; set; }
        public string StartCity { get; set; }
        public string StartState { get; set; }
        public List<TrackStatDTO> TrackStats { get; set; }
    }
}
