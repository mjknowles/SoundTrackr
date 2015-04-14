using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.Messaging.Track
{
    public class GetTracksRequest
    {
        public GetTracksRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }    }
}
