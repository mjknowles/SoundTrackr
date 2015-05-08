'use strict';

/* Services */

var soundTrackrServices = angular.module('soundTrackrServices', ['ngResource']);

soundTrackrServices.factory('Track', ['$resource',
  function ($resource) {
      return $resource('/api/tracks/:trackId', {}, {
          query: { method: 'GET', params: {trackId:''}, isArray:true }
      });
  }]);
