using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundTrackr.Common.Domain;

namespace SoundTrackr.Domain.Entities.User
{
    public class User : EntityBase<int>, IAggregateRoot
    {
        public string UserName { get; set; }
        public List<Track.Track> Tracks { get; set; }

        protected override void Validate()
        {
        }
    }
}
