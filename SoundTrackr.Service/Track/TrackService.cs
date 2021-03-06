﻿using SoundTrackr.Domain.Entities.Track;
using SoundTrackr.Service.Exceptions;
using SoundTrackr.Service.Messaging.Track;
using SoundTrackr.Service.DTOs.DTOConversions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundTrackr.Service.DTOs;

namespace SoundTrackr.Service.Track
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            if (trackRepository == null) throw new ArgumentNullException("Track Repo");
            _trackRepository = trackRepository;        
        }

        public GetTrackResponse GetTrack(GetTrackRequest getTrackRequest)
        {
            GetTrackResponse getTrackResponse = new GetTrackResponse();
            SoundTrackr.Domain.Entities.Track.Track track = null;
            try
            {
                track = _trackRepository.FindById(getTrackRequest.Id);
                if (track == null)
                {
                    getTrackResponse.Exception = GetStandardTrackNotFoundException();
                }
                else
                {
                    SortTrackStatsByTimestamp(track);
                    getTrackResponse.Track = track.ConvertToDTO();
                }
            }
            catch (Exception ex)
            {
                getTrackResponse.Exception = ex;
            }

            return getTrackResponse;
        }

        public GetTracksResponse GetTracks(GetTracksRequest getTracksRequest)
        {
            GetTracksResponse getTracksResponse = new GetTracksResponse();
            List<SoundTrackr.Domain.Entities.Track.Track> tracks = null;
            try
            {
                if(!String.IsNullOrEmpty(getTracksRequest.UserId))
                {
                    tracks = _trackRepository.GetTracksByUserId(getTracksRequest.UserId);
                }
                else if(!String.IsNullOrEmpty(getTracksRequest.UserName))
                {
                    tracks = _trackRepository.GetTracksByUserName(getTracksRequest.UserName);
                }
                else
                {
                    tracks = null;
                }
                if (tracks == null)
                {
                    getTracksResponse.Exception = GetStandardTracksNotFoundException();
                }
                else
                {
                    getTracksResponse.Tracks = new List<TrackDTO>();
                    foreach (SoundTrackr.Domain.Entities.Track.Track track in tracks)
                    {
                        getTracksResponse.Tracks.Add(track.ConvertToDTO());
                    } 
                }
            }
            catch (Exception ex)
            {
                getTracksResponse.Exception = ex;
            }

            return getTracksResponse;
        }

        private void SortTrackStatsByTimestamp(SoundTrackr.Domain.Entities.Track.Track track)
        {
            for(int i = 0; i < track.SubTracks.Count; i++)
            {
                track.SubTracks[i].TrackStats = track.SubTracks[i].TrackStats.OrderBy(ts => ts.Timestamp).ToList();
            }
        }

        private ResourceNotFoundException GetStandardTrackNotFoundException()
        {
            return new ResourceNotFoundException("The requested track was not found.");
        }

        private ResourceNotFoundException GetStandardTracksNotFoundException()
        {
            return new ResourceNotFoundException("No tracks found for user.");
        }
    }
}
