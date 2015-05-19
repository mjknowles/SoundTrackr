'use strict';

/* Services */

var soundTrackrServices = angular.module('soundTrackrServices', ['ngResource']);

soundTrackrServices.factory('Track', ['$resource',
  function ($resource) {
      return {
          track: $resource('/api/tracks/:trackId', {}, {
              query: { method: 'GET', params: { trackId: '' }, isArray: false }
          }),
          tracks: $resource('/api/tracks/:userName', {}, {
              query: { method: 'GET', params: { userName: 'testuser' }, isArray: false }
          }),
      };
  }]);
