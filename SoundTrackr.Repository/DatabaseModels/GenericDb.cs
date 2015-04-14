using SoundTrackr.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.DatabaseModels
{
    public class GenericDb : IAggregateRoot
    {
        public int Id { get; set; }
    }
}
