using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.Messaging.Track
{
    public abstract class BaseTrackRequest : IntegerIdRequest
    {
        public BaseTrackRequest(int id) : base(id) { }
    }
}
