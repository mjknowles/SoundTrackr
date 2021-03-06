﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.Messaging.Track
{
    public class GetTrackRequest : BaseTrackRequest
    {
        public GetTrackRequest(int id, string userId) : base(id) 
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
