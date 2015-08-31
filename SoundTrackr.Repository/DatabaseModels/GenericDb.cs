using SoundTrackr.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Repository.DatabaseModels
{
    public abstract class GenericDb<IdType, DomainType> : IAggregateRoot
    {
        public IdType Id { get; set; }
        public abstract DomainType ConvertToDomain();
    }

}
