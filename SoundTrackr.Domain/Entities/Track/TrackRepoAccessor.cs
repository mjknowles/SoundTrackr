using SoundTrackr.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Domain.Entities.Track
{
    public class TrackRepoAccessor : ITrackRepoAccessor
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrackRepoAccessor(ITrackRepository trackRepository, IUnitOfWork unitOfWork)
        {
            if (trackRepository == null) throw new ArgumentNullException("Track Repo");
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _trackRepository = trackRepository;
            _unitOfWork = unitOfWork;
        }

        public Track GetTrack(int id)
        {
            return _trackRepository.FindById(id);
        }

        public List<Track> GetAllTracks()
        {
            return _trackRepository.GetAllTracks();
        }

        public List<Track> GetTracksByUserId(string userId)
        {
            return _trackRepository.GetTracksByUserId(userId);
        }

        public List<Track> GetTracksByUserName(string userName)
        {
            return _trackRepository.GetTracksByUserName(userName);
        }
    }
}
