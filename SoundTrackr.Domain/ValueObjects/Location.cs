using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Domain.ValueObjects
{
    public class Location
    {
        public Location(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
