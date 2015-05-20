'use strict';

/* Services */

var soundTrackrServices = angular.module('soundTrackrServices', ['ngResource']);

soundTrackrServices.factory('TrackAPI', ['$resource',
  function ($resource) {
      return {
          track: $resource('/api/tracks/:trackId', {}, {
              query: { method: 'GET', params: { trackId: '1' }, isArray: false }
          }),
          tracks: $resource('/api/tracks/:userName', {}, {
              query: { method: 'GET', params: { userName: '' }, isArray: true }
          }),
      };
  }]);
