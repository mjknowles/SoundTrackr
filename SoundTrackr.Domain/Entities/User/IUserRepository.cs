using SoundTrackr.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Domain.Entities.User
{
    public interface IUserRepository : IAggregateRootRepository<User, int>
    {
        User GetUser(string userName);
    }
}
