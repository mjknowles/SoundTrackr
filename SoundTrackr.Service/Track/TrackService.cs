using SoundTrackr.Domain.Entities.Track;
using SoundTrackr.Service.Exceptions;
using SoundTrackr.Service.Messaging.Track;
using SoundTrackr.Service.DTOs.DTOConversions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTrackr.Service.Track
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepoAccessor _trackServiceRepoAccessor;

        public TrackService(ITrackRepoAccessor trackServiceRepoAccessor)
        {
            if (trackServiceRepoAccessor == null) throw new ArgumentNullException("Track Repo Accessor");
            _trackServiceRepoAccessor = trackServiceRepoAccessor;        
        }

        public GetTrackResponse GetTrack(GetTrackRequest getTrackRequest)
        {
            GetTrackResponse getTrackResponse = new GetTrackResponse();
            SoundTrackr.Domain.Entities.Track.Track track = null;
            try
            {
                track = _trackServiceRepoAccessor.GetTrack(getTrackRequest.Id);
                if (track == null)
                {
                    getTrackResponse.Exception = GetStandardTrackNotFoundException();
                }
                else
                {
                    getTrackResponse.Track = track.ConvertToDTO();
                }
            }
            catch (Exception ex)
            {
                getTrackResponse.Exception = ex;
            }

            return getTrackResponse;
        }

        private ResourceNotFoundException GetStandardTrackNotFoundException()
        {
            return new ResourceNotFoundException("The requested track was not found.");
        }
    }
}
